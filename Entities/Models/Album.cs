using Entities.Enums;
using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public class Album :MusicEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string CoverPhotoUrl { get; set; }

        // Navigation Properies
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public ICollection<Track> Tracks { get; set; }
        public ICollection<Genre> AlbumGenres { get; set; }

        public Album()
        {
            Tracks = new HashSet<Track>();
            AlbumGenres = new HashSet<Genre>();
        }

        public Album(string title, DateTime releaseDate, string coverPhotoUrl, Artist artist, ICollection<Genre> albumGenres)
        {
            Title = title;
            ReleaseDate = releaseDate;
            CoverPhotoUrl = coverPhotoUrl;
            Artist = artist;
            Tracks = new HashSet<Track>();
            AlbumGenres = albumGenres;
        }
    }
}
