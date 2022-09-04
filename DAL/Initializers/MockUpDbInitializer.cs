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
            #region ACDC
            #region Seeding Artist
            Artist oa1 = new Artist("AC DC", Country.Australia, "Some artist photo Url", new DateTime(1973, 1, 1), new List<Genre>() { Genre.Rock, Genre.Hard_Rock, Genre.Heavy_Metal });
            #endregion

            #region Seeding Albums
            Album oam1 = new Album("Highway to Hell", new DateTime(1979, 1, 1), "Some cover photo url", new List<Genre>() { Genre.Rock, Genre.Hard_Rock, Genre.Heavy_Metal }, oa1);
            Album oam2 = new Album("Back in Black", new DateTime(1980, 7, 21), "Some cover photo url", new List<Genre>() { Genre.Rock, Genre.Hard_Rock, Genre.Heavy_Metal }, oa1);
            Album oam3 = new Album("Dirty Deeds Done Dirt Cheap", new DateTime(1976, 9, 20), "Some cover photo url", new List<Genre>() { Genre.Rock, Genre.Hard_Rock, Genre.Heavy_Metal }, oa1);

            #endregion

            #region Seeding Tracks
            Track ot1 = new Track("Highway to Hell", 208, "Some audio url", new List<Genre>() { Genre.Rock, Genre.Hard_Rock, Genre.Heavy_Metal }, oam1);
            Track ot2 = new Track("if You Want Blood", 277, "Some audio url", new List<Genre>() { Genre.Rock, Genre.Hard_Rock, Genre.Heavy_Metal }, oam1);
            Track ot3 = new Track("Get it Hot", 154, "Some audio url", new List<Genre>() { Genre.Rock, Genre.Hard_Rock, Genre.Heavy_Metal }, oam1);
            Track ot4 = new Track("Love Hungry Man", 257, "Some audio url", new List<Genre>() { Genre.Rock, Genre.Hard_Rock, Genre.Heavy_Metal }, oam1);
            Track ot5 = new Track("Night Prowler", 376, "Some audio url", new List<Genre>() { Genre.Rock, Genre.Hard_Rock, Genre.Heavy_Metal }, oam1);
            Track ot6 = new Track("Touch to Much", 246, "Some audio url", new List<Genre>() { Genre.Rock, Genre.Hard_Rock, Genre.Heavy_Metal }, oam1);

            oam1.Tracks.Add(ot1);
            oam1.Tracks.Add(ot2);
            oam1.Tracks.Add(ot3);
            oam1.Tracks.Add(ot4);
            oam1.Tracks.Add(ot5);
            oam1.Tracks.Add(ot6);
            oa1.Albums.Add(oam1);

            Track ot7 = new Track("Hells Bells", 312, "Some audio url", new List<Genre>() { Genre.Rock, Genre.Hard_Rock, Genre.Heavy_Metal }, oam2);
            Track ot8 = new Track("Let Me Put My Love Into You", 215, "Some audio url", new List<Genre>() { Genre.Rock, Genre.Hard_Rock, Genre.Heavy_Metal }, oam2);
            Track ot9 = new Track("You Shook Me All Night Long", 210, "Some audio url", new List<Genre>() { Genre.Rock, Genre.Hard_Rock, Genre.Heavy_Metal }, oam2);
            Track ot10 = new Track("Shoot to Thrill", 318, "Some audio url", new List<Genre>() { Genre.Rock, Genre.Hard_Rock, Genre.Heavy_Metal }, oam2);
            Track ot11 = new Track("Back in Black", 256, "Some audio url", new List<Genre>() { Genre.Rock, Genre.Hard_Rock, Genre.Heavy_Metal }, oam2);
            Track ot12 = new Track("Givin The Dog A Bone", 212, "Some audio url", new List<Genre>() { Genre.Rock, Genre.Hard_Rock, Genre.Heavy_Metal }, oam2);

            oam2.Tracks.Add(ot7);
            oam2.Tracks.Add(ot8);
            oam2.Tracks.Add(ot9);
            oam2.Tracks.Add(ot10);
            oam2.Tracks.Add(ot11);
            oam2.Tracks.Add(ot12);
            oa1.Albums.Add(oam2);

            Track ot13 = new Track("Dirty Deeds Done Dirt Cheap", 232, "Some audio url", new List<Genre>() { Genre.Rock, Genre.Hard_Rock, Genre.Heavy_Metal }, oam3);
            Track ot14 = new Track("Big Balls", 159, "Some audio url", new List<Genre>() { Genre.Rock, Genre.Hard_Rock, Genre.Heavy_Metal }, oam3);
            Track ot15 = new Track("Problem Child", 346, "Some audio url", new List<Genre>() { Genre.Rock, Genre.Hard_Rock, Genre.Heavy_Metal }, oam3);
            Track ot16 = new Track("Love at First Feel", 192, "Some audio url", new List<Genre>() { Genre.Rock, Genre.Hard_Rock, Genre.Heavy_Metal }, oam3);
            Track ot17 = new Track("Rocker", 171, "Some audio url", new List<Genre>() { Genre.Rock, Genre.Hard_Rock, Genre.Heavy_Metal }, oam3);
            Track ot18 = new Track("Dirty Deeds Done Dirt Cheap", 232, "Some audio url", new List<Genre>() { Genre.Rock, Genre.Hard_Rock, Genre.Heavy_Metal }, oam3);

            oam3.Tracks.Add(ot13);
            oam3.Tracks.Add(ot14);
            oam3.Tracks.Add(ot15);
            oam3.Tracks.Add(ot16);
            oam3.Tracks.Add(ot17);
            oam3.Tracks.Add(ot18);
            #endregion
            #endregion
            #region Damian Marley
            Artist oa2 = new Artist("Damian Marley", Country.Jamaica, "Some artist photo url", new DateTime(1992, 1, 1), new List<Genre>() { Genre.Reggae, Genre.HipHop, Genre.Rnb, Genre.Soul});

            Album oam4 = new Album("Welcome to Jamrock", new DateTime(2005, 9, 12), "Some cover photo url", new List<Genre>() { Genre.Reggae, Genre.HipHop, Genre.Rnb, Genre.Soul }, oa2);
            Album oam5 = new Album("Mr.Marley", new DateTime(1996, 9, 9), "Some cover photo url", new List<Genre>() { Genre.Reggae, Genre.HipHop }, oa2);
            Album oam6 = new Album("Halfway Tree", new DateTime(2001, 9, 11), "Some cover photo url", new List<Genre>() { Genre.Reggae, Genre.HipHop, Genre.Rnb, Genre.Soul }, oa2);

            Track ot19 = new Track();
            #endregion

            context.Artists.AddOrUpdate(oa1);
            context.Albums.AddOrUpdate(oam1, oam2, oam2);
            context.Tracks.AddOrUpdate(ot1, ot2, ot3, ot4, ot5, ot6, ot7, ot8, ot9, ot10, ot11, ot12, ot13, ot14, ot15, ot16, ot17, ot18);
            context.SaveChanges();
            #endregion

            base.Seed(context);
        }
    }
}
