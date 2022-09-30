using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Entities.Models;
using Microsoft.Ajax.Utilities;
using MusicMonkeyWebApp.Models.Paging;

namespace MusicMonkeyWebApp.Controllers.ApiControllers
{

    [EnableCors("*", "*", "*")]
    public class TrackApiController : BaseApiController
    {
        // GET: api/TrackApi
        public IEnumerable<object> GetTracks(string type = "", int? inputCount = 0)
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
            trackDtoModels = inputCount > 0 ? trackDtoModels.Take((int)inputCount) : trackDtoModels;
  
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

            string sortProp = args["sortProp"];
            string filter = args["filter"];

            IEnumerable<object> tracks;
            if (args["type"] != null && args.type == "full")
            {
                tracks = unit.Tracks.GetTracksWithEverything(pagingModel, sortProp, filter).Select(x => FullTrackDTOModel(x));
            }
            else
            {
                tracks = unit.Tracks.GetTracksWithEverything(pagingModel, sortProp, filter).Select(x => PartialTrackDTOModel(x));
            }

            if (pagingModel != null)
            {
                //var count = string.IsNullOrWhiteSpace(filter) ? unit.Tracks.Count() : tracks.Count();
                var count = unit.Tracks.Count(); // string.IsNullOrWhiteSpace(filter) ? tracks.Count() : unit.Tracks.Count();

                pagingModel = new PagingModel(pagingModel.PageIndex, pagingModel.ItemsPerPage, count);
            }


            return new { tracks, paging = pagingModel };
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
        public IHttpActionResult PostTrack(Track track, string type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            unit.Tracks.Create(MapAndReturnNewTrack(track));
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
        private object RandomTrackDTOModel(int id)
        {
            Track track = unit.Tracks.GetTrackByIdWithEverything(id);

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
                ArtistPhotoUrl = track.Album?.Artist?.PhotoUrl,
                Popularity = track.Popularity,
                AlbumTitle = track.Album != null ? track.Album.Title : null,
                AlbumId = track.Album != null ? track.Album.Id : -1,
                ArtistName = track.Album != null ? track.Album.Artist.Name : null,
                ArtistId = track.Album != null ? track.Album.Artist.Id : -1,
                TrackGenres = track.TrackGenres.SelectMany(p => new string[] { p.Type })
            };
        }
        private Track MapAndReturnNewTrack(Track track)
        {
            Track newTrack = new Track();
            newTrack.Title = track.Title;
            newTrack.DurationSecs = track.DurationSecs;
            newTrack.AudioUrl = track.AudioUrl;
            newTrack.Popularity = track.Popularity;
            newTrack.AlbumId = track.AlbumId;
            foreach (var item in track.TrackGenres.Select(x => x.Id).ToList()) newTrack.TrackGenres.Add(unit.Genres.GetById(item));
            return newTrack;
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