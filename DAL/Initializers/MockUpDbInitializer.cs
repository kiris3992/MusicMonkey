using DAL.Initializers.TeamsSeeding;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;

namespace DAL.Initializers
{
    public class MockUpDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var teamSeeder = new TeamSeeder().GetSeed();

            context.Genres.AddOrUpdate(teamSeeder.genres.ToArray());
            foreach(var seeder in teamSeeder.seeders)
            {
                try
                {
                    context.Artists.AddOrUpdate(seeder.GetArtists().ToArray());
                }
                catch(Exception ex)
                {
                    Debug.WriteLine($"{seeder.GetType().Name} : {ex.Message}");
                }
            }

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
