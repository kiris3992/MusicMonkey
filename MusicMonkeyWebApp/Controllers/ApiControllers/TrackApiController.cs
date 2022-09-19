using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.Http.ModelBinding;
using System.Web.UI;
using DAL;
using Entities.Models;
using Microsoft.Owin.Security.Provider;
using MusicMonkeyWebApp.Models.Paging;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace MusicMonkeyWebApp.Controllers.ApiControllers
{

    [EnableCors("*", "*", "*")]
    public class TrackApiController : BaseApiController
    {
        // GET: api/TrackApi
        public IEnumerable<object> GetTracks(string type = "")
        {
            IEnumerable<Track> tracks = unit.Tracks.GetTracksWithEverything();
            IEnumerable<object> trackDtoModels = new List<object>();
            
            switch (type)
            {
                case "full":
                    trackDtoModels = tracks.Select(x => FullTrackDTOModel(x));
                    break;
                default:
                    trackDtoModels = tracks.Select(x => PartialTrackDTOModel(x));
                    break;
            }

            return trackDtoModels;
        }


        [HttpPost]
        public dynamic GetTracksWithPaging(dynamic args)
        {
            PagingModel pagingModel = null;
            if (args["PageIndex"] != null && args["ItemsPerPage"] != null)
            {
                pagingModel = new PagingModel { PageIndex = args.PageIndex, ItemsPerPage = args.ItemsPerPage };
            }

            IEnumerable<object> tracks;
            if (args["type"] != null && args.type == "full")
            {
                tracks = unit.Tracks.GetTracksWithEverything(pagingModel).Select(x => FullTrackDTOModel(x));
            }
            else
            {
                tracks = unit.Tracks.GetTracksWithEverything(pagingModel).Select(x => PartialTrackDTOModel(x));
            }

            if (pagingModel != null)
            {
                pagingModel = new PagingModel(pagingModel.PageIndex, pagingModel.ItemsPerPage, unit.Tracks.Count());
            }

            return new { tracks, paging = pagingModel }; ;
        }

        // GET: api/TrackApi/5
        [ResponseType(typeof(Track))]
        public object GetTrack(int? id)
        {

            if (id is null)
            {
                return BadRequest();
            }

            Track track = unit.Tracks.GetTrackByIdWithEverything(id);
            if (track == null)
            {
                return NotFound();
            }

            return PartialTrackDTOModel(track);
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

            Track mapedTrack = unit.Tracks.GetTrackByIdWithEverything(id);
            MapTrack(mapedTrack, track);
            unit.Tracks.Update(mapedTrack);
            unit.Complete();

            return Ok();
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult PutTrack(dynamic track)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Track mapTrack = unit.Tracks.GetById((int)track.Id);

                if (mapTrack == null) return BadRequest();

                mapTrack.Title = track.Title;
                mapTrack.DurationSecs = track.DurationSecs;
                mapTrack.Popularity = track.Popularity;

                mapTrack.Album = unit.Albums.GetById((int)track.AlbumId);
                mapTrack.Album.Artist = unit.Artists.GetById((int)track.ArtistId);

                unit.Tracks.Update(mapTrack);

                if (unit.Complete() > 0) return Ok(); else return InternalServerError();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        // POST: api/TrackApi
        [ResponseType(typeof(Track))]
        public IHttpActionResult PostTrack(Track track)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            unit.Tracks.Create(track);
            unit.Complete();

            return Ok();
        }

        // DELETE: api/TrackApi/5
        [ResponseType(typeof(Track))]
        public IHttpActionResult DeleteTrack(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }

            Track track = unit.Tracks.GetTrackByIdWithEverything(id);
            if (track == null)
            {
                return NotFound();
            }

            unit.Tracks.DeleteById(id);
            unit.Complete();

            return Ok();
        }

        //Custom Service Methods
        private object FullTrackDTOModel(Track track)
        {
            return new  //Tracks
            {
                track.Id,
                track.Title,
                track.DurationSecs,
                track.AudioUrl,
                track.Popularity,
                TrackGenres = track.TrackGenres.SelectMany(p => new string[] { p.Type }),
                Album = new  //Album
                {
                    track.Album.Id,
                    track.Album.Title,
                    track.Album.ReleaseDate,
                    track.Album.CoverPhotoUrl,
                    AlbumGenres = track.Album.AlbumGenres.SelectMany(p => new string[] { p.Type }),
                    Artist = new  //Artist
                    {
                        track.Album.Artist.Name,
                        track.Album.Artist.Country,
                        track.Album.Artist.PhotoUrl,
                        track.Album.Artist.CareerStartDate,
                        ArtistGenres = track.Album.Artist.ArtistGenres.SelectMany(p => new string[] { p.Type })
                    }
                }
            };
        }
        private object PartialTrackDTOModel(Track track)
        {
            return new
            {
                Id = track.Id,
                Title = track.Title,
                DurationSecs = track.DurationSecs,
                AudioUrl = track.AudioUrl,
                Popularity = track.Popularity,
                AlbumTitle = track.Album != null ? track.Album.Title : null,
                AlbumId = track.Album != null ? track.Album.Id : -1,
                ArtistName = track.Album != null ? track.Album.Artist.Name : null,
                ArtistId = track.Album != null ? track.Album.Artist.Id : -1,
                TrackGenres = track.TrackGenres.SelectMany(p => new string[] { p.Type })
            };
        }
        private void MapTrack(Track mapedTrack, Track incomingTrack)
        {
            mapedTrack.Title = incomingTrack.Title;
            mapedTrack.DurationSecs = incomingTrack.DurationSecs;
            mapedTrack.AudioUrl = incomingTrack.AudioUrl;
            mapedTrack.Popularity = incomingTrack.Popularity;
        }

        private bool TrackExists(int id)
        {
            return db.Tracks.Count(e => e.Id == id) > 0;
        }
    }
}