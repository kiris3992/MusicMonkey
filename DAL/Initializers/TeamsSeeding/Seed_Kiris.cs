using Entities.Enums;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Initializers.TeamsSeeding
{
    public class Seed_Kiris : AbsTeamSeeder, ITeamSeeder
    {
        public List<Artist> GetArtists()
        {
            var artists = new List<Artist>
            {
                new Artist { // Nirvana
                    Name = "Nirvana", Country = Country.USA, CareerStartDate = new DateTime(1987, 12, 1), PhotoUrl = "", ArtistGenres = new List<Genre> { rock },
                    Albums = new List<Album> {
                        new Album {
                            Title = "Nevermind", ReleaseDate = new DateTime(1991, 9, 4), CoverPhotoUrl = "https://lastfm.freetls.fastly.net/i/u/ar0/570021b68d3d9d2db08bc99a473303b0.jpg",
                            Tracks = new List<Track> {
                                new Track { Title = "Smells Like Teen Spirit", DurationSecs = 301, TrackGenres = new List<Genre> { rock }, Popularity = 5, AudioUrl = "Nirvana_-_Nevermind_-_1_-_Smells_Like_Teen_Spirit_(Official_Music_Video)_(320kbps).mp3" },
                                new Track { Title = "In Bloom", DurationSecs = 255, TrackGenres = new List<Genre> { rock }, Popularity = 4, AudioUrl = "Nirvana_-_Nevermind_-_2_-_In_Bloom_(Official_Music_Video)_(320kbps).mp3" },
                                new Track { Title = "Come as You Are", DurationSecs = 219, TrackGenres = new List<Genre> { rock }, Popularity = 5, AudioUrl = "Nirvana_-_Nevermind_-_3_-_Come_As_You_Are_(Official_Music_Video)_(320kbps).mp3" },
                                new Track { Title = "Breed", DurationSecs = 184, TrackGenres = new List<Genre> { rock }, Popularity = 3, AudioUrl = "Nirvana_-_Nevermind_-_4_-_Breed_(Audio)_(320kbps).mp3" },
                                new Track { Title = "Lithium", DurationSecs = 257, TrackGenres = new List<Genre> { rock }, Popularity = 3, AudioUrl = "Nirvana_-_Nevermind_-_5_-_Lithium,_LP_Version_(Lithium,_Single)_(320kbps).mp3" },
                                new Track { Title = "Polly", DurationSecs = 177, TrackGenres = new List<Genre> { rock }, Popularity = 4, AudioUrl = "Nirvana_-_Nevermind_-_6_-_Polly_(Live_On_MTV_Unplugged,_1993___Unedited)_(320kbps).mp3" },
                                new Track { Title = "Territorial Pissings", DurationSecs = 143, TrackGenres = new List<Genre> { rock }, Popularity = 5, AudioUrl = "Nirvana_-_Nevermind_-_7_-_Territorial_Pissings_(Audio)_(320kbps).mp3" },
                                new Track { Title = "Drain You", DurationSecs = 224, TrackGenres = new List<Genre> { rock }, Popularity = 4, AudioUrl = "Nirvana_-_Nevermind_-_8_-_Drain_You_(Audio)_(320kbps).mp3" },
                                new Track { Title = "Lounge Act", DurationSecs = 157, TrackGenres = new List<Genre> { rock }, Popularity = 3, AudioUrl = "Nirvana_-_Nevermind_-_9_-_Lounge_Act_(Audio)_(320kbps).mp3" },
                                new Track { Title = "Stay Away", DurationSecs = 212, TrackGenres = new List<Genre> { rock }, Popularity = 3, AudioUrl = "Nirvana_-_Nevermind_-_10_-_Stay_Away_(Audio)_(320kbps).mp3" },
                                new Track { Title = "On a Plain", DurationSecs = 196, TrackGenres = new List<Genre> { rock }, Popularity = 4, AudioUrl = "Nirvana_-_Nevermind_-_11_-_On_A_Plain_(Live_On_MTV_Unplugged,_1993___Unedited)_(320kbps).mp3" },
                                new Track { Title = "Something in the Way", DurationSecs = 232, TrackGenres = new List<Genre> { rock }, Popularity = 5, AudioUrl = "Nirvana_-_Nevermind_-_12_-_Something_In_The_Way_(Audio)_(320kbps).mp3" },
                            }
                        }
                    }
                },
                new Artist { // Prodigy
                    Name = "Prodigy", Country = Country.United_Kingdom, CareerStartDate = new DateTime(1990, 1, 1), PhotoUrl = "", ArtistGenres = new List<Genre> { electronic, rock },
                    Albums = new List<Album> {
                        new Album {
                            Title = "The Fat of the Land", ReleaseDate = new DateTime(1997, 1, 1), CoverPhotoUrl = "https://upload.wikimedia.org/wikipedia/en/3/3b/TheProdigy-TheFatOfTheLand.jpg?20171231004557",
                            Tracks = new List<Track> {
                                new Track { Title = "Smack My Bitch Up", DurationSecs = 342, TrackGenres = new List<Genre> { electronic, rock }, Popularity = 5, AudioUrl = "Prodigy_-_The_Fat_of_the_Land_-_1_-_Smack_My_Bitch_Up_(320kbps).mp3" },
                                new Track { Title = "Breathe", DurationSecs = 239, TrackGenres = new List<Genre> { electronic, rock }, Popularity = 5, AudioUrl = "Prodigy_-_The_Fat_of_the_Land_-_2_-_Breathe_(Official_Video)_(320kbps).mp3" },
                                new Track { Title = "Diesel Power", DurationSecs = 257, TrackGenres = new List<Genre> { electronic, rock }, Popularity = 5, AudioUrl = "Prodigy_-_The_Fat_of_the_Land_-_3_-_Diesel_Power_(320kbps).mp3" },
                                new Track { Title = "Funky Shit", DurationSecs = 316, TrackGenres = new List<Genre> { electronic, rock }, Popularity = 2, AudioUrl = "Prodigy_-_The_Fat_of_the_Land_-_4_-_Funky_Shit_(320kbps).mp3" },
                                new Track { Title = "Serial Thrilla", DurationSecs = 311, TrackGenres = new List<Genre> { electronic, rock }, Popularity = 4, AudioUrl = "Prodigy_-_The_Fat_of_the_Land_-_5_-_Serial_Thrilla_(320kbps).mp3" },
                                new Track { Title = "Mindfields", DurationSecs = 404, TrackGenres = new List<Genre> { electronic, rock }, Popularity = 3, AudioUrl = "Prodigy_-_The_Fat_of_the_Land_-_6_-_Mindfields_(Live_in_Russia)_(320kbps).mp3" },
                                new Track { Title = "Narayan", DurationSecs = 393, TrackGenres = new List<Genre> { electronic, rock }, Popularity = 3, AudioUrl = "Prodigy_-_The_Fat_of_the_Land_-_7_-_Narayan_(320kbps).mp3" },
                                new Track { Title = "Firestarter", DurationSecs = 226, TrackGenres = new List<Genre> { electronic, rock }, Popularity = 5, AudioUrl = "Prodigy_-_The_Fat_of_the_Land_-_8_-_Firestarter_(Official_Video)_(320kbps).mp3" },
                                new Track { Title = "Climbatize", DurationSecs = 397, TrackGenres = new List<Genre> { electronic, rock }, Popularity = 3, AudioUrl = "Prodigy_-_The_Fat_of_the_Land_-_9_-_Climbatize_(320kbps).mp3" },
                                new Track { Title = "Fuel My Fire", DurationSecs = 258, TrackGenres = new List<Genre> { electronic, rock }, Popularity = 3, AudioUrl = "Prodigy_-_The_Fat_of_the_Land_-_10_-_Fuel_My_Fire_(320kbps).mp3" },
                            }
                        },
                        new Album {
                            Title = "The Added Fat EP", ReleaseDate = new DateTime (2012, 12, 3), CoverPhotoUrl = "https://is3-ssl.mzstatic.com/image/thumb/Music112/v4/06/a9/00/06a900da-0006-a3d3-8616-ceba0dd08b60/634904059064.png/1200x1200bf-60.jpg",
                            Tracks = new List<Track> {
                                new Track { Title = "Smack My Bitch Up (Noisia Remix)", DurationSecs = 354, TrackGenres = new List<Genre> { electronic, rock }, Popularity = 5, AudioUrl = "Audio_Url" },
                                new Track { Title = "Firestarter (Alvin Risk Remix)", DurationSecs = 199, TrackGenres = new List<Genre> { electronic, rock }, Popularity = 5, AudioUrl = "Audio_Url" },
                                new Track { Title = "Breathe (Zeds Dead Remix)", DurationSecs = 277, TrackGenres = new List<Genre> { electronic, rock }, Popularity = 5, AudioUrl = "Audio_Url" },
                                new Track { Title = "Mindfields (Baauer Remix)", DurationSecs = 232, TrackGenres = new List<Genre> { electronic, rock }, Popularity = 5, AudioUrl = "Audio_Url" },
                                new Track { Title = "Breathe (The Glitch Mob Remix)", DurationSecs = 266, TrackGenres = new List<Genre> { electronic, rock }, Popularity = 5, AudioUrl = "Audio_Url" },
                                new Track { Title = "Smack My Bitch Up (Major Lazer Remix)", DurationSecs = 306, TrackGenres = new List<Genre> { electronic, rock }, Popularity = 5, AudioUrl = "Audio_Url" },
                            }
                        },
                        new Album {
                            Title = "Music for the Jilted Generation", ReleaseDate = new DateTime(1994, 7, 1), CoverPhotoUrl = "https://upload.wikimedia.org/wikipedia/en/8/86/TheProdigy-MusicForTheJiltedGeneration.jpg",
                            Tracks = new List<Track> {
                                new Track { Title = "Intro", DurationSecs = 46, TrackGenres = new List<Genre> { electronic, rock }, Popularity = 3, AudioUrl = "Audio_Url" },
                                new Track { Title = "Break & Enter", DurationSecs = 504, TrackGenres = new List<Genre> { electronic, rock }, Popularity = 4, AudioUrl = "Audio_Url" },
                                new Track { Title = "Their Law", DurationSecs = 401, TrackGenres = new List<Genre> { electronic, rock }, Popularity = 5, AudioUrl = "Audio_Url" },
                                new Track { Title = "Full Throttle", DurationSecs = 303, TrackGenres = new List<Genre> { electronic, rock }, Popularity = 5, AudioUrl = "Audio_Url" },
                                new Track { Title = "Voodoo People", DurationSecs = 387, TrackGenres = new List<Genre> { electronic, rock }, Popularity = 5, AudioUrl = "Audio_Url" },
                                new Track { Title = "Speedway", DurationSecs = 536, TrackGenres = new List<Genre> { electronic, rock }, Popularity = 3, AudioUrl = "Audio_Url" },
                                new Track { Title = "The Heat (The Energy)", DurationSecs = 268, TrackGenres = new List<Genre> { electronic, rock }, Popularity = 4, AudioUrl = "Audio_Url" },
                                new Track { Title = "Poison", DurationSecs = 402, TrackGenres = new List<Genre> { electronic, rock }, Popularity = 5, AudioUrl = "Audio_Url" },
                                new Track { Title = "No Good (Start the Dance)", DurationSecs = 379, TrackGenres = new List<Genre> { electronic, rock }, Popularity = 5, AudioUrl = "Audio_Url" },
                                new Track { Title = "One Love", DurationSecs = 233, TrackGenres = new List<Genre> { electronic, rock }, Popularity = 2, AudioUrl = "Audio_Url" },
                                new Track { Title = "The Narcotic Suite (3 Kilos)", DurationSecs = 446, TrackGenres = new List<Genre> { electronic, rock }, Popularity = 3, AudioUrl = "Audio_Url" },
                                new Track { Title = "The Narcotic Suite (Skylined)", DurationSecs = 358, TrackGenres = new List<Genre> { electronic, rock }, Popularity = 4, AudioUrl = "Audio_Url" },
                                new Track { Title = "The Narcotic Suite (Claustrophobic Sting)", DurationSecs = 432, TrackGenres = new List<Genre> { electronic, rock }, Popularity = 5, AudioUrl = "Audio_Url" },
                            }
                        }
                    }
                },
                new Artist { // Τρύπες
                    Name = "Τρύπες", Country = Country.Greece, CareerStartDate = new DateTime (1983, 1, 1), PhotoUrl = "https://upload.wikimedia.org/wikipedia/el/thumb/a/aa/Tripes1.jpg/230px-Tripes1.jpg", ArtistGenres = new List<Genre> { rock },
                    Albums = new List<Album> {
                        new Album {
                            Title = "Εννιά πληρωμένα τραγούδια", ReleaseDate = new DateTime (1993, 3, 1), CoverPhotoUrl = "https://upload.wikimedia.org/wikipedia/el/thumb/1/1f/Trypes_ennia_plhrwmena_tragoudia.jpg/1200px-Trypes_ennia_plhrwmena_tragoudia.jpg",
                            Tracks = new List<Track> {
                                new Track { Title = "Δε χωράς πουθενά", DurationSecs = 266, TrackGenres = new List<Genre> { rock }, Popularity = 5, AudioUrl = "Audio_Url" },
                                new Track { Title = "Η μάσκα που κρύβεις", DurationSecs = 213, TrackGenres = new List<Genre> { rock }, Popularity = 5, AudioUrl = "Audio_Url" },
                                new Track { Title = "Το τρένο", DurationSecs = 294, TrackGenres = new List<Genre> { rock }, Popularity = 4, AudioUrl = "Audio_Url" },
                                new Track { Title = "Θυμάμαι ένα σπίτι", DurationSecs = 196, TrackGenres = new List<Genre> { rock }, Popularity = 4, AudioUrl = "Audio_Url" },
                                new Track { Title = "Αμνησία", DurationSecs = 215, TrackGenres = new List<Genre> { rock }, Popularity = 5, AudioUrl = "Audio_Url" },
                                new Track { Title = "Όλες οι απαντήσεις", DurationSecs = 202, TrackGenres = new List<Genre> { rock }, Popularity = 2, AudioUrl = "Audio_Url" },
                                new Track { Title = "Από μια άδεια καρδιά", DurationSecs = 296, TrackGenres = new List<Genre> { rock }, Popularity = 4, AudioUrl = "Audio_Url" },
                                new Track { Title = "Λα λα λα λα", DurationSecs = 187, TrackGenres = new List<Genre> { rock }, Popularity = 4, AudioUrl = "Audio_Url" },
                                new Track { Title = "Ένα πληρωμένο τραγούδι", DurationSecs = 202, TrackGenres = new List<Genre> { rock }, Popularity = 5, AudioUrl = "Audio_Url" },
                                new Track { Title = "Τσιφτετέλι", DurationSecs = 256, TrackGenres = new List<Genre> { rock }, Popularity = 1, AudioUrl = "Audio_Url" },
                            }
                        }
                    }
                },
            };

            return artists;
        }
    }
}
