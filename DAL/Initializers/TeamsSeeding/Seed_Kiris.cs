using Entities.Enums;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Initializers.TeamsSeeding
{
    public class Seed_Kiris : ITeamSeeder
    {
        public List<Artist> GetArtists(TeamGenres g)
        {
            return new List<Artist>
            {
                new Artist { // Nirvana
                    Name = "Nirvana", Country = Country.USA, CareerStartDate = new DateTime(1987, 12, 1), ArtistGenres = { g.grunge, g.alternativeRock, g.punkRock }, PhotoUrl = "/Content/Assets/entity-files/Nirvana/artist_cover.jpg",
                    Albums = new List<Album> {
                        new Album {
                            Title = "Nevermind", ReleaseDate = new DateTime(1991, 9, 4), AlbumGenres = { g.grunge, g.electroPunk }, CoverPhotoUrl = "/Content/Assets/entity-files/Nirvana/Nevermind/album_cover.jpg",
                            Tracks = new List<Track> {
                                new Track { Title = "Smells Like Teen Spirit", DurationSecs = 301, TrackGenres = { g.grunge, g.electroPunk }, Popularity = 5, AudioUrl = "/Content/Assets/entity-files/Nirvana/Nevermind/1.mp3" },
                                new Track { Title = "Come as You Are", DurationSecs = 219, TrackGenres = { g.grunge, g.electroPunk }, Popularity = 5, AudioUrl = "/Content/Assets/entity-files/Nirvana/Nevermind/3.mp3" },
                                new Track { Title = "In Bloom", DurationSecs = 255, TrackGenres = { g.grunge, g.electroPunk }, Popularity = 4, AudioUrl = "/Content/Assets/entity-files/Nirvana/Nevermind/2.mp3" },
                                new Track { Title = "Breed", DurationSecs = 184, TrackGenres = { g.grunge, g.electroPunk }, Popularity = 3, AudioUrl = "/Content/Assets/entity-files/Nirvana/Nevermind/4.mp3" },
                                new Track { Title = "Lithium", DurationSecs = 257, TrackGenres = { g.grunge, g.electroPunk }, Popularity = 3, AudioUrl = "/Content/Assets/entity-files/Nirvana/Nevermind/5.mp3" },
                                new Track { Title = "Polly", DurationSecs = 177, TrackGenres = { g.grunge, g.electroPunk }, Popularity = 4, AudioUrl = "/Content/Assets/entity-files/Nirvana/Nevermind/6.mp3" },
                                new Track { Title = "Territorial Pissings", DurationSecs = 143, TrackGenres = { g.grunge, g.electroPunk }, Popularity = 5, AudioUrl = "/Content/Assets/entity-files/Nirvana/Nevermind/7.mp3" },
                                new Track { Title = "Drain You", DurationSecs = 224, TrackGenres = { g.grunge, g.electroPunk }, Popularity = 4, AudioUrl = "/Content/Assets/entity-files/Nirvana/Nevermind/8.mp3" },
                                new Track { Title = "Lounge Act", DurationSecs = 157, TrackGenres = { g.grunge, g.electroPunk }, Popularity = 3, AudioUrl = "/Content/Assets/entity-files/Nirvana/Nevermind/9.mp3" },
                                new Track { Title = "Stay Away", DurationSecs = 212, TrackGenres = { g.grunge, g.electroPunk }, Popularity = 3, AudioUrl = "/Content/Assets/entity-files/Nirvana/Nevermind/10.mp3" },
                                new Track { Title = "On a Plain", DurationSecs = 196, TrackGenres = { g.grunge, g.electroPunk }, Popularity = 4, AudioUrl = "/Content/Assets/entity-files/Nirvana/Nevermind/11.mp3" },
                                new Track { Title = "Something in the Way", DurationSecs = 232, TrackGenres = { g.grunge, g.electroPunk }, Popularity = 5, AudioUrl = "/Content/Assets/entity-files/Nirvana/Nevermind/12.mp3" },
                            }
                        }
                    }
                },
                new Artist { // Prodigy
                    Name = "Prodigy", Country = Country.United_Kingdom, CareerStartDate = new DateTime(1990, 1, 1), ArtistGenres = { g.bigBeat, g.electroPunk, g.electronicRock }, PhotoUrl = "/Content/Assets/entity-files/Prodigy/artist_cover.jpg",
                    Albums = new List<Album> {
                        new Album {
                            Title = "The Fat of the Land", ReleaseDate = new DateTime(1997, 1, 1), AlbumGenres = { g.electroPunk, g.electronicRock }, CoverPhotoUrl = "/Content/Assets/entity-files/Prodigy/The_Fat_of_the_Land/album_cover.jpg",
                            Tracks = new List<Track> {
                                new Track { Title = "Smack My Bitch Up", DurationSecs = 342, TrackGenres = { g.electroPunk, g.electronicRock }, Popularity = 5, AudioUrl = "/Content/Assets/entity-files/Prodigy/The_Fat_of_the_Land/1.mp3" },
                                new Track { Title = "Breathe", DurationSecs = 239, TrackGenres = { g.electroPunk, g.electronicRock }, Popularity = 5, AudioUrl = "/Content/Assets/entity-files/Prodigy/The_Fat_of_the_Land/2.mp3" },
                                new Track { Title = "Diesel Power", DurationSecs = 257, TrackGenres = { g.electroPunk, g.electronicRock }, Popularity = 5, AudioUrl = "/Content/Assets/entity-files/Prodigy/The_Fat_of_the_Land/3.mp3" },
                                new Track { Title = "Funky Shit", DurationSecs = 316, TrackGenres = { g.electroPunk, g.electronicRock }, Popularity = 2, AudioUrl = "/Content/Assets/entity-files/Prodigy/The_Fat_of_the_Land/4.mp3" },
                                new Track { Title = "Serial Thrilla", DurationSecs = 311, TrackGenres = { g.electroPunk, g.electronicRock }, Popularity = 4, AudioUrl = "/Content/Assets/entity-files/Prodigy/The_Fat_of_the_Land/5.mp3" },
                                new Track { Title = "Mindfields", DurationSecs = 404, TrackGenres = { g.electroPunk, g.electronicRock }, Popularity = 3, AudioUrl = "/Content/Assets/entity-files/Prodigy/The_Fat_of_the_Land/6.mp3" },
                                new Track { Title = "Narayan", DurationSecs = 393, TrackGenres = { g.electroPunk, g.electronicRock }, Popularity = 3, AudioUrl = "/Content/Assets/entity-files/Prodigy/The_Fat_of_the_Land/7.mp3" },
                                new Track { Title = "Firestarter", DurationSecs = 226, TrackGenres = { g.electroPunk, g.electronicRock }, Popularity = 5, AudioUrl = "/Content/Assets/entity-files/Prodigy/The_Fat_of_the_Land/8.mp3" },
                                new Track { Title = "Climbatize", DurationSecs = 397, TrackGenres = { g.electroPunk, g.electronicRock }, Popularity = 3, AudioUrl = "/Content/Assets/entity-files/Prodigy/The_Fat_of_the_Land/9.mp3" },
                                new Track { Title = "Fuel My Fire", DurationSecs = 258, TrackGenres = { g.electroPunk, g.electronicRock }, Popularity = 3, AudioUrl = "/Content/Assets/entity-files/Prodigy/The_Fat_of_the_Land/10.mp3" },
                            }
                        },
                        new Album {
                            Title = "The Added Fat EP", ReleaseDate = new DateTime (2012, 12, 3), AlbumGenres = { g.bigBeat, g.electroPunk, g.electronicRock }, CoverPhotoUrl = "/Content/Assets/entity-files/Prodigy/The_Added_Fat_EP/cover.jpg",
                            Tracks = new List<Track> {
                                new Track { Title = "Smack My Bitch Up (Noisia Remix)", DurationSecs = 354, TrackGenres = { g.bigBeat, g.electroPunk, g.electronicRock }, Popularity = 5, AudioUrl = "/Content/Assets/entity-files/Prodigy/The_Added_Fat_EP/1.mp3" },
                                new Track { Title = "Firestarter (Alvin Risk Remix)", DurationSecs = 199, TrackGenres = { g.bigBeat, g.electroPunk, g.electronicRock }, Popularity = 5, AudioUrl = "/Content/Assets/entity-files/Prodigy/The_Added_Fat_EP/2.mp3" },
                                new Track { Title = "Breathe (Zeds Dead Remix)", DurationSecs = 277, TrackGenres = { g.bigBeat, g.electroPunk, g.electronicRock }, Popularity = 5, AudioUrl = "/Content/Assets/entity-files/Prodigy/The_Added_Fat_EP/3.mp3" },
                                new Track { Title = "Mindfields (Baauer Remix)", DurationSecs = 232, TrackGenres = { g.bigBeat, g.electroPunk, g.electronicRock }, Popularity = 5, AudioUrl = "/Content/Assets/entity-files/Prodigy/The_Added_Fat_EP/4.mp3" },
                                new Track { Title = "Breathe (The Glitch Mob Remix)", DurationSecs = 266, TrackGenres = { g.bigBeat, g.electroPunk, g.electronicRock }, Popularity = 5, AudioUrl = "/Content/Assets/entity-files/Prodigy/The_Added_Fat_EP/5.mp3" },
                                new Track { Title = "Smack My Bitch Up (Major Lazer Remix)", DurationSecs = 306, TrackGenres = { g.bigBeat, g.electroPunk, g.electronicRock }, Popularity = 5, AudioUrl = "/Content/Assets/entity-files/Prodigy/The_Added_Fat_EP/6.mp3" },
                            }
                        },
                        new Album {
                            Title = "Music for the Jilted Generation", ReleaseDate = new DateTime(1994, 7, 1), AlbumGenres = { g.electroPunk, g.electronicRock }, CoverPhotoUrl = "/Content/Assets/entity-files/Prodigy/Music_for_the_Jilted_Generation/cover.jpg",
                            Tracks = new List<Track> {
                                new Track { Title = "Intro", DurationSecs = 46, TrackGenres = { g.electroPunk, g.electronicRock }, Popularity = 3, AudioUrl = "/Content/Assets/entity-files/Prodigy/Music_for_the_Jilted_Generation/1.mp3" },
                                new Track { Title = "Break & Enter", DurationSecs = 504, TrackGenres = { g.electroPunk, g.electronicRock }, Popularity = 4, AudioUrl = "/Content/Assets/entity-files/Prodigy/Music_for_the_Jilted_Generation/2.mp3" },
                                new Track { Title = "Their Law", DurationSecs = 401, TrackGenres = { g.electroPunk, g.electronicRock }, Popularity = 5, AudioUrl = "/Content/Assets/entity-files/Prodigy/Music_for_the_Jilted_Generation/3.mp3" },
                                new Track { Title = "Full Throttle", DurationSecs = 303, TrackGenres = { g.electroPunk, g.electronicRock }, Popularity = 5, AudioUrl = "/Content/Assets/entity-files/Prodigy/Music_for_the_Jilted_Generation/4.mp3" },
                                new Track { Title = "Voodoo People", DurationSecs = 387, TrackGenres = { g.electroPunk, g.electronicRock }, Popularity = 5, AudioUrl = "/Content/Assets/entity-files/Prodigy/Music_for_the_Jilted_Generation/5.mp3" },
                                new Track { Title = "Speedway", DurationSecs = 536, TrackGenres = { g.electroPunk, g.electronicRock }, Popularity = 3, AudioUrl = "/Content/Assets/entity-files/Prodigy/Music_for_the_Jilted_Generation/6.mp3" },
                                new Track { Title = "The Heat (The Energy)", DurationSecs = 268, TrackGenres = { g.electroPunk, g.electronicRock }, Popularity = 4, AudioUrl = "/Content/Assets/entity-files/Prodigy/Music_for_the_Jilted_Generation/7.mp3" },
                                new Track { Title = "Poison", DurationSecs = 402, TrackGenres = { g.electroPunk, g.electronicRock }, Popularity = 5, AudioUrl = "/Content/Assets/entity-files/Prodigy/Music_for_the_Jilted_Generation/8.mp3" },
                                new Track { Title = "No Good (Start the Dance)", DurationSecs = 379, TrackGenres = { g.electroPunk, g.electronicRock }, Popularity = 5, AudioUrl = "/Content/Assets/entity-files/Prodigy/Music_for_the_Jilted_Generation/9.mp3" },
                                new Track { Title = "One Love", DurationSecs = 233, TrackGenres = { g.electroPunk, g.electronicRock }, Popularity = 2, AudioUrl = "/Content/Assets/entity-files/Prodigy/Music_for_the_Jilted_Generation/10.mp3" },
                                new Track { Title = "The Narcotic Suite (3 Kilos)", DurationSecs = 446, TrackGenres = { g.electroPunk, g.electronicRock }, Popularity = 3, AudioUrl = "/Content/Assets/entity-files/Prodigy/Music_for_the_Jilted_Generation/11.mp3" },
                                new Track { Title = "The Narcotic Suite (Skylined)", DurationSecs = 358, TrackGenres = { g.electroPunk, g.electronicRock }, Popularity = 4, AudioUrl = "/Content/Assets/entity-files/Prodigy/Music_for_the_Jilted_Generation/12.mp3" },
                                new Track { Title = "The Narcotic Suite (Claustrophobic Sting)", DurationSecs = 432, TrackGenres = { g.electroPunk, g.electronicRock }, Popularity = 5, AudioUrl = "/Content/Assets/entity-files/Prodigy/Music_for_the_Jilted_Generation/13.mp3" },
                            }
                        }
                    }
                },
                new Artist { // Τρύπες
                    Name = "Τρύπες", Country = Country.Greece, CareerStartDate = new DateTime (1983, 1, 1), ArtistGenres = { g.rock }, PhotoUrl = "/Content/Assets/entity-files/Trypes/cover.jpg",
                    Albums = new List<Album> {
                        new Album {
                            Title = "Εννιά πληρωμένα τραγούδια", ReleaseDate = new DateTime (1993, 3, 1), AlbumGenres = { g.rock }, CoverPhotoUrl = "/Content/Assets/entity-files/Trypes/Ennia_Pliromena_Tragoudia/cover.jpg",
                            Tracks = new List<Track> {
                                new Track { Title = "Δε χωράς πουθενά", DurationSecs = 266, TrackGenres = { g.rock }, Popularity = 5, AudioUrl = "/Content/Assets/entity-files/Trypes/Ennia_Pliromena_Tragoudia/1.mp3" },
                                new Track { Title = "Η μάσκα που κρύβεις", DurationSecs = 213, TrackGenres = { g.rock }, Popularity = 5, AudioUrl = "/Content/Assets/entity-files/Trypes/Ennia_Pliromena_Tragoudia/2.mp3" },
                                new Track { Title = "Το τρένο", DurationSecs = 294, TrackGenres = { g.rock }, Popularity = 4, AudioUrl = "/Content/Assets/entity-files/Trypes/Ennia_Pliromena_Tragoudia/3.mp3" },
                                new Track { Title = "Θυμάμαι ένα σπίτι", DurationSecs = 196, TrackGenres = { g.rock }, Popularity = 4, AudioUrl = "/Content/Assets/entity-files/Trypes/Ennia_Pliromena_Tragoudia/4.mp3" },
                                new Track { Title = "Αμνησία", DurationSecs = 215, TrackGenres = { g.rock }, Popularity = 5, AudioUrl = "/Content/Assets/entity-files/Trypes/Ennia_Pliromena_Tragoudia/5.mp3" },
                                new Track { Title = "Όλες οι απαντήσεις", DurationSecs = 202, TrackGenres = { g.rock }, Popularity = 2, AudioUrl = "/Content/Assets/entity-files/Trypes/Ennia_Pliromena_Tragoudia/6.mp3" },
                                new Track { Title = "Από μια άδεια καρδιά", DurationSecs = 296, TrackGenres = { g.rock }, Popularity = 4, AudioUrl = "/Content/Assets/entity-files/Trypes/Ennia_Pliromena_Tragoudia/7.mp3" },
                                new Track { Title = "Λα λα λα λα", DurationSecs = 187, TrackGenres = { g.rock }, Popularity = 4, AudioUrl = "/Content/Assets/entity-files/Trypes/Ennia_Pliromena_Tragoudia/8.mp3" },
                                new Track { Title = "Ένα πληρωμένο τραγούδι", DurationSecs = 202, TrackGenres = { g.rock }, Popularity = 5, AudioUrl = "/Content/Assets/entity-files/Trypes/Ennia_Pliromena_Tragoudia/9.mp3" },
                                new Track { Title = "Τσιφτετέλι", DurationSecs = 256, TrackGenres = { g.rock }, Popularity = 1, AudioUrl = "/Content/Assets/entity-files/Trypes/Ennia_Pliromena_Tragoudia/10.mp3" },
                            }
                        }
                    }
                },
            };
        }
    }
}
