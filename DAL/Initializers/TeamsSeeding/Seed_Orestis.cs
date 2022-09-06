using Entities.Enums;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Initializers.TeamsSeeding
{
    public class Seed_Orestis : AbsTeamSeeder, ITeamSeeder
    {
        public List<Artist> GetArtists()
        {
            #region Orestis Region

            #region ACDC
            Artist oa1 = new Artist("AC DC", Country.Australia, "Some artist photo Url", new DateTime(1973, 1, 1), new HashSet<Genre>() { rock, hardRock, heavyMetal });

            Album oam1 = new Album("Highway to Hell", new DateTime(1979, 1, 1), "Some cover photo url", oa1, new HashSet<Genre>() { rock, hardRock, heavyMetal });
            Album oam2 = new Album("Back in Black", new DateTime(1980, 7, 21), "Some cover photo url", oa1, new HashSet<Genre>() { rock, hardRock, heavyMetal });
            Album oam3 = new Album("Dirty Deeds Done Dirt Cheap", new DateTime(1976, 9, 20), "Some cover photo url", oa1, new HashSet<Genre>() { rock, hardRock, heavyMetal });

            Track ot1 = new Track("Highway to Hell", 208, "Some audio url", oam1, new HashSet<Genre>() { rock, hardRock, heavyMetal }, 5);
            Track ot2 = new Track("if You Want Blood", 277, "Some audio url", oam1, new HashSet<Genre>() { rock, hardRock, heavyMetal }, 5);
            Track ot3 = new Track("Get it Hot", 154, "Some audio url", oam1, new HashSet<Genre>() { rock, hardRock, heavyMetal }, 4);
            Track ot4 = new Track("Love Hungry Man", 257, "Some audio url", oam1, new HashSet<Genre>() { rock, hardRock, heavyMetal }, 4);
            Track ot5 = new Track("Night Prowler", 376, "Some audio url", oam1, new HashSet<Genre>() { rock, hardRock, heavyMetal }, 4);
            Track ot6 = new Track("Touch to Much", 246, "Some audio url", oam1, new HashSet<Genre>() { rock, hardRock, heavyMetal }, 5);

            oam1.Tracks.Add(ot1);
            oam1.Tracks.Add(ot2);
            oam1.Tracks.Add(ot3);
            oam1.Tracks.Add(ot4);
            oam1.Tracks.Add(ot5);
            oam1.Tracks.Add(ot6);
            oa1.Albums.Add(oam1);

            Track ot7 = new Track("Hells Bells", 312, "Some audio url", oam2, new HashSet<Genre>() { rock, hardRock, heavyMetal }, 5);
            Track ot8 = new Track("Let Me Put My Love Into You", 215, "Some audio url", oam2, new HashSet<Genre>() { rock, hardRock, heavyMetal }, 5);
            Track ot9 = new Track("You Shook Me All Night Long", 210, "Some audio url", oam2, new HashSet<Genre>() { rock, hardRock, heavyMetal }, 5);
            Track ot10 = new Track("Shoot to Thrill", 318, "Some audio url", oam2, new HashSet<Genre>() { rock, hardRock, heavyMetal }, 5);
            Track ot11 = new Track("Back in Black", 256, "Some audio url", oam2, new HashSet<Genre>() { rock, hardRock, heavyMetal }, 5);
            Track ot12 = new Track("Givin The Dog A Bone", 212, "Some audio url", oam2, new HashSet<Genre>() { rock, hardRock, heavyMetal }, 5);

            oam2.Tracks.Add(ot7);
            oam2.Tracks.Add(ot8);
            oam2.Tracks.Add(ot9);
            oam2.Tracks.Add(ot10);
            oam2.Tracks.Add(ot11);
            oam2.Tracks.Add(ot12);
            oa1.Albums.Add(oam2);

            Track ot13 = new Track("Dirty Deeds Done Dirt Cheap", 232, "Some audio url", oam3, new HashSet<Genre>() { rock, hardRock, heavyMetal }, 5);
            Track ot14 = new Track("Big Balls", 159, "Some audio url", oam3, new HashSet<Genre>() { rock, hardRock, heavyMetal }, 4);
            Track ot15 = new Track("Problem Child", 346, "Some audio url", oam3, new HashSet<Genre>() { rock, hardRock, heavyMetal }, 4);
            Track ot16 = new Track("Love at First Feel", 192, "Some audio url", oam3, new HashSet<Genre>() { rock, hardRock, heavyMetal }, 3);
            Track ot17 = new Track("Rocker", 171, "Some audio url", oam3, new HashSet<Genre>() { rock, hardRock, heavyMetal }, 4);
            Track ot18 = new Track("Ride On", 350, "Some audio url", oam3, new HashSet<Genre>() { rock, hardRock, heavyMetal }, 3);

            oam3.Tracks.Add(ot13);
            oam3.Tracks.Add(ot14);
            oam3.Tracks.Add(ot15);
            oam3.Tracks.Add(ot16);
            oam3.Tracks.Add(ot17);
            oam3.Tracks.Add(ot18);
            oa1.Albums.Add(oam3);
            #endregion

            #region Damian Marley
            Artist oa2 = new Artist("Damian Marley", Country.Jamaica, "Some artist photo url", new DateTime(1992, 1, 1), new HashSet<Genre>() { reggae, rnb, soul, hipHop, rap });

            Album oam4 = new Album("Welcome to Jamrock", new DateTime(2005, 9, 12), "Some cover photo url", oa2, new HashSet<Genre>() { reggae, rnb, hipHop, rap });
            Album oam5 = new Album("Mr.Marley", new DateTime(1996, 9, 9), "Some cover photo url", oa2, new HashSet<Genre>() { reggae, rnb, hipHop, rap });
            Album oam6 = new Album("Halfway Tree", new DateTime(2001, 9, 11), "Some cover photo url", oa2, new HashSet<Genre>() { reggae, rnb, soul, hipHop, rap });

            Track ot19 = new Track("Confrontation", 329, "Some audio url", oam4, new HashSet<Genre>() { reggae, rnb, hipHop, rap }, 4);
            Track ot20 = new Track("Welcome to Jamrock", 214, "Some audio url", oam4, new HashSet<Genre>() { reggae, rnb, hipHop, rap }, 4);
            Track ot21 = new Track("All Night", 210, "Some audio url", oam4, new HashSet<Genre>() { reggae, rnb, hipHop, rap }, 5);
            Track ot22 = new Track("Pimpa's Paradise", 304, "Some audio url", oam4, new HashSet<Genre>() { reggae, rnb, hipHop, rap }, 3);
            Track ot23 = new Track("There for You", 241, "Some audio url", oam4, new HashSet<Genre>() { reggae, rnb, hipHop, rap }, 3);
            Track ot24 = new Track("Beautiful", 248, "Some audio url", oam4, new HashSet<Genre>() { reggae, rnb, hipHop, rap }, 2);

            oam4.Tracks.Add(ot19);
            oam4.Tracks.Add(ot20);
            oam4.Tracks.Add(ot21);
            oam4.Tracks.Add(ot22);
            oam4.Tracks.Add(ot23);
            oam4.Tracks.Add(ot24);
            oa2.Albums.Add(oam4);

            Track ot25 = new Track("Trouble", 335, "Some audio url", oam5, new HashSet<Genre>() { reggae, rnb, hipHop, rap }, 5);
            Track ot26 = new Track("Party Time", 252, "Some audio url", oam5, new HashSet<Genre>() { reggae, rnb, hipHop, rap }, 3);
            Track ot27 = new Track("Keep on Grooving", 276, "Some audio url", oam5, new HashSet<Genre>() { reggae, rnb, hipHop, rap }, 3);
            Track ot28 = new Track("Love and Unity", 244, "Some audio url", oam5, new HashSet<Genre>() { reggae, rnb, hipHop, rap }, 4);
            Track ot29 = new Track("Old War Chant", 248, "Some audio url", oam5, new HashSet<Genre>() { reggae, rnb, hipHop, rap }, 4);
            Track ot30 = new Track("Kingston 12", 214, "Some audio url", oam5, new HashSet<Genre>() { reggae, rnb, hipHop, rap }, 5);

            oam5.Tracks.Add(ot25);
            oam5.Tracks.Add(ot26);
            oam5.Tracks.Add(ot27);
            oam5.Tracks.Add(ot28);
            oam5.Tracks.Add(ot29);
            oam5.Tracks.Add(ot30);
            oa2.Albums.Add(oam5);

            Track ot31 = new Track("Educated Fools", 317, "Some audio url", oam6, new HashSet<Genre>() { reggae, rnb, soul, hipHop, rap }, 2);
            Track ot32 = new Track("It Was Written", 367, "Some audio url", oam6, new HashSet<Genre>() { reggae, rnb, soul, hipHop, rap }, 3);
            Track ot33 = new Track("Still Searchin'", 305, "Some audio url", oam6, new HashSet<Genre>() { reggae, rnb, soul, hipHop, rap }, 3);
            Track ot34 = new Track("Mi Blenda", 281, "Some audio url", oam6, new HashSet<Genre>() { reggae, rnb, soul, hipHop, rap }, 5);
            Track ot35 = new Track("More Justice", 215, "Some audio url", oam6, new HashSet<Genre>() { reggae, rnb, soul, hipHop, rap }, 4);
            Track ot36 = new Track("Catch a Fire", 291, "Some audio url", oam6, new HashSet<Genre>() { reggae, rnb, soul, hipHop, rap }, 4);

            oam6.Tracks.Add(ot31);
            oam6.Tracks.Add(ot32);
            oam6.Tracks.Add(ot33);
            oam6.Tracks.Add(ot34);
            oam6.Tracks.Add(ot35);
            oam6.Tracks.Add(ot36);
            oa2.Albums.Add(oam6);
            #endregion

            #region Creedence Clearwater Revival
            Artist oa3 = new Artist("Creedence Clearwater Revival", Country.USA, "Some artist photo url", new DateTime(1967, 1, 1), new HashSet<Genre>() { rock, country, blues, folk });

            Album oam7 = new Album("Cosmo's Factory", new DateTime(1970, 7, 1), "Some cover photo url", oa3, new HashSet<Genre>() { rock, country, blues, folk });
            Album oam8 = new Album("Pendulum", new DateTime(1970, 2, 9), "Some cover photo url", oa3, new HashSet<Genre>() { rock, country, blues, folk });
            Album oam9 = new Album("Mardi Gras", new DateTime(1972, 4, 11), "Some cover photo url", oa3, new HashSet<Genre>() { rock, country, blues, folk });

            Track ot37 = new Track("Ramble Tamble", 432, "Some audio url", oam7, new HashSet<Genre>() { rock, country, blues, folk }, 4);
            Track ot38 = new Track("Travelin Band", 127, "Some audio url", oam7, new HashSet<Genre>() { rock, country, blues, folk }, 4);
            Track ot39 = new Track("Lookin' out My Back Door", 151, "Some audio url", oam7, new HashSet<Genre>() { rock, country, blues, folk }, 4);
            Track ot40 = new Track("Up Around the Bend", 162, "Some audio url", oam7, new HashSet<Genre>() { rock, country, blues, folk }, 5);
            Track ot41 = new Track("Before You Accuse Me", 207, "Some audio url", oam7, new HashSet<Genre>() { rock, country, blues, folk }, 4);
            Track ot42 = new Track("Ooby Dooby", 128, "Some audio url", oam7, new HashSet<Genre>() { rock, country, blues, folk }, 5);

            oam7.Tracks.Add(ot37);
            oam7.Tracks.Add(ot38);
            oam7.Tracks.Add(ot39);
            oam7.Tracks.Add(ot40);
            oam7.Tracks.Add(ot41);
            oam7.Tracks.Add(ot42);
            oa3.Albums.Add(oam7);

            Track ot43 = new Track("Pegan Baby", 385, "Some audio url", oam8, new HashSet<Genre>() { rock, country, blues, folk }, 5);
            Track ot44 = new Track("Chameleon", 200, "Some audio url", oam8, new HashSet<Genre>() { rock, country, blues, folk }, 3);
            Track ot45 = new Track("Hey Tonight", 163, "Some audio url", oam8, new HashSet<Genre>() { rock, country, blues, folk }, 3);
            Track ot46 = new Track("Have You Ever Seen The Rain", 160, "Some audio url", oam8, new HashSet<Genre>() { rock, country, blues, folk }, 5);
            Track ot47 = new Track("Born to Move", 341, "Some audio url", oam8, new HashSet<Genre>() { rock, country, blues, folk }, 4);
            Track ot48 = new Track("Sailor's Lament", 228, "Some audio url", oam8, new HashSet<Genre>() { rock, country, blues, folk }, 3);

            oam8.Tracks.Add(ot43);
            oam8.Tracks.Add(ot44);
            oam8.Tracks.Add(ot45);
            oam8.Tracks.Add(ot46);
            oam8.Tracks.Add(ot47);
            oam8.Tracks.Add(ot48);
            oa3.Albums.Add(oam8);

            Track ot49 = new Track("Lookin' For A Reason", 205, "Some audio url", oam9, new HashSet<Genre>() { rock, country, blues, folk }, 5);
            Track ot50 = new Track("Need Someone to Hold", 184, "Some audio url", oam9, new HashSet<Genre>() { rock, country, blues, folk }, 4);
            Track ot51 = new Track("Someday Never Comes", 241, "Some audio url", oam9, new HashSet<Genre>() { rock, country, blues, folk }, 3);
            Track ot52 = new Track("Sail Away", 153, "Some audio url", oam9, new HashSet<Genre>() { rock, country, blues, folk }, 4);
            Track ot53 = new Track("Take It Like a Friend", 182, "Some audio url", oam9, new HashSet<Genre>() { rock, country, blues, folk }, 2);
            Track ot54 = new Track("Hello Mary Lou", 135, "Some audio url", oam9, new HashSet<Genre>() { rock, country, blues, folk }, 3);

            oam9.Tracks.Add(ot49);
            oam9.Tracks.Add(ot50);
            oam9.Tracks.Add(ot51);
            oam9.Tracks.Add(ot52);
            oam9.Tracks.Add(ot53);
            oam9.Tracks.Add(ot54);
            oa3.Albums.Add(oam9);
            #endregion


            #endregion

            return new List<Artist> { oa1, oa2, oa3 };
        }
    }
}
