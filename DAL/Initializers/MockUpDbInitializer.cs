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
            #region Seeding Artists
            Artist oa1 = new Artist("AC DC", Country.Australia, "Some artist Url", new DateTime(1973, 1, 1), new List<Genre>() { Genre.Rock, Genre.Hard_Rock, Genre.Heavy_Metal });
            #endregion

            #region Seeding Albums
            Album oam1 = new Album("Highway to Hell", new DateTime(1979, 1, 1), "Some cover url", new List<Genre>() { Genre.Rock, Genre.Hard_Rock, Genre.Heavy_Metal }, oa1);

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
            #endregion

            context.Artists.AddOrUpdate(oa1);
            context.Albums.AddOrUpdate(oam1);
            context.Tracks.AddOrUpdate(ot1, ot2, ot3, ot4, ot5, ot6);
            context.SaveChanges();
            #endregion

            base.Seed(context);
        }
    }
}
