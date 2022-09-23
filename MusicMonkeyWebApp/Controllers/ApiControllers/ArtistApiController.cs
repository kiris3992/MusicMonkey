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
using Newtonsoft.Json;
using RepositoryService.Persistance;

namespace MusicMonkeyWebApp.Controllers.ApiControllers
{
    public class ArtistApiController : BaseApiController
    {




        // GET: api/ArtistApi
        public IEnumerable<Object> GetArtists(string type = "", int? inputCount = 0)
        {
            IEnumerable<Artist> artists = unit.Artists.GetArtistsWithEverything();
            IEnumerable<object> artistDtoModels = new List<object>();
            switch (type)
            {
                case "popular":
                    artistDtoModels = artists.Select(x => ArtistWithPopularityDTOModel(x));
                    break;
                default:
                    artistDtoModels = artists.Select(x => ArtistDTOModel(x));
                    break;
            }
            artistDtoModels = inputCount > 0 ? artistDtoModels.Take((int)inputCount) : artistDtoModels;

            return artistDtoModels; 
        }


        // GET: api/ArtistApi/5
        [ResponseType(typeof(Object))]
        public object GetArtist(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }

            Artist artist = unit.Artists.GetArtistByIdWithEverything(id);
            if (artist == null)
            {
                return NotFound();
            }

            return ArtistDTOModel(artist);
        }

        // PUT: api/ArtistApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutArtist(int id, Artist artist)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != artist.Id) //Here
            {
                return BadRequest();
            }

            Artist mapedArtist = unit.Artists.GetArtistByIdWithEverything(id);

            if (!(mapedArtist is null))
            {
                MapArtist(artist, mapedArtist);
            }

            unit.Artists.Update(mapedArtist);
            unit.Complete();

            return Ok();
        }



        // POST: api/ArtistApi
        [ResponseType(typeof(Artist))]
        public IHttpActionResult PostArtist(Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            unit.Artists.Create(artist);
            unit.Complete();

            return Ok();
        }

        // DELETE: api/ArtistApi/5
        [ResponseType(typeof(Artist))]
        public IHttpActionResult DeleteArtist(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }

            Artist artist = unit.Artists.GetArtistByIdWithEverything(id);
            if (artist == null)
            {
                return NotFound();
            }

            DeleteAllAlbumsAndTracksOfArtist(artist);
            unit.Artists.DeleteById(id);
            unit.Complete();

            return Ok();
        }

        //Custom Service Methods
        private object ArtistDTOModel(Artist a)
        {
            return new {
                a.Id,
                a.Name,
                Country = a.Country.ToString().Replace("_", " "),
                a.PhotoUrl,
                a.CareerStartDate,
                ArtistGenres = a.ArtistGenres.SelectMany(p => new[] { p.Type }),
                Albums = a.Albums.Select(x => new {
                    x.Id,
                    x.Title,
                    x.ReleaseDate,
                    x.CoverPhotoUrl,
                    AlbumGenres = x.AlbumGenres.SelectMany(p => new[] { p.Type }),
                    Tracks = x.Tracks.Select(y => new {
                        y.Id,
                        y.Title,
                        y.DurationSecs,
                        y.AudioUrl,
                        y.Popularity,
                        TrackGenres = y.TrackGenres.SelectMany(p => new[] { p.Type })
                    }),
                }),
            };
        }
        private object ArtistWithPopularityDTOModel(Artist artist)
        {
            return new
            {
                artist.Id,
                artist.Name,
                Popularity = Math.Round(AvgArtistPop(artist.Albums.Select(x => AvgAlbumPop(x))), 2)
            };
        }

        private double AvgArtistPop(IEnumerable<double> albumPopularities) => albumPopularities.Average();

        private double AvgAlbumPop(Album album) => album.Tracks.Average(x => x.Popularity);

        private void DeleteAllAlbumsAndTracksOfArtist(Artist artist)
        {
            var albums = unit.Albums
                .GetAlbumsWithEverything()
                .Where(x => x.Artist == artist)
                .ToList();

            if (albums.Count >= 1)
            {
                foreach (var album in albums)
                {
                    var tracks = unit.Tracks
                        .GetAll()
                        .Where(x => x.Album == album)
                        .ToList();

                    unit.Tracks.DeleteRange(tracks);
                }

                unit.Albums.DeleteRange(albums);
            }
        }
        private void MapArtist(Artist incomingArtist, Artist mapedArtist)
        {
            mapedArtist.Name = incomingArtist.Name;
            mapedArtist.Country = incomingArtist.Country;
            mapedArtist.PhotoUrl = incomingArtist.PhotoUrl;
            mapedArtist.CareerStartDate = incomingArtist.CareerStartDate;
            mapedArtist.Albums = incomingArtist.Albums;
            mapedArtist.ArtistGenres = incomingArtist.ArtistGenres;
        }

        private bool ArtistExists(int id)
        {
            return db.Artists.Count(e => e.Id == id) > 0;
        }
    }
}