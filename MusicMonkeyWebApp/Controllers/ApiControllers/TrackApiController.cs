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
                TrackGenres = track.TrackGenres.SelectMany(p => new string[] { p.Type }),  //track Genres
                Album = new  //Album
                {
                    track.Album.Id,
                    track.Album.Title,
                    track.Album.ReleaseDate,
                    track.Album.CoverPhotoUrl,
                    Artist = new  //Artist
                    {
                        track.Album.Artist.Name,
                        track.Album.Artist.Country,
                        track.Album.Artist.PhotoUrl,
                        track.Album.Artist.CareerStartDate,
                        ArtistGenres = track.Album
                                .Artist
                                .ArtistGenres
                                .SelectMany(p => new string[] { p.Type })  //Artist Genres
                    },
                    AlbumGenres = track
                            .Album
                            .AlbumGenres
                            .SelectMany(p => new string[] { p.Type })  //Album Genres
                },
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
                ArtistName = track.Album != null ? track.Album.Artist.Name : null,
                TrackGenres = track.TrackGenres.SelectMany(p => new string[] { p.Type})
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