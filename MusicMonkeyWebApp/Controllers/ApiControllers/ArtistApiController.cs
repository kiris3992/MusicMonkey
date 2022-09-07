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
using RepositoryService.Persistance;

namespace MusicMonkeyWebApp.Controllers.ApiControllers
{
    public class ArtistApiController : BaseApiController
    {
        // GET: api/ArtistApi
        public IEnumerable<Object> GetArtists()
        {
            return unit.Artists
                .GetArtistsWithEverything()
                .Select(x => ArtistDTOModel(x));
        }


        // GET: api/ArtistApi/5
        [ResponseType(typeof(Artist))]
        public Object GetArtist(int? id)
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

            db.Entry(artist).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtistExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
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
            db.SaveChanges();
            //return Ok(artist);

            return CreatedAtRoute("DefaultApi", new { id = artist.Id }, artist);
        }

        // DELETE: api/ArtistApi/5
        [ResponseType(typeof(Artist))]
        public IHttpActionResult DeleteArtist(int id)
        {
            Artist artist = unit.Artists.GetArtistByIdWithEverything(id);
            if (artist == null)
            {
                return NotFound();
            }

            DeleteAllAlbumsAndTracksOfArtist(artist);

            unit.Artists.DeleteById(id);
            unit.Artists.Save();

            return Ok(artist);
        }


        //Custom Service Methods
        private Object ArtistDTOModel(Artist artist)
        {
            return new
            {
                Id = artist.Id,
                Name = artist.Name,
                Country = artist.Country,
                PhotoUrl = artist.PhotoUrl,
                CareerStartDate = artist.CareerStartDate,
                Albums = artist.Albums.Select(x => new  //Albums
                {
                    Title = x.Title,
                    ReleaseDate = x.ReleaseDate,
                    CoverPhotoUrl = x.CoverPhotoUrl,
                    Tracks = x.Tracks.Select(y => new //Tracks
                    {
                        Title = y.Title,
                        DurationSecs = y.DurationSecs,
                        AudioUrl = y.AudioUrl,
                        Popularity = y.Popularity,
                        TrackGenres = y.TrackGenres.SelectMany(p => new string[] { p.Type })  //Track Genres
                    }),
                    AlbumGenres = x.AlbumGenres.SelectMany(p => new string[] { p.Type })  //Album Genres
                }),
                ArtistGenres = artist.ArtistGenres.SelectMany(p => new string[] { p.Type })  //Artist Genres
            };
        }
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

        private bool ArtistExists(int id)
        {
            return db.Artists.Count(e => e.Id == id) > 0;
        }
    }
}