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
            Track ot23 = new Track("There for You", 281, "Some audio url", oam4, new HashSet<Genre>() { reggae, rnb, hipHop, rap });
            Track ot24 = new Track("Beautiful", 288, "Some audio url", oam4, new HashSet<Genre>() { reggae, rnb, hipHop, rap });

            oam4.Tracks.Add(ot19);
            oam4.Tracks.Add(ot20);
            oam4.Tracks.Add(ot21);
            oam4.Tracks.Add(ot22);
            oam4.Tracks.Add(ot23);
            oam4.Tracks.Add(ot24);
            oa2.Albums.Add(oam4);
            #endregion

            //#region Creedence Clearwater Revival
            //Artist oa3 = new Artist("Creadence Clearwater Revival", Country.USA, "Some artist photo url", new DateTime(1967, 1, 1), new HashSet<Genre>() {rock, country, blues });
            //#endregion

            context.Genres.AddOrUpdate(blues, chillstep, classical, country, dance, disco, electronic, folk, hipHop, house, instrumental, jazz, kid, latin, metal, opera, pop, progressive, punk, rap, reggae, rnb, rock, soul, techno, traditional, trance, trap, hardRock, heavyMetal, grunge);
            context.Artists.AddOrUpdate(oa1, oa2);
            context.Albums.AddOrUpdate(oam1, oam2, oam2, oam4, oam5, oam6);
            context.Tracks.AddOrUpdate(ot1, ot2, ot3, ot4, ot5, ot6, ot7, ot8, ot9, ot10, ot11, ot12, ot13, ot14, ot15, ot16, ot17, ot18, ot19, ot20, ot21, ot22, ot23, ot24);
            context.SaveChanges();
            #endregion

            base.Seed(context);
        }
    }
}
