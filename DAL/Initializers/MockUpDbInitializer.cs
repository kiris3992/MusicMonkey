using Entities.Enums;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Initializers
{
    public class MockUpDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            #region Orestis Region
            #region Seeding Genres
            Genre blues = new Genre("Blues");
            Genre chillstep = new Genre("Chillstep");
            Genre classical = new Genre("Classical");
            Genre country = new Genre("Country");
            Genre dance = new Genre("Dance");
            Genre disco = new Genre("Disco");
            Genre electronic = new Genre("Electronic");
            Genre folk = new Genre("Folk");
            Genre hipHop = new Genre("Hip Hop");
            Genre house = new Genre("House");
            Genre instrumental = new Genre("Instrumental");
            Genre jazz = new Genre("Jazz");
            Genre kid = new Genre("Kid");
            Genre latin = new Genre("Latin");
            Genre metal = new Genre("Metal");
            Genre opera = new Genre("Opera");
            Genre pop = new Genre("Pop");
            Genre progressive = new Genre("Progressive");
            Genre punk = new Genre("Punk");
            Genre rap = new Genre("Rap");
            Genre reggae = new Genre("Reggae");
            Genre rnb = new Genre("Rnb");
            Genre rock = new Genre("Rock");
            Genre soul = new Genre("Soul");
            Genre techno = new Genre("Techno");
            Genre traditional = new Genre("Traditional");
            Genre trance = new Genre("Trance");
            Genre trap = new Genre("Trap");
            Genre hardRock = new Genre("Hard Rock");
            Genre heavyMetal = new Genre("Heavy Metal");
            Genre grunge = new Genre("Grunge");
            #endregion

            #region ACDC
            Artist oa1 = new Artist("AC DC", Country.Australia, "Some artist photo Url", new DateTime(1973, 1, 1), new HashSet<Genre>() { rock, hardRock, heavyMetal });

            Album oam1 = new Album("Highway to Hell", new DateTime(1979, 1, 1), "Some cover photo url", oa1, new HashSet<Genre>() { rock, hardRock, heavyMetal });
            Album oam2 = new Album("Back in Black", new DateTime(1980, 7, 21), "Some cover photo url", oa1, new HashSet<Genre>() { rock, hardRock, heavyMetal });
            Album oam3 = new Album("Dirty Deeds Done Dirt Cheap", new DateTime(1976, 9, 20), "Some cover photo url", oa1, new HashSet<Genre>() { rock, hardRock, heavyMetal });

            Track ot1 = new Track("Highway to Hell", 208, "Some audio url", oam1, new HashSet<Genre>() { rock, hardRock, heavyMetal });
            Track ot2 = new Track("if You Want Blood", 277, "Some audio url", oam1, new HashSet<Genre>() { rock, hardRock, heavyMetal });
            Track ot3 = new Track("Get it Hot", 154, "Some audio url", oam1, new HashSet<Genre>() { rock, hardRock, heavyMetal });
            Track ot4 = new Track("Love Hungry Man", 257, "Some audio url", oam1, new HashSet<Genre>() { rock, hardRock, heavyMetal });
            Track ot5 = new Track("Night Prowler", 376, "Some audio url", oam1, new HashSet<Genre>() { rock, hardRock, heavyMetal });
            Track ot6 = new Track("Touch to Much", 246, "Some audio url", oam1, new HashSet<Genre>() { rock, hardRock, heavyMetal });

            oam1.Tracks.Add(ot1);
            oam1.Tracks.Add(ot2);
            oam1.Tracks.Add(ot3);
            oam1.Tracks.Add(ot4);
            oam1.Tracks.Add(ot5);
            oam1.Tracks.Add(ot6);
            oa1.Albums.Add(oam1);

            Track ot7 = new Track("Hells Bells", 312, "Some audio url", oam2, new HashSet<Genre>() { rock, hardRock, heavyMetal });
            Track ot8 = new Track("Let Me Put My Love Into You", 215, "Some audio url", oam2, new HashSet<Genre>() { rock, hardRock, heavyMetal });
            Track ot9 = new Track("You Shook Me All Night Long", 210, "Some audio url", oam2, new HashSet<Genre>() { rock, hardRock, heavyMetal });
            Track ot10 = new Track("Shoot to Thrill", 318, "Some audio url", oam2, new HashSet<Genre>() { rock, hardRock, heavyMetal });
            Track ot11 = new Track("Back in Black", 256, "Some audio url", oam2, new HashSet<Genre>() { rock, hardRock, heavyMetal });
            Track ot12 = new Track("Givin The Dog A Bone", 212, "Some audio url", oam2, new HashSet<Genre>() { rock, hardRock, heavyMetal });

            oam2.Tracks.Add(ot7);
            oam2.Tracks.Add(ot8);
            oam2.Tracks.Add(ot9);
            oam2.Tracks.Add(ot10);
            oam2.Tracks.Add(ot11);
            oam2.Tracks.Add(ot12);
            oa1.Albums.Add(oam2);

            Track ot13 = new Track("Dirty Deeds Done Dirt Cheap", 232, "Some audio url", oam3, new HashSet<Genre>() { rock, hardRock, heavyMetal });
            Track ot14 = new Track("Big Balls", 159, "Some audio url", oam3, new HashSet<Genre>() { rock, hardRock, heavyMetal });
            Track ot15 = new Track("Problem Child", 346, "Some audio url", oam3, new HashSet<Genre>() { rock, hardRock, heavyMetal });
            Track ot16 = new Track("Love at First Feel", 192, "Some audio url", oam3, new HashSet<Genre>() { rock, hardRock, heavyMetal });
            Track ot17 = new Track("Rocker", 171, "Some audio url", oam3, new HashSet<Genre>() { rock, hardRock, heavyMetal });
            Track ot18 = new Track("Dirty Deeds Done Dirt Cheap", 232, "Some audio url", oam3, new HashSet<Genre>() { rock, hardRock, heavyMetal });

            oam3.Tracks.Add(ot13);
            oam3.Tracks.Add(ot14);
            oam3.Tracks.Add(ot15);
            oam3.Tracks.Add(ot16);
            oam3.Tracks.Add(ot17);
            oam3.Tracks.Add(ot18);
            oa1.Albums.Add(oam3);
            #endregion

            #region Damian Marley
            Artist oa2 = new Artist("Damian Marley", Country.Jamaica, "Some artist photo url", new DateTime(1992, 1, 1), new HashSet<Genre>() { reggae, rnb, soul, hipHop, rap});

            Album oam4 = new Album("Welcome to Jamrock", new DateTime(2005, 9, 12), "Some cover photo url",  oa2, new HashSet<Genre>() { reggae, rnb, hipHop, rap });
            Album oam5 = new Album("Mr.Marley", new DateTime(1996, 9, 9), "Some cover photo url",  oa2, new HashSet<Genre>() { reggae, rnb, hipHop, rap });
            Album oam6 = new Album("Halfway Tree", new DateTime(2001, 9, 11), "Some cover photo url", oa2, new HashSet<Genre>() { reggae, rnb, soul, hipHop, rap });

            Track ot19 = new Track("Confrontation", 329, "Some audio url", oam4, new HashSet<Genre>() { reggae, rnb, hipHop, rap });
            Track ot20 = new Track("Welcome to Jamrock", 214, "Some audio url", oam4, new HashSet<Genre>() { reggae, rnb, hipHop, rap });
            Track ot21 = new Track("All Night", 210, "Some audio url", oam4, new HashSet<Genre>() { reggae, rnb, hipHop, rap });
            Track ot22 = new Track("Pimpa's Paradise", 304, "Some audio url", oam4, new HashSet<Genre>() { reggae, rnb, hipHop, rap });
            Track ot23 = new Track("There for You", 241, "Some audio url", oam4, new HashSet<Genre>() { reggae, rnb, hipHop, rap });
            Track ot24 = new Track("Beautiful", 248, "Some audio url", oam4, new HashSet<Genre>() { reggae, rnb, hipHop, rap });

            oam4.Tracks.Add(ot19);
            oam4.Tracks.Add(ot20);
            oam4.Tracks.Add(ot21);
            oam4.Tracks.Add(ot22);
            oam4.Tracks.Add(ot23);
            oam4.Tracks.Add(ot24);
            oa2.Albums.Add(oam4);

            Track ot25 = new Track("Trouble", 335, "Some audio url", oam5, new HashSet<Genre>() { reggae, rnb, hipHop, rap });
            Track ot26 = new Track("Party Time", 252, "Some audio url", oam5, new HashSet<Genre>() { reggae, rnb, hipHop, rap });
            Track ot27 = new Track("Keep on Grooving", 276, "Some audio url", oam5, new HashSet<Genre>() { reggae, rnb, hipHop, rap });
            Track ot28 = new Track("Love and Unity", 244, "Some audio url", oam5, new HashSet<Genre>() { reggae, rnb, hipHop, rap });
            Track ot29 = new Track("Old War Chant", 248, "Some audio url", oam5, new HashSet<Genre>() { reggae, rnb, hipHop, rap });
            Track ot30 = new Track("Kingston 12", 214, "Some audio url", oam5, new HashSet<Genre>() { reggae, rnb, hipHop, rap });

            oam5.Tracks.Add(ot25);
            oam5.Tracks.Add(ot26);
            oam5.Tracks.Add(ot27);
            oam5.Tracks.Add(ot28);
            oam5.Tracks.Add(ot29);
            oam5.Tracks.Add(ot30);
            oa2.Albums.Add(oam5);

            Track ot31 = new Track("Educated Fools", 317, "Some audio url", oam6, new HashSet<Genre>() { reggae, rnb, soul, hipHop, rap });
            Track ot32 = new Track("It Was Written", 367, "Some audio url", oam6, new HashSet<Genre>() { reggae, rnb, soul, hipHop, rap });
            Track ot33 = new Track("Still Searchin'", 305, "Some audio url", oam6, new HashSet<Genre>() { reggae, rnb, soul, hipHop, rap });
            Track ot34 = new Track("Mi Blenda", 281, "Some audio url", oam6, new HashSet<Genre>() { reggae, rnb, soul, hipHop, rap });
            Track ot35 = new Track("More Justice", 215, "Some audio url", oam6, new HashSet<Genre>() { reggae, rnb, soul, hipHop, rap });
            Track ot36 = new Track("Catch a Fire", 291, "Some audio url", oam6, new HashSet<Genre>() { reggae, rnb, soul, hipHop, rap });

            oam6.Tracks.Add(ot31);
            oam6.Tracks.Add(ot32);
            oam6.Tracks.Add(ot33);
            oam6.Tracks.Add(ot34);
            oam6.Tracks.Add(ot35);
            oam6.Tracks.Add(ot36);
            oa2.Albums.Add(oam6);
            #endregion

            #region Creedence Clearwater Revival
            Artist oa3 = new Artist("Creedence Clearwater Revival", Country.USA, "Some artist photo url", new DateTime(1967, 1, 1), new HashSet<Genre>() { rock, country, blues, folk});

            Album oam7 = new Album("Cosmo's Factory", new DateTime(1970, 7, 1), "Some cover photo url", oa3, new HashSet<Genre>() { rock, country, blues, folk});
            Album oam8 = new Album("Pendulum", new DateTime(1970, 2, 9), "Some cover photo url", oa3, new HashSet<Genre>() { rock, country, blues, folk});
            Album oam9 = new Album("Mardi Gras", new DateTime(1972, 4, 11), "Some cover photo url", oa3, new HashSet<Genre>() { rock, country, blues, folk});

            Track ot37 = new Track("Ramble Tamble", 432, "Some audio url", oam7, new HashSet<Genre>() { rock, country, blues, folk});
            Track ot38 = new Track("Travelin Band", 127, "Some audio url", oam7, new HashSet<Genre>() { rock, country, blues, folk});
            Track ot39 = new Track("Lookin' out My Back Door", 151, "Some audio url", oam7, new HashSet<Genre>() { rock, country, blues, folk});
            Track ot40 = new Track("Up Around the Bend", 162, "Some audio url", oam7, new HashSet<Genre>() { rock, country, blues, folk});
            Track ot41 = new Track("Before You Accuse Me", 207, "Some audio url", oam7, new HashSet<Genre>() { rock, country, blues, folk});
            Track ot42 = new Track("Ooby Dooby", 128, "Some audio url", oam7, new HashSet<Genre>() { rock, country, blues, folk});

            oam7.Tracks.Add(ot37);
            oam7.Tracks.Add(ot38);
            oam7.Tracks.Add(ot39);
            oam7.Tracks.Add(ot40);
            oam7.Tracks.Add(ot41);
            oam7.Tracks.Add(ot42);
            oa3.Albums.Add(oam7);

            Track ot43 = new Track("Pegan Baby", 385, "Some audio url", oam8, new HashSet<Genre>() { rock, country, blues, folk });
            Track ot44 = new Track("Chameleon", 200, "Some audio url", oam8, new HashSet<Genre>() { rock, country, blues, folk });
            Track ot45 = new Track("Hey Tonight", 163, "Some audio url", oam8, new HashSet<Genre>() { rock, country, blues, folk });
            Track ot46 = new Track("Have You Ever Seen The Rain", 160, "Some audio url", oam8, new HashSet<Genre>() { rock, country, blues, folk });
            Track ot47 = new Track("Born to Move", 341, "Some audio url", oam8, new HashSet<Genre>() { rock, country, blues, folk });
            Track ot48 = new Track("Sailor's Lament", 228, "Some audio url", oam8, new HashSet<Genre>() { rock, country, blues, folk });

            oam8.Tracks.Add(ot43);
            oam8.Tracks.Add(ot44);
            oam8.Tracks.Add(ot45);
            oam8.Tracks.Add(ot46);
            oam8.Tracks.Add(ot47);
            oam8.Tracks.Add(ot48);
            oa3.Albums.Add(oam8);

            Track ot49 = new Track("Lookin' For A Reason", 205, "Some audio url", oam9, new HashSet<Genre>() { rock, country, blues, folk });
            Track ot50 = new Track("Need Someone to Hold", 184, "Some audio url", oam9, new HashSet<Genre>() { rock, country, blues, folk });
            Track ot51 = new Track("Someday Never Comes", 241, "Some audio url", oam9, new HashSet<Genre>() { rock, country, blues, folk });
            Track ot52 = new Track("Sail Away", 153, "Some audio url", oam9, new HashSet<Genre>() { rock, country, blues, folk });
            Track ot53 = new Track("Take It Like a Friend", 182, "Some audio url", oam9, new HashSet<Genre>() { rock, country, blues, folk });
            Track ot54 = new Track("Hello Mary Lou", 135, "Some audio url", oam9, new HashSet<Genre>() { rock, country, blues, folk });

            oam9.Tracks.Add(ot49);
            oam9.Tracks.Add(ot50);
            oam9.Tracks.Add(ot51);
            oam9.Tracks.Add(ot52);
            oam9.Tracks.Add(ot53);
            oam9.Tracks.Add(ot54);
            oa3.Albums.Add(oam9);
            #endregion

            #region Pass Data to DB
            context.Genres.AddOrUpdate(blues, chillstep, classical, country, dance, disco, electronic, folk, hipHop, house, instrumental, jazz, kid, latin, metal, opera, pop, progressive, punk, rap, reggae, rnb, rock, soul, techno, traditional, trance, trap, hardRock, heavyMetal, grunge);
            context.Artists.AddOrUpdate(oa1, oa2);
            context.Albums.AddOrUpdate(oam1, oam2, oam2, oam4, oam5, oam6, oam7, oam8, oam9);
            context.Tracks.AddOrUpdate(ot1, ot2, ot3, ot4, ot5, ot6, ot7, ot8, ot9, ot10, ot11, ot12, ot13, ot14, ot15, ot16, ot17, ot18, ot19, ot20, ot21, ot22, ot23, ot24, ot25, ot26, ot27, ot28, ot29, ot30, ot31, ot32, ot33, ot34, ot35, ot36, ot37, ot38, ot39, ot40, ot41, ot42, ot43, ot44, ot45, ot46, ot47, ot48, ot49, ot50, ot51, ot52, ot53, ot54);
            context.SaveChanges();
            #endregion
            #endregion


            #region Panos Seeding
            # region Bob Dylan
            Artist pa1 = new Artist("Bob Dylan", Country.USA, "photo", new DateTime(1959, 1, 1), new HashSet<Genre>() { folk, blues });

            Album pa1album1 = new Album("Bringing It All Back Home", new DateTime(1965, 3, 22), "photo", pa1, new HashSet<Genre>() { folk, blues });
            Album pa1album2 = new Album("Planet Waves", new DateTime(1974, 1, 17), "photo", pa1, new HashSet<Genre>() { folk, rock, blues });
            Album pa1album3 = new Album("Dylan & the Dead", new DateTime(1989, 2, 6), "photo", pa1, new HashSet<Genre>() { folk, rock });

            Track pa1al1t1 = new Track("Mr. Tambourine Man", 320, "audio", pa1album1, new HashSet<Genre>() { folk }, 4);
            Track pa1al1t2 = new Track("Gates of Eden", 324, "audio", pa1album1, new HashSet<Genre>() { folk, blues }, 2);
            Track pa1al1t3 = new Track("It's Alright, Ma (I'm Only Bleeding)", 437, "audio", pa1album1, new HashSet<Genre>() { folk },3);
            Track pa1al1t4 = new Track("It's All Over Now, Baby Blue", 248, "audio", pa1album1, new HashSet<Genre>() { folk, country },3);

            pa1album1.Tracks.Add(pa1al1t1);
            pa1album1.Tracks.Add(pa1al1t2);
            pa1album1.Tracks.Add(pa1al1t3);
            pa1album1.Tracks.Add(pa1al1t4);
            pa1.Albums.Add(pa1album1);

            Track pa1al2t1 = new Track("On a Night Like This", 154, "audio", pa1album2, new HashSet<Genre>() { folk }, 4);
            Track pa1al2t2 = new Track("Going, Going, Gone", 196, "audio", pa1album2, new HashSet<Genre>() { folk }, 2);
            Track pa1al2t3 = new Track("Tough Mama", 250, "audio", pa1album2, new HashSet<Genre>() { folk }, 1);
            Track pa1al2t4 = new Track("Hazel", 149, "audio", pa1album2, new HashSet<Genre>() { folk }, 4);
            Track pa1al2t5 = new Track("Something There Is About You", 267, "audio", pa1album2, new HashSet<Genre>() { folk }, 3);
            Track pa1al2t6 = new Track("Forever Young", 280, "audio", pa1album2, new HashSet<Genre>() { folk, rock }, 2);

            pa1album2.Tracks.Add(pa1al2t1);
            pa1album2.Tracks.Add(pa1al2t2);
            pa1album2.Tracks.Add(pa1al2t3);
            pa1album2.Tracks.Add(pa1al2t4);
            pa1album2.Tracks.Add(pa1al2t5);
            pa1album2.Tracks.Add(pa1al2t6);

            pa1.Albums.Add(pa1album2);

            Track pa1al3t1 = new Track("Slow Train",272,"audio",pa1album3, new HashSet<Genre>() { folk, blues }, 1);
            Track pa1al3t2 = new Track("I Want You",240,"audio",pa1album3, new HashSet<Genre>() { folk, blues }, 2);
            Track pa1al3t3 = new Track("Gotta Serve Somebody",325,"audio",pa1album3, new HashSet<Genre>() { folk, blues }, 4);
            Track pa1al3t4 = new Track("Queen Jane Approximately",378,"audio",pa1album3, new HashSet<Genre>() { folk, blues }, 2);
            Track pa1al3t5 = new Track("Joey",546,"audio",pa1album3, new HashSet<Genre>() { folk, blues }, 3);
            Track pa1al3t6 = new Track("All Along the Watchtower", 352,"audio",pa1album3, new HashSet<Genre>() { folk }, 3);
            Track pa1al3t7 = new Track("Knockin' on Heaven's Door", 401,"audio",pa1album3, new HashSet<Genre>() { folk, rock }, 5);

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

            Artist pa2 = new Artist("Ludwig van Beethoven", Country.Germany, "photo", new DateTime(1790, 1, 1), new HashSet<Genre>() { classical });

            Album pa2album = new Album("Beethoven Symfonies", new DateTime(1795, 1, 1),"photo", pa2, new HashSet<Genre>() { classical });

            Track pa2t1 = new Track("Symphony No.1, C",1669,"audio",pa2album, new HashSet<Genre>() { classical },2);
            Track pa2t2 = new Track("Symphony No.2,D",1809,"audio",pa2album, new HashSet<Genre>() { classical },1);
            Track pa2t3 = new Track("Symphony No.3 (Eroica), Eb",3336,"audio",pa2album, new HashSet<Genre>() { classical },1);
            Track pa2t4 = new Track("Symphony No.4, Bb",2247,"audio",pa2album, new HashSet<Genre>() { classical },2);
            Track pa2t5 = new Track("Symphony No.5, C minor",2012,"audio",pa2album, new HashSet<Genre>() { classical },3);
            Track pa2t6 = new Track("Symphony No.6 (Pastoral), F",2523,"audio",pa2album, new HashSet<Genre>() { classical },1);
            Track pa2t7 = new Track("Symphony No.7, A",1983,"audio",pa2album, new HashSet<Genre>() { classical },3);
            Track pa2t8 = new Track("Symphony No.8, F ",2340,"audio",pa2album, new HashSet<Genre>() { classical },4);
            Track pa2t9 = new Track("Symphony No.9 (Choral), D minor", 3939,"audio",pa2album, new HashSet<Genre>() { classical },5);

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
            Artist pa3 = new Artist("Lady Gaga", Country.USA, "photo", new DateTime(2007, 1, 1), new HashSet<Genre>() { pop });

            Album pa3album1=new Album("The Fame",new DateTime(2008,08,19),"photo",pa3,new HashSet<Genre>() { pop });
            Album pa3album2=new Album("Born this way",new DateTime(2011,05,23),"photo",pa3,new HashSet<Genre>() { pop });
            Album pa3album3=new Album("Joanne",new DateTime(2016,10,21),"photo",pa3,new HashSet<Genre>() { pop,rock,country });

            Track pa3al1t1 = new Track("Just Dance", 242,"audio",pa3album1, new HashSet<Genre>() { pop },4);
            Track pa3al1t2 = new Track("LoveGame", 216,"audio",pa3album1, new HashSet<Genre>() { pop },3);
            Track pa3al1t3 = new Track("Paparazzi", 208,"audio",pa3album1, new HashSet<Genre>() { pop },3);
            Track pa3al1t4 = new Track("Poker Face", 238,"audio",pa3album1, new HashSet<Genre>() { pop },5);
            Track pa3al1t5 = new Track("Eh, Eh (Nothing Else I Can Say)", 175,"audio",pa3album1, new HashSet<Genre>() { pop },1);
            Track pa3al1t6 = new Track("Beautiful, Dirty, Rich", 220,"audio",pa3album1, new HashSet<Genre>() { pop },2);
            Track pa3al1t7 = new Track("The Fame", 222,"audio",pa3album1, new HashSet<Genre>() { pop },3);
            Track pa3al1t8 = new Track("Money Honey", 170,"audio",pa3album1, new HashSet<Genre>() { pop },2);
            Track pa3al1t9 = new Track("Starstruck", 217,"audio",pa3album1, new HashSet<Genre>() { pop },1);

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

            Track pa3al2t1 = new Track("Marry the night",245,"audio",pa3album2, new HashSet<Genre>() { pop },3);
            Track pa3al2t2 = new Track("Born this way",240,"audio",pa3album2, new HashSet<Genre>() { pop },5);
            Track pa3al2t3 = new Track("Government Hooker",254,"audio",pa3album2, new HashSet<Genre>() { pop },1);
            Track pa3al2t4 = new Track("Judas",249,"audio",pa3album2, new HashSet<Genre>() { pop },4);
            Track pa3al2t5 = new Track("Americano",247,"audio",pa3album2, new HashSet<Genre>() { pop },2);
            Track pa3al2t6 = new Track("Hair",308,"audio",pa3album2, new HashSet<Genre>() { pop },1);
            Track pa3al2t7 = new Track("Edge of Glory",321,"audio",pa3album2, new HashSet<Genre>() { pop },4);

            pa3album2.Tracks.Add(pa3al2t1);
            pa3album2.Tracks.Add(pa3al2t2);
            pa3album2.Tracks.Add(pa3al2t3);
            pa3album2.Tracks.Add(pa3al2t4);
            pa3album2.Tracks.Add(pa3al2t5);
            pa3album2.Tracks.Add(pa3al2t6);
            pa3album2.Tracks.Add(pa3al2t7);

            pa3.Albums.Add(pa3album2);

            Track pa3al3t1 = new Track("Diamont Heart",210,"audio",pa3album3, new HashSet<Genre>() { pop, blues },2);
            Track pa3al3t2 = new Track("A-Yo",208,"audio",pa3album3, new HashSet<Genre>() { pop },1);
            Track pa3al3t3 = new Track("Joanne",197,"audio",pa3album3, new HashSet<Genre>() { pop, country },2);
            Track pa3al3t4 = new Track("John Wayne",174,"audio",pa3album3, new HashSet<Genre>() { pop, rock },3);
            Track pa3al3t5 = new Track("Dancin’ In Circles",207,"audio",pa3album3, new HashSet<Genre>() { pop },2);
            Track pa3al3t6 = new Track("Perfect Illusion",182,"audio",pa3album3, new HashSet<Genre>() { pop, country },4);
            Track pa3al3t7 = new Track("Million Reasons",205,"audio",pa3album3, new HashSet<Genre>() { pop, blues },4);

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

            Artist pa4 = new Artist("The Wiggles", Country.Australia,"photo", new DateTime(1991,1,1),new HashSet<Genre>() { kid});

            Album pa4album1 = new Album("The Wiggles",new DateTime(1991,08,1),"photo",pa4,new HashSet<Genre>() { kid});
            Album pa4album2 = new Album("Big Red Car",new DateTime(1995,1,1),"photo",pa4,new HashSet<Genre>() { kid});
            Album pa4album3 = new Album("Serfer Jeff",new DateTime(2012,5,3),"photo",pa4,new HashSet<Genre>() { kid});

            Track pa4al1t1 = new Track("Get Ready to Wiggle", 117,"audio", pa4album1,new HashSet<Genre>() { kid},4);
            Track pa4al1t2 = new Track("Lavender's Blue", 92,"audio", pa4album1,new HashSet<Genre>() { kid},3);
            Track pa4al1t3 = new Track("Rock-a-Bye Your Bear", 106,"audio", pa4album1,new HashSet<Genre>() { kid},2);
            Track pa4al1t4 = new Track("Dorothy the Dinosaur", 143,"audio", pa4album1,new HashSet<Genre>() { kid},1);
            Track pa4al1t5 = new Track("Mischief the Monkey", 44,"audio", pa4album1,new HashSet<Genre>() { kid},1);
            Track pa4al1t6 = new Track("Glub Glub Train", 19,"audio", pa4album1,new HashSet<Genre>() { kid},2);

            pa4album1.Tracks.Add(pa4al1t1);
            pa4album1.Tracks.Add(pa4al1t2);
            pa4album1.Tracks.Add(pa4al1t3);
            pa4album1.Tracks.Add(pa4al1t4);
            pa4album1.Tracks.Add(pa4al1t5);
            pa4album1.Tracks.Add(pa4al1t6);
            pa4.Albums.Add(pa4album1);

            Track pa4al2t1 = new Track("Wags the Dog",162,"audio",pa4album2,new HashSet<Genre>() { kid},2);
            Track pa4al2t2 = new Track("Henry's Dance",111,"audio",pa4album2,new HashSet<Genre>() { kid},1);
            Track pa4al2t3 = new Track("Five Little Joeys",108,"audio",pa4album2,new HashSet<Genre>() { kid},3);
            Track pa4al2t4 = new Track("Di Dicki Do Dum",93,"audio",pa4album2,new HashSet<Genre>() { kid},2);
            Track pa4al2t5 = new Track("Brown Girl in the Ring", 95, "audio", pa4album2, new HashSet<Genre>() { kid }, 2);
            Track pa4al2t6 = new Track("Dorothy's Dance Party",195,"audio",pa4album2,new HashSet<Genre>() { kid},4);

            pa4album2.Tracks.Add(pa4al2t1);
            pa4album2.Tracks.Add(pa4al2t2);
            pa4album2.Tracks.Add(pa4al2t3);
            pa4album2.Tracks.Add(pa4al2t4);
            pa4album2.Tracks.Add(pa4al2t5);
            pa4album2.Tracks.Add(pa4al2t6);
            pa4.Albums.Add(pa4album2);

            Track pa4al3t1 = new Track("Here Come Our Friends", 92,"audio",pa4album3,new HashSet<Genre>() { kid},1);
            Track pa4al3t2 = new Track("Surfer Jeff", 138,"audio",pa4album3,new HashSet<Genre>() { kid},4);
            Track pa4al3t3 = new Track("Up, Down, Turn Around", 42,"audio",pa4album3,new HashSet<Genre>() { kid},3);
            Track pa4al3t4 = new Track("The Mini Foxie Puppy Dance", 87,"audio",pa4album3,new HashSet<Genre>() { kid},3);
            Track pa4al3t5 = new Track("Ooey, Ooey, Ooey Allergies", 123,"audio",pa4album3,new HashSet<Genre>() { kid},2);
            Track pa4al3t6 = new Track("Look Before You Go", 81,"audio",pa4album3,new HashSet<Genre>() { kid},1);

            pa4album3.Tracks.Add(pa4al3t1);
            pa4album3.Tracks.Add(pa4al3t2);
            pa4album3.Tracks.Add(pa4al3t3);
            pa4album3.Tracks.Add(pa4al3t4);
            pa4album3.Tracks.Add(pa4al3t5);
            pa4album3.Tracks.Add(pa4al3t6);
            pa4.Albums.Add(pa4album3);

            #endregion

            #region Maria Callas

            Artist pa5 = new Artist("Maria Callas", Country.USA, "photo", new DateTime(1940, 1, 1), new HashSet<Genre>() { classical });

            Album pa5album = new Album("Pure Maria Callas", new DateTime(1991,8,1),"photo",pa5,new HashSet<Genre>() { classical });

            Track pa5alt1 = new Track("Norma", 433,"audio",pa5album,new HashSet<Genre>() { classical },3);
            Track pa5alt2 = new Track("Carmen", 261,"audio",pa5album,new HashSet<Genre>() { classical },4);
            Track pa5alt3 = new Track("La Traviata", 566,"audio",pa5album,new HashSet<Genre>() { classical },5);
            Track pa5alt4 = new Track("La Wally", 291,"audio",pa5album,new HashSet<Genre>() { classical },1);
            Track pa5alt5 = new Track("Gianni Schicchi", 160,"audio",pa5album,new HashSet<Genre>() { classical },2);
            Track pa5alt6 = new Track("Madama Butterfly", 190,"audio",pa5album,new HashSet<Genre>() { classical },4);

            pa5album.Tracks.Add(pa5alt1);
            pa5album.Tracks.Add(pa5alt2);
            pa5album.Tracks.Add(pa5alt3);
            pa5album.Tracks.Add(pa5alt4);
            pa5album.Tracks.Add(pa5alt5);
            pa5album.Tracks.Add(pa5alt6);
            pa5.Albums.Add(pa5album);
            #endregion
            #region Transfer to DB
            context.Artists.AddOrUpdate(pa1,pa2,pa3,pa4,pa5);
            context.Albums.AddOrUpdate(pa1album1, pa1album2, pa1album3,pa2album, pa3album1, pa3album2, pa3album3, pa4album1, pa4album2, pa4album3,pa5album);
            context.Tracks.AddOrUpdate(pa1al1t1, pa1al1t2, pa1al1t3, pa1al1t4, pa1al2t1, pa1al2t2, pa1al2t3, pa1al2t4, pa1al2t5, pa1al2t6, 
                                        pa1al3t1, pa1al3t2, pa1al3t3, pa1al3t4, pa1al3t5, pa1al3t6, pa1al3t7, pa2t1, pa2t2, pa2t3, pa2t4, 
                                        pa2t5, pa2t6, pa2t7, pa2t8, pa2t9, pa3al1t1, pa3al1t2, pa3al1t3, pa3al1t4, pa3al1t5, pa3al1t6, 
                                        pa3al1t7, pa3al1t8, pa3al1t9, pa3al2t1, pa3al2t2, pa3al2t3, pa3al2t4, pa3al2t5, pa3al2t6, pa3al2t7, pa3al3t1,
                                        pa3al3t2, pa3al3t3, pa3al3t4, pa3al3t5, pa3al3t6, pa3al3t7, pa4al1t1, pa4al1t2, pa4al1t3, pa4al1t4, pa4al1t5,
                                        pa4al1t6, pa4al2t1, pa4al2t2, pa4al2t3, pa4al2t4, pa4al2t5, pa4al2t6, pa4al3t1, pa4al3t2, pa4al3t3, pa4al3t4,
                                        pa4al3t5, pa4al3t6, pa5alt1, pa5alt2, pa5alt3, pa5alt4, pa5alt5, pa5alt6);
            context.SaveChanges();
            #endregion
            #endregion

            base.Seed(context);
        }
    }
}
