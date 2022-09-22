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

            Subscription free = new Subscription() { Name = "Free", Price = 0 };
            Subscription silver = new Subscription() { Name = "Silver", Price = 29.99 };
            Subscription gold = new Subscription() { Name = "Gold", Price = 49.99 };
            context.Subscriptions.AddOrUpdate(free,silver,gold);

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
