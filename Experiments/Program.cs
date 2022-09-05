using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities.Enums;


namespace Experiments
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            var artists = db.Artists
                .Include(x => x.ArtistGenres)
                .ToList();

            foreach (var artist in artists)
            {
                Console.WriteLine(artist.Name);
                foreach (var genre in artist.ArtistGenres)
                {
                    Console.WriteLine($"{genre.Type, 15}");
                }
            }
        }
    }
}
