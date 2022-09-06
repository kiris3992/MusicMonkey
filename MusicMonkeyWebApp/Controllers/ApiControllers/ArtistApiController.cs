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
    public class ArtistApiController : ApiController 
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private UnitOfWork unit;

        public ArtistApiController()
        {
            unit = new UnitOfWork(db);
        }

        // GET: api/ArtistApi
        public IEnumerable<Object> GetArtists()
        {
            return MapArtistsToDTO();
        }








        private IEnumerable<Object> MapArtistsToDTO()
        {
            var artists = unit.Artists.GetAllWithEverything();
            var artistDTO = artists.Select(x =>
                new
                {
                    Id = x.Id,
                    Name = x.Name,
                    Country = x.Country,
                    PhotoUrl = x.PhotoUrl,
                    CareerStartDate = x.CareerStartDate,
                    Albums = x.Albums.Select(y =>
                        new //Albums
                        {
                            Title = y.Title,
                            ReleaseDate = y.ReleaseDate,
                            CoverPhotoUrl = y.CoverPhotoUrl,
                            Tracks = y.Tracks.Select(i =>
                                new //Tracks
                                {
                                    Title = i.Title,
                                    DurationSecs = i.DurationSecs,
                                    AudioUrl = i.AudioUrl,
                                    Popularity = i.Popularity,
                                    TrackGenres = i.TrackGenres.Select(p =>
                                        new //Track Genres
                                        {
                                            Type = p.Type
                                        }
                                    )
                                }
                            ),
                            AlbumGenres = y.AlbumGenres.Select(p =>
                               new //Album Genres
                               {
                                   Type = p.Type
                               }
                            )
                        }
                    ),
                    ArtistGenres = x.ArtistGenres.Select(p =>
                       new  //Artist Genres
                     {
                           Type = p.Type
                       }
                  )
                }
            );
            return artistDTO;
        }

        // GET: api/ArtistApi/5
        [ResponseType(typeof(Artist))]
        public IHttpActionResult GetArtist(int id)
        {
            Artist artist = unit.Artists.GetById(id);
            if (artist == null)
            {
                return NotFound();
            }

            return Ok(artist);
        }

        // PUT: api/ArtistApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutArtist(int id, Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != artist.Id)
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

            db.Artists.Add(artist);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = artist.Id }, artist);
        }

        // DELETE: api/ArtistApi/5
        [ResponseType(typeof(Artist))]
        public IHttpActionResult DeleteArtist(int id)
        {
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return NotFound();
            }

            db.Artists.Remove(artist);
            db.SaveChanges();

            return Ok(artist);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unit.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ArtistExists(int id)
        {
            return db.Artists.Count(e => e.Id == id) > 0;
        }
    }
}