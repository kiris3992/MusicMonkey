using DAL.Initializers.TeamsSeeding;
using Entities.Enums;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;

namespace DAL.Initializers
{
    public class MockUpDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            TeamGenres Genres = new TeamGenres();
            var (seeders, genres) = new TeamSeeder().Initialize(Genres);

            context.Genres.AddOrUpdate(o => o.Type, genres.ToArray());
            foreach (var seeder in seeders)
            {
                try
                {
                    context.Artists.AddOrUpdate(seeder.GetArtists(Genres).ToArray());
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"{seeder.GetType().Name} : {ex.Message}");
                }
            }

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
