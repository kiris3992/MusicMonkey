using DAL.Initializers.TeamsSeeding;
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


            context.Genres.AddOrUpdate(x => x.Type, blues, chillstep, classical, country, dance, disco, electronic, folk, hipHop, house, instrumental, jazz, kid, latin, metal, opera, pop, progressive, punk, rap, reggae, rnb, rock, soul, techno, traditional, trance, trap, hardRock, heavyMetal, grunge);


            List<ITeamSeeder> teamSeeders = new List<ITeamSeeder> { new Seed_Aggelos(), new Seed_Kiris(), new Seed_Orestis(), new Seed_Panos(), new Seed_Spyros() };
            foreach (var seeder in teamSeeders)
            {
                var artists = seeder.GetArtists();

                if (artists != null)
                {
                    context.Artists.AddOrUpdate(x => x.Name, artists.ToArray());

                }
            }

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
