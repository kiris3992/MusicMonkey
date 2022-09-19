using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DAL;
using Entities.Models;

namespace MusicMonkeyWebApp.Controllers.ApiControllers
{
    public class AlbumApiController : BaseApiController
    {
        // GET: api/AlbumApi
        public IEnumerable<object> GetAlbums(string type = "")
        {
            IEnumerable<Album> albums = unit.Albums.GetAlbumsWithEverything();
            IEnumerable<object> albumDtoModels = new List<Album>();

            switch (type)
            {
                case "full":
                    albumDtoModels = albums.Select(x => FullAlbumDTOModel(x));
                    break;
                case "popular":
                    albumDtoModels = albums.Select(x => AlbumWithPopularityDTOModel(x));
                    break;
                case "trackcount":
                    albumDtoModels = albums.OrderByDescending(x => x.Tracks.Count)
                        .Select(x => AlbumWithTrackCountDTOModel(x));
                    break;
                case "dateDesc":
                    albumDtoModels = albums.OrderByDescending(x => x.ReleaseDate)
                        .Select(x => FullAlbumDTOModel(x));
                    break;
                default:
                    albumDtoModels = albums.Select(x => PartialAlbumDTOModel(x));
                    break;
            }

            return albumDtoModels;
        }

        // GET: api/AlbumApi/5
        [ResponseType(typeof(Album))]
        public object GetAlbum(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }

            Album album = unit.Albums.GetAlbumByIdWithEverything(id);
            if (album == null)
            {
                return NotFound();
            }

            return PartialAlbumDTOModel(album);
        }

        // PUT: api/AlbumApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAlbum(int id, Album album)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != album.Id)
            {
                return BadRequest();
            }

            Album mapedAlbum = unit.Albums.GetAlbumByIdWithEverything(id);

            if (!(mapedAlbum is null))
            {
                MapAlbum(mapedAlbum, album);
            }

            unit.Albums.Update(mapedAlbum);
            unit.Complete();

            return Ok();
        }

        // POST: api/AlbumApi
        [ResponseType(typeof(Album))]
        public IHttpActionResult PostAlbum(Album album)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            unit.Albums.Create(album);
            unit.Complete();

            return Ok();
        }

        // DELETE: api/AlbumApi/5
        [ResponseType(typeof(Album))]
        public IHttpActionResult DeleteAlbum(int? id)
        {
            Album album = unit.Albums.GetAlbumByIdWithEverything(id);
            if (album == null)
            {
                return NotFound();
            }

            DeleteAllTracksOfAlbum(album);
            unit.Albums.DeleteById(id);
            unit.Complete();

            return Ok();
        }


        //Custom Service Methods
        private object FullAlbumDTOModel(Album album)
        {
            return new
            {
                Id = album.Id,
                Title = album.Title,
                ReleaseDate = album.ReleaseDate,
                CoverPhotoUrl = album.CoverPhotoUrl,
                Artist = new  //Artists
                {
                    Id = album.Artist.Id,
                    Name = album.Artist.Name,
                    Country = album.Artist.Country,
                    PhotoUrl = album.Artist.PhotoUrl,
                    CareerStartDate = album.Artist.CareerStartDate,
                    ArtistGenres = album.Artist.ArtistGenres.SelectMany(p => new string[] { p.Type })  //Artist Genres
                },
                Tracks = album.Tracks.Select(x => new  //Tracks
                {
                    Id = x.Id,
                    Title = x.Title,
                    DurationSecs = x.DurationSecs,
                    AudioUrl = x.AudioUrl,
                    Popularity = x.Popularity,
                    TrackGenres = x.TrackGenres.SelectMany(p => new string[] { p.Type })  //Track Genres
                }),
                AlbumGenres = album.AlbumGenres.SelectMany(p => new string[] { p.Type })  //Album Genres
            };
        }
        private object AlbumWithPopularityDTOModel(Album album)
        {
            return new
            {
                album.Id,
                album.Title,
                Popularity = Math.Round(album.Tracks.Average(x => x.Popularity) , 2)
            };
        }
        private object AlbumWithTrackCountDTOModel(Album album)
        {
            {
                return new
                {
                    album.Id,
                    album.Title,
                    TrackCount = album.Tracks.Count
                };
            }
        }
        private object PartialAlbumDTOModel(Album album)
        {
            return new
            {
                Id = album.Id,
                Title = album.Title,
                ReleaseDate = album.ReleaseDate,
                CoverPhotoUrl = album.CoverPhotoUrl,
                ArtistName = album.Artist != null ? album.Artist.Name : null,
                TrackTitles = album.Tracks.SelectMany(p => new string[] { p.Title}),
                AlbumGenres = album.AlbumGenres.SelectMany(p => new string[] { p.Type})
            };
        }
        private void DeleteAllTracksOfAlbum(Album album)
        {
            var tracks = unit.Tracks
                .GetAll()
                .Where(x => x.Album == album)
                .ToList();

            if (tracks.Count >= 1)
            {
                unit.Tracks.DeleteRange(tracks);
            }
        }
        private void MapAlbum(Album mapedAlbum, Album incomingAlbum)
        {
            mapedAlbum.Title = incomingAlbum.Title;
            mapedAlbum.ReleaseDate = incomingAlbum.ReleaseDate;
            mapedAlbum.CoverPhotoUrl = incomingAlbum.CoverPhotoUrl;
            mapedAlbum.Artist = incomingAlbum.Artist;
            mapedAlbum.Tracks = incomingAlbum.Tracks;
            mapedAlbum.AlbumGenres = incomingAlbum.AlbumGenres;
        }

        private bool AlbumExists(int id)
        {
            return db.Albums.Count(e => e.Id == id) > 0;
        }
    }
}