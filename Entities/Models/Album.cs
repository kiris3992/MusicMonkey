﻿using Entities.Enums;
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
        public List<Genre> AlbumGenres { get; set; }

        // Navigation Properies
        public Artist Artist { get; set; }
        public ICollection<Track> Tracks { get; set; }

        public Album()
        {
            AlbumGenres = new List<Genre>();
            Tracks = new HashSet<Track>();
        }

        public Album(string title, DateTime releaseDate, string coverPhotoUrl, List<Genre> albumGenres, Artist artist)
        {
            Title = title;
            ReleaseDate = releaseDate;
            CoverPhotoUrl = coverPhotoUrl;
            Artist = artist;
            AlbumGenres = albumGenres;
            Tracks = new HashSet<Track>();
        }
    }
}
