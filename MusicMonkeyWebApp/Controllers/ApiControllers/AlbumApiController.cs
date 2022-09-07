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
    public class AlbumApiController : BaseApiController
    {
        // GET
        public IEnumerable<Object> GetAlbums()
        {
            var albums = unit.Albums.GetAlbumsWithEverything();

            return albums.Select(a => new { 
                a.Id,
                a.Title,
                a.ReleaseDate,
                a.CoverPhotoUrl,
                AlbumGenres = a.AlbumGenres.SelectMany(g=> new string[] { g.Type }),
                Tracks = a.Tracks.Select(t => new { 
                    t.Title,
                    t.DurationSecs,
                    t.AudioUrl,
                    t.Popularity,
                    TrackGenres = t.TrackGenres.SelectMany(g => new string[] { g.Type })
                })
            });
        }

        // GET
        public IHttpActionResult GetAlbum(int id)
        {
            Album album = unit.Albums.GetById(id);
            if(album == null)
            {
                return NotFound();
            }
            return Ok(album);
        }

        // PUT
        public IHttpActionResult PutAlbum(int id, Album album)
        {
            if(!ModelState.IsValid || id != album.Id)
            {
                return BadRequest(ModelState);
            }
            return null;
        }
    }
}