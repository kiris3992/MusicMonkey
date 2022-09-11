using Entities.Enums;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Initializers.TeamsSeeding
{
    public class Seed_Panos : ITeamSeeder
    {
        public List<Artist> GetArtists(TeamGenres g)
        {
            #region Panos Seeding
            #region Bob Dylan
            Artist pa1 = new Artist("Bob Dylan", Country.USA, "photo", new DateTime(1959, 1, 1), new HashSet<Genre> { g.folk, g.blues });

            Album pa1album1 = new Album("Bringing It All Back Home", new DateTime(1965, 3, 22), "photo", pa1, new HashSet<Genre>() { g.folk, g.blues });
            Album pa1album2 = new Album("Planet Waves", new DateTime(1974, 1, 17), "photo", pa1, new HashSet<Genre>() { g.folk, g.rock, g.blues });
            Album pa1album3 = new Album("Dylan & the Dead", new DateTime(1989, 2, 6), "photo", pa1, new HashSet<Genre>() { g.folk, g.rock });

            Track pa1al1t1 = new Track("Mr. Tambourine Man", 320, "audio", pa1album1, new HashSet<Genre>() { g.folk }, 4);
            Track pa1al1t2 = new Track("Gates of Eden", 324, "audio", pa1album1, new HashSet<Genre>() { g.folk, g.blues }, 2);
            Track pa1al1t3 = new Track("It's Alright, Ma (I'm Only Bleeding)", 437, "audio", pa1album1, new HashSet<Genre>() { g.folk }, 3);
            Track pa1al1t4 = new Track("It's All Over Now, Baby Blue", 248, "audio", pa1album1, new HashSet<Genre>() { g.folk, g.country }, 3);

            pa1album1.Tracks.Add(pa1al1t1);
            pa1album1.Tracks.Add(pa1al1t2);
            pa1album1.Tracks.Add(pa1al1t3);
            pa1album1.Tracks.Add(pa1al1t4);
            pa1.Albums.Add(pa1album1);

            Track pa1al2t1 = new Track("On a Night Like This", 154, "audio", pa1album2, new HashSet<Genre>() { g.folk }, 4);
            Track pa1al2t2 = new Track("Going, Going, Gone", 196, "audio", pa1album2, new HashSet<Genre>() { g.folk }, 2);
            Track pa1al2t3 = new Track("Tough Mama", 250, "audio", pa1album2, new HashSet<Genre>() { g.folk }, 1);
            Track pa1al2t4 = new Track("Hazel", 149, "audio", pa1album2, new HashSet<Genre>() { g.folk }, 4);
            Track pa1al2t5 = new Track("Something There Is About You", 267, "audio", pa1album2, new HashSet<Genre>() { g.folk }, 3);
            Track pa1al2t6 = new Track("Forever Young", 280, "audio", pa1album2, new HashSet<Genre>() { g.folk, g.rock }, 2);

            pa1album2.Tracks.Add(pa1al2t1);
            pa1album2.Tracks.Add(pa1al2t2);
            pa1album2.Tracks.Add(pa1al2t3);
            pa1album2.Tracks.Add(pa1al2t4);
            pa1album2.Tracks.Add(pa1al2t5);
            pa1album2.Tracks.Add(pa1al2t6);

            pa1.Albums.Add(pa1album2);

            Track pa1al3t1 = new Track("Slow Train", 272, "audio", pa1album3, new HashSet<Genre>() { g.folk, g.blues }, 1);
            Track pa1al3t2 = new Track("I Want You", 240, "audio", pa1album3, new HashSet<Genre>() { g.folk, g.blues }, 2);
            Track pa1al3t3 = new Track("Gotta Serve Somebody", 325, "audio", pa1album3, new HashSet<Genre>() { g.folk, g.blues }, 4);
            Track pa1al3t4 = new Track("Queen Jane Approximately", 378, "audio", pa1album3, new HashSet<Genre>() { g.folk, g.blues }, 2);
            Track pa1al3t5 = new Track("Joey", 546, "audio", pa1album3, new HashSet<Genre>() { g.folk, g.blues }, 3);
            Track pa1al3t6 = new Track("All Along the Watchtower", 352, "audio", pa1album3, new HashSet<Genre>() { g.folk }, 3);
            Track pa1al3t7 = new Track("Knockin' on Heaven's Door", 401, "audio", pa1album3, new HashSet<Genre>() { g.folk, g.rock }, 5);

            pa1album3.Tracks.Add(pa1al3t1);
            pa1album3.Tracks.Add(pa1al3t2);
            pa1album3.Tracks.Add(pa1al3t3);
            pa1album3.Tracks.Add(pa1al3t4);
            pa1album3.Tracks.Add(pa1al3t5);
            pa1album3.Tracks.Add(pa1al3t6);
            pa1album3.Tracks.Add(pa1al3t7);

            pa1.Albums.Add(pa1album3);
            #endregion

            #region Beethoven

            Artist pa2 = new Artist("Ludwig van Beethoven", Country.Germany, "photo", new DateTime(1790, 1, 1), new HashSet<Genre> { g.classical });

            Album pa2album = new Album("Beethoven Symfonies", new DateTime(1795, 1, 1), "photo", pa2, new HashSet<Genre>() { g.classical });

            Track pa2t1 = new Track("Symphony No.1, C", 1669, "audio", pa2album, new HashSet<Genre> { g.classical }, 2);
            Track pa2t2 = new Track("Symphony No.2,D", 1809, "audio", pa2album, new HashSet<Genre> { g.classical }, 1);
            Track pa2t3 = new Track("Symphony No.3 (Eroica), Eb", 3336, "audio", pa2album, new HashSet<Genre>() { g.classical }, 1);
            Track pa2t4 = new Track("Symphony No.4, Bb", 2247, "audio", pa2album, new HashSet<Genre>() { g.classical }, 2);
            Track pa2t5 = new Track("Symphony No.5, C minor", 2012, "audio", pa2album, new HashSet<Genre>() { g.classical }, 3);
            Track pa2t6 = new Track("Symphony No.6 (Pastoral), F", 2523, "audio", pa2album, new HashSet<Genre>() { g.classical }, 1);
            Track pa2t7 = new Track("Symphony No.7, A", 1983, "audio", pa2album, new HashSet<Genre>() { g.classical }, 3);
            Track pa2t8 = new Track("Symphony No.8, F ", 2340, "audio", pa2album, new HashSet<Genre>() { g.classical }, 4);
            Track pa2t9 = new Track("Symphony No.9 (Choral), D minor", 3939, "audio", pa2album, new HashSet<Genre>() { g.classical }, 5);

            pa2album.Tracks.Add(pa2t1);
            pa2album.Tracks.Add(pa2t2);
            pa2album.Tracks.Add(pa2t3);
            pa2album.Tracks.Add(pa2t4);
            pa2album.Tracks.Add(pa2t5);
            pa2album.Tracks.Add(pa2t6);
            pa2album.Tracks.Add(pa2t7);
            pa2album.Tracks.Add(pa2t8);
            pa2album.Tracks.Add(pa2t9);
            pa2.Albums.Add(pa2album);

            #endregion

            #region Lady Gaga
            Artist pa3 = new Artist("Lady Gaga", Country.USA, "photo", new DateTime(2007, 1, 1), new HashSet<Genre> { g.pop });

            Album pa3album1 = new Album("The Fame", new DateTime(2008, 08, 19), "photo", pa3, new HashSet<Genre>() { g.pop });
            Album pa3album2 = new Album("Born this way", new DateTime(2011, 05, 23), "photo", pa3, new HashSet<Genre>() { g.pop });
            Album pa3album3 = new Album("Joanne", new DateTime(2016, 10, 21), "photo", pa3, new HashSet<Genre>() { g.pop, g.rock, g.country });

            Track pa3al1t1 = new Track("Just Dance", 242, "audio", pa3album1, new HashSet<Genre>() { g.pop }, 4);
            Track pa3al1t2 = new Track("LoveGame", 216, "audio", pa3album1, new HashSet<Genre>() { g.pop }, 3);
            Track pa3al1t3 = new Track("Paparazzi", 208, "audio", pa3album1, new HashSet<Genre>() { g.pop }, 3);
            Track pa3al1t4 = new Track("Poker Face", 238, "audio", pa3album1, new HashSet<Genre>() { g.pop }, 5);
            Track pa3al1t5 = new Track("Eh, Eh (Nothing Else I Can Say)", 175, "audio", pa3album1, new HashSet<Genre>() { g.pop }, 1);
            Track pa3al1t6 = new Track("Beautiful, Dirty, Rich", 220, "audio", pa3album1, new HashSet<Genre>() { g.pop }, 2);
            Track pa3al1t7 = new Track("The Fame", 222, "audio", pa3album1, new HashSet<Genre>() { g.pop }, 3);
            Track pa3al1t8 = new Track("Money Honey", 170, "audio", pa3album1, new HashSet<Genre>() { g.pop }, 2);
            Track pa3al1t9 = new Track("Starstruck", 217, "audio", pa3album1, new HashSet<Genre>() { g.pop }, 1);

            pa3album1.Tracks.Add(pa3al1t1);
            pa3album1.Tracks.Add(pa3al1t2);
            pa3album1.Tracks.Add(pa3al1t3);
            pa3album1.Tracks.Add(pa3al1t4);
            pa3album1.Tracks.Add(pa3al1t5);
            pa3album1.Tracks.Add(pa3al1t6);
            pa3album1.Tracks.Add(pa3al1t7);
            pa3album1.Tracks.Add(pa3al1t8);
            pa3album1.Tracks.Add(pa3al1t9);

            pa3.Albums.Add(pa3album1);

            Track pa3al2t1 = new Track("Marry the night", 245, "audio", pa3album2, new HashSet<Genre>() { g.pop }, 3);
            Track pa3al2t2 = new Track("Born this way", 240, "audio", pa3album2, new HashSet<Genre>() { g.pop }, 5);
            Track pa3al2t3 = new Track("Government Hooker", 254, "audio", pa3album2, new HashSet<Genre>() { g.pop }, 1);
            Track pa3al2t4 = new Track("Judas", 249, "audio", pa3album2, new HashSet<Genre>() { g.pop }, 4);
            Track pa3al2t5 = new Track("Americano", 247, "audio", pa3album2, new HashSet<Genre>() { g.pop }, 2);
            Track pa3al2t6 = new Track("Hair", 308, "audio", pa3album2, new HashSet<Genre>() { g.pop }, 1);
            Track pa3al2t7 = new Track("Edge of Glory", 321, "audio", pa3album2, new HashSet<Genre>() { g.pop }, 4);

            pa3album2.Tracks.Add(pa3al2t1);
            pa3album2.Tracks.Add(pa3al2t2);
            pa3album2.Tracks.Add(pa3al2t3);
            pa3album2.Tracks.Add(pa3al2t4);
            pa3album2.Tracks.Add(pa3al2t5);
            pa3album2.Tracks.Add(pa3al2t6);
            pa3album2.Tracks.Add(pa3al2t7);

            pa3.Albums.Add(pa3album2);

            Track pa3al3t1 = new Track("Diamont Heart", 210, "audio", pa3album3, new HashSet<Genre>() { g.pop, g.blues }, 2);
            Track pa3al3t2 = new Track("A-Yo", 208, "audio", pa3album3, new HashSet<Genre>() { g.pop }, 1);
            Track pa3al3t3 = new Track("Joanne", 197, "audio", pa3album3, new HashSet<Genre>() { g.pop, g.country }, 2);
            Track pa3al3t4 = new Track("John Wayne", 174, "audio", pa3album3, new HashSet<Genre>() { g.pop, g.rock }, 3);
            Track pa3al3t5 = new Track("Dancin’ In Circles", 207, "audio", pa3album3, new HashSet<Genre>() { g.pop }, 2);
            Track pa3al3t6 = new Track("Perfect Illusion", 182, "audio", pa3album3, new HashSet<Genre>() { g.pop, g.country }, 4);
            Track pa3al3t7 = new Track("Million Reasons", 205, "audio", pa3album3, new HashSet<Genre>() { g.pop, g.blues }, 4);

            pa3album3.Tracks.Add(pa3al3t1);
            pa3album3.Tracks.Add(pa3al3t2);
            pa3album3.Tracks.Add(pa3al3t3);
            pa3album3.Tracks.Add(pa3al3t4);
            pa3album3.Tracks.Add(pa3al3t5);
            pa3album3.Tracks.Add(pa3al3t6);
            pa3album3.Tracks.Add(pa3al3t7);

            pa3.Albums.Add(pa3album3);

            #endregion

            #region The Wiggles

            Artist pa4 = new Artist("The Wiggles", Country.Australia, "photo", new DateTime(1991, 1, 1), new HashSet<Genre> { g.kid });

            Album pa4album1 = new Album("The Wiggles", new DateTime(1991, 08, 1), "photo", pa4, new HashSet<Genre>() { g.kid });
            Album pa4album2 = new Album("Big Red Car", new DateTime(1995, 1, 1), "photo", pa4, new HashSet<Genre>() { g.kid });
            Album pa4album3 = new Album("Serfer Jeff", new DateTime(2012, 5, 3), "photo", pa4, new HashSet<Genre>() { g.kid });

            Track pa4al1t1 = new Track("Get Ready to Wiggle", 117, "audio", pa4album1, new HashSet<Genre>() { g.kid }, 4);
            Track pa4al1t2 = new Track("Lavender's Blue", 92, "audio", pa4album1, new HashSet<Genre>() { g.kid }, 3);
            Track pa4al1t3 = new Track("Rock-a-Bye Your Bear", 106, "audio", pa4album1, new HashSet<Genre>() { g.kid }, 2);
            Track pa4al1t4 = new Track("Dorothy the Dinosaur", 143, "audio", pa4album1, new HashSet<Genre>() { g.kid }, 1);
            Track pa4al1t5 = new Track("Mischief the Monkey", 44, "audio", pa4album1, new HashSet<Genre>() { g.kid }, 1);
            Track pa4al1t6 = new Track("Glub Glub Train", 19, "audio", pa4album1, new HashSet<Genre>() { g.kid }, 2);

            pa4album1.Tracks.Add(pa4al1t1);
            pa4album1.Tracks.Add(pa4al1t2);
            pa4album1.Tracks.Add(pa4al1t3);
            pa4album1.Tracks.Add(pa4al1t4);
            pa4album1.Tracks.Add(pa4al1t5);
            pa4album1.Tracks.Add(pa4al1t6);
            pa4.Albums.Add(pa4album1);

            Track pa4al2t1 = new Track("Wags the Dog", 162, "audio", pa4album2, new HashSet<Genre>() { g.kid }, 2);
            Track pa4al2t2 = new Track("Henry's Dance", 111, "audio", pa4album2, new HashSet<Genre>() { g.kid }, 1);
            Track pa4al2t3 = new Track("Five Little Joeys", 108, "audio", pa4album2, new HashSet<Genre>() { g.kid }, 3);
            Track pa4al2t4 = new Track("Di Dicki Do Dum", 93, "audio", pa4album2, new HashSet<Genre>() { g.kid }, 2);
            Track pa4al2t5 = new Track("Brown Girl in the Ring", 95, "audio", pa4album2, new HashSet<Genre>() { g.kid }, 2);
            Track pa4al2t6 = new Track("Dorothy's Dance Party", 195, "audio", pa4album2, new HashSet<Genre>() { g.kid }, 4);

            pa4album2.Tracks.Add(pa4al2t1);
            pa4album2.Tracks.Add(pa4al2t2);
            pa4album2.Tracks.Add(pa4al2t3);
            pa4album2.Tracks.Add(pa4al2t4);
            pa4album2.Tracks.Add(pa4al2t5);
            pa4album2.Tracks.Add(pa4al2t6);
            pa4.Albums.Add(pa4album2);

            Track pa4al3t1 = new Track("Here Come Our Friends", 92, "audio", pa4album3, new HashSet<Genre>() { g.kid }, 1);
            Track pa4al3t2 = new Track("Surfer Jeff", 138, "audio", pa4album3, new HashSet<Genre>() { g.kid }, 4);
            Track pa4al3t3 = new Track("Up, Down, Turn Around", 42, "audio", pa4album3, new HashSet<Genre>() { g.kid }, 3);
            Track pa4al3t4 = new Track("The Mini Foxie Puppy Dance", 87, "audio", pa4album3, new HashSet<Genre>() { g.kid }, 3);
            Track pa4al3t5 = new Track("Ooey, Ooey, Ooey Allergies", 123, "audio", pa4album3, new HashSet<Genre>() { g.kid }, 2);
            Track pa4al3t6 = new Track("Look Before You Go", 81, "audio", pa4album3, new HashSet<Genre>() { g.kid }, 1);

            pa4album3.Tracks.Add(pa4al3t1);
            pa4album3.Tracks.Add(pa4al3t2);
            pa4album3.Tracks.Add(pa4al3t3);
            pa4album3.Tracks.Add(pa4al3t4);
            pa4album3.Tracks.Add(pa4al3t5);
            pa4album3.Tracks.Add(pa4al3t6);
            pa4.Albums.Add(pa4album3);

            #endregion

            #region Maria Callas

            Artist pa5 = new Artist("Maria Callas", Country.USA, "photo", new DateTime(1940, 1, 1), new HashSet<Genre> { g.classical });

            Album pa5album = new Album("Pure Maria Callas", new DateTime(1991, 8, 1), "photo", pa5, new HashSet<Genre>() { g.classical });

            Track pa5alt1 = new Track("Norma", 433, "audio", pa5album, new HashSet<Genre>() { g.classical }, 3);
            Track pa5alt2 = new Track("Carmen", 261, "audio", pa5album, new HashSet<Genre>() { g.classical }, 4);
            Track pa5alt3 = new Track("La Traviata", 566, "audio", pa5album, new HashSet<Genre>() { g.classical }, 5);
            Track pa5alt4 = new Track("La Wally", 291, "audio", pa5album, new HashSet<Genre>() { g.classical }, 1);
            Track pa5alt5 = new Track("Gianni Schicchi", 160, "audio", pa5album, new HashSet<Genre>() { g.classical }, 2);
            Track pa5alt6 = new Track("Madama Butterfly", 190, "audio", pa5album, new HashSet<Genre>() { g.classical }, 4);

            pa5album.Tracks.Add(pa5alt1);
            pa5album.Tracks.Add(pa5alt2);
            pa5album.Tracks.Add(pa5alt3);
            pa5album.Tracks.Add(pa5alt4);
            pa5album.Tracks.Add(pa5alt5);
            pa5album.Tracks.Add(pa5alt6);
            pa5.Albums.Add(pa5album);
            #endregion
            #region Transfer to DB

            return new List<Artist> { pa1, pa2, pa3, pa4, pa5 };

            #endregion
            #endregion


        }
    }
}
