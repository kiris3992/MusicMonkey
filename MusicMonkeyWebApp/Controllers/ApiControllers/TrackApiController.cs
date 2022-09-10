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
    public class TrackApiController : BaseApiController
    {
        // GET: api/TrackApi
        public IEnumerable<Object> GetTracks()
        {
             return unit.Tracks
                .GetTracksWithEverything()
                .Select(x => CustomTrackDTOModel(x));
        }

        // GET: api/TrackApi/5
        [ResponseType(typeof(Track))]
        public Object GetTrack(int? id)
        {

            if (id is null)
            {
                return BadRequest();
            }

            Track track = db.Tracks.Find(id);
            if (track == null)
            {
                return NotFound();
            }

            return Ok(track);
        }

        // PUT: api/TrackApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTrack(int id, Track track)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != track.Id)
            {
                return BadRequest();
            }

            db.Entry(track).State = EntityState.Modified;
            
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrackExists(id))
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

        // POST: api/TrackApi
        [ResponseType(typeof(Track))]
        public IHttpActionResult PostTrack(Track track)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tracks.Add(track);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = track.Id }, track);
        }

        // DELETE: api/TrackApi/5
        [ResponseType(typeof(Track))]
        public IHttpActionResult DeleteTrack(int id)
        {
            Track track = db.Tracks.Find(id);
            if (track == null)
            {
                return NotFound();
            }

            db.Tracks.Remove(track);
            db.SaveChanges();

            return Ok(track);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //Custom Service Methods
        private Object FullTrackDTOModel(Track track)
        {
            return new  //Tracks
            {
                Id = track.Id,
                Title = track.Title,
                DurationSecs = track.DurationSecs,
                AudioUrl = track.AudioUrl,
                Popularity = track.Popularity,
                Album = new  //Album
                {
                    Id = track.Album.Id,
                    Title = track.Album.Title,
                    ReleaseDate = track.Album.ReleaseDate,
                    CoverPhotoUrl = track.Album.CoverPhotoUrl,
                    Artist = new  //Artist
                    {
                        Name = track.Album.Artist.Name,
                        Country = track.Album.Artist.Country,
                        PhotoUrl = track.Album.Artist.PhotoUrl,
                        CareerStartDate = track.Album.Artist.CareerStartDate,
                        ArtistGenres = track.Album
                                .Artist
                                .ArtistGenres
                                .Select(p => new string[] { p.Type })  //Artist Genres
                    },
                    AlbumGenres = track
                            .Album
                            .AlbumGenres
                            .Select(p => new string[] { p.Type })  //Album Genres
                },
                TrackGenres = track.TrackGenres.Select(p => new string[] { p.Type })  //track Genres
            };
        }
        private Object CustomTrackDTOModel(Track track)
        {
            return new
            {
                Id = track.Id,
                Title = track.Title,
                DurationSecs = track.DurationSecs,
                AudioUrl = track.AudioUrl,
                Popularity = track.Popularity,
                AlbumTitle = track.Album.Title,
                ArtistName = track.Album.Artist.Name
            };
        }

        private bool TrackExists(int id)
        {
            return db.Tracks.Count(e => e.Id == id) > 0;
        }
    }
}