using Entities.Enums;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Initializers.TeamsSeeding
{
    public class Seed_Spyros : AbsTeamSeeder, ITeamSeeder
    {
       
            public List<Artist> GetArtists()
            {
                var artists = new List<Artist>
            {
                new Artist { // Eminem
                    Name = "Eminem", Country = Country.USA, CareerStartDate = new DateTime(1987, 12, 1), PhotoUrl = "", ArtistGenres = new List<Genre> { rap },
                    Albums = new List<Album> {
                        new Album {
                            Title = "Marshall Mathers LP", ReleaseDate = new DateTime(1999, 9, 4), CoverPhotoUrl = "",
                            Tracks = new List<Track> {
                                new Track { Title = "Public Service Announce", DurationSecs = 301, TrackGenres = new List<Genre> { rap }, Popularity = 1, AudioUrl = "" },
                                new Track { Title = "Kill You", DurationSecs = 455, TrackGenres = new List<Genre> { rap }, Popularity = 4, AudioUrl = "" },
                                new Track { Title = "Stan", DurationSecs = 119, TrackGenres = new List<Genre> { rap }, Popularity = 4, AudioUrl = "" },
                                new Track { Title = "Breed", DurationSecs = 184, TrackGenres = new List<Genre> { rap }, Popularity = 3, AudioUrl = "" },
                                new Track { Title = "Who Knew", DurationSecs = 257, TrackGenres = new List<Genre> { rap }, Popularity = 3, AudioUrl = "" },
                                new Track { Title = "Steve Berman", DurationSecs = 54, TrackGenres = new List<Genre> { rap }, Popularity = 2, AudioUrl = "" },

                            }
                        }
                    }
                },
                new Artist { // Gun's N Roses
                    Name = "Gun's N Roses", Country = Country.USA, CareerStartDate = new DateTime(1985, 1, 1), PhotoUrl = "", ArtistGenres = new List<Genre> { hardRock, rock },
                    Albums = new List<Album> {
                        new Album {
                            Title = "Appetite for Destruction", ReleaseDate = new DateTime(1987, 21, 6), CoverPhotoUrl = "",
                            Tracks = new List<Track> {
                                new Track { Title = "Welcome to the Jungle", DurationSecs = 546, TrackGenres = new List<Genre> { rock }, Popularity = 5, AudioUrl = "" },
                                new Track { Title = "It's so easy", DurationSecs = 200, TrackGenres = new List<Genre> { rock }, Popularity = 3, AudioUrl = "" },
                                new Track { Title = "Night Trains", DurationSecs = 290, TrackGenres = new List<Genre> { rock }, Popularity = 4, AudioUrl = "" },
                                new Track { Title = "Out ta Get Me", DurationSecs = 260, TrackGenres = new List<Genre> { rock }, Popularity = 3, AudioUrl = "" },
                                new Track { Title = "Paradise City", DurationSecs = 300, TrackGenres = new List<Genre> { hardRock, rock }, Popularity = 5, AudioUrl = "" },

                            }
                        },
                        new Album {
                            Title = "Use Your Illusion", ReleaseDate = new DateTime (1991,1,1), CoverPhotoUrl = "",
                            Tracks = new List<Track> {
                                new Track { Title = "Right Next Door to Hell", DurationSecs = 185, TrackGenres = new List<Genre> { rock }, Popularity = 3, AudioUrl = "" },
                                new Track { Title = "Dust N' Bones", DurationSecs = 199, TrackGenres = new List<Genre> { rock }, Popularity = 5, AudioUrl = "" },
                                new Track { Title = "Live and Let Die", DurationSecs = 182, TrackGenres = new List<Genre> { rock }, Popularity = 4, AudioUrl = "" },
                                new Track { Title = "Don't Cry", DurationSecs = 290, TrackGenres = new List<Genre> {  rock }, Popularity = 2, AudioUrl = "" },
                                new Track { Title = "Perfect Crime", DurationSecs = 266, TrackGenres = new List<Genre> {  rock }, Popularity = 1, AudioUrl = "" },
                                new Track { Title = "Bad Obsession", DurationSecs = 300, TrackGenres = new List<Genre> { rock }, Popularity = 2, AudioUrl = "" },
                            }
                        },
                        
                    }
                },
             
            };

                return artists;
            }
    }
}
