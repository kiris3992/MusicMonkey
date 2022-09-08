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
        public IEnumerable<Object> GetAlbums()
        {
            return unit.Albums
                .GetAlbumsWithEverything()
                .Select(x => AlbumDTOModel(x));
        }

        // GET: api/AlbumApi/5
        [ResponseType(typeof(Album))]
        public Object GetAlbum(int? id)
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

            return AlbumDTOModel(album);
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

            db.Entry(album).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlbumExists(id))
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

        // POST: api/AlbumApi
        [ResponseType(typeof(Album))]
        public IHttpActionResult PostAlbum(Album album)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Albums.Add(album);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = album.Id }, album);
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
        private Object AlbumDTOModel(Album album)
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
                    ArtistGenres = album.Artist.ArtistGenres.SelectMany(p => new string[] { p.Type})  //Artist Genres
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
                AlbumGenres = album.AlbumGenres.SelectMany(p => new string[] { p.Type})  //Album Genres
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

        private bool AlbumExists(int id)
        {
            return db.Albums.Count(e => e.Id == id) > 0;
        }
    }
}