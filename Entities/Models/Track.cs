using Entities.Enums;
using System.Collections.Generic;

namespace Entities.Models
{
    public class Track : MusicEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int DurationSecs { get; set; }
        public string AudioUrl { get; set; }
        public int Popularity { get; set; }

        // Navigation Properies
        public Album Album { get; set; }
        public ICollection<Genre> TrackGenres { get; set; }

        public Track()
        {
            TrackGenres = new HashSet<Genre>();
        }

        public Track(string title, int durationSecs, string audioUrl, Album album, ICollection<Genre> trackGenres)
        {
            Title = title;
            DurationSecs = durationSecs;
            AudioUrl = audioUrl;
            Album = album;
            TrackGenres = trackGenres;

        }

        public Track(string title, int durationSecs, string audioUrl, Album album, ICollection<Genre> trackGenres, int popularity)
        {
            Title = title;
            DurationSecs = durationSecs;
            AudioUrl = audioUrl;
            Album = album;
            TrackGenres = trackGenres;
            Popularity = popularity;

        }

        public Track(string title, int durationSecs, string audioUrl, Album album, ICollection<Genre> trackGenres, int popularity)
        {
            Title = title;
            DurationSecs = durationSecs;
            AudioUrl = audioUrl;
            Album = album;
            TrackGenres = trackGenres;
            Popularity = popularity;
        }
    }
}
