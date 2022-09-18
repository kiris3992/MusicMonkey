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
    public class GenreApiController : BaseApiController
    {
        // GET: api/GenreApi
        public IEnumerable<object> GetGenres(string type = "")
        {
            IEnumerable<Genre> genres = unit.Genres.GetGenresWithEverything();
            IEnumerable<object> genreDtoModels = new List<object>();
            switch (type)
            {
                case "trackcount":
                    genreDtoModels = genres.OrderByDescending(x => x.Tracks.Count)
                        .Select(x => TracksByGenresDTOModel(x));
                    break;
                default:
                    genreDtoModels = genres.Select(x => PartialGenreDTOModel(x));
                    break;
            }
            return genreDtoModels;
        }

        // GET: api/GenreApi/5
        [ResponseType(typeof(Genre))]
        public object GetGenre(int id)
        {
            Genre genre = db.Genres.Find(id);
            if (genre == null)
            {
                return NotFound();
            }

            return Ok(genre);
        }

        // PUT: api/GenreApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGenre(int id, Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != genre.Id)
            {
                return BadRequest();
            }

            db.Entry(genre).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenreExists(id))
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

        // POST: api/GenreApi
        [ResponseType(typeof(Genre))]
        public IHttpActionResult PostGenre(Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Genres.Add(genre);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = genre.Id }, genre);
        }

        // DELETE: api/GenreApi/5
        [ResponseType(typeof(Genre))]
        public IHttpActionResult DeleteGenre(int id)
        {
            Genre genre = db.Genres.Find(id);
            if (genre == null)
            {
                return NotFound();
            }

            db.Genres.Remove(genre);
            db.SaveChanges();

            return Ok(genre);
        }

        //Custom Service Methods
        private object PartialGenreDTOModel(Genre genre)
        {
            return new
            {
                genre.Id,
                genre.Type,
                Artists = genre.Artists.Select(x => new 
                { 
                    x.Name
                }),
                Albums = genre.Albums.Select(x => new 
                {
                    x.Title
                }),
                Tracks = genre.Tracks.Select(x => new 
                {
                    x.Title
                })
            };
        }
        private object TracksByGenresDTOModel(Genre genre)
        {
            return new
            {
                genre.Id,
                genre.Type,
                TrackCount = genre.Tracks.Count
            };
        }

        private bool GenreExists(int id)
        {
            return db.Genres.Count(e => e.Id == id) > 0;
        }
    }
}