using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Initializers.TeamsSeeding
{
    public class TeamSeeder
    {
        public (List<ITeamSeeder> seeders, List<Genre> genres) GetSeed()
        {
            List<ITeamSeeder> teamSeeders = new List<ITeamSeeder> { new Seed_Aggelos(), new Seed_Kiris(), new Seed_Orestis(), new Seed_Panos(), new Seed_Spyros() };

            var bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
            var fieldValues = teamSeeders[0].GetType()
                                 .GetFields(bindingFlags)
                                 .Where(field => field.FieldType.Name == "Genre")
                                 .Select(o => (Genre)o.GetValue(teamSeeders[0]))
                                 .ToList();

            return (teamSeeders, fieldValues);
        }
    }
}
