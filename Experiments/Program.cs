
using System;
using System.Collections.Generic;
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


            Console.WriteLine("Experiments Start");

            ApplicationDbContext db = new ApplicationDbContext();

            var artists = db.Artists
                .Include("Albums")
                .Include("Albums.Tracks")
                .ToList();

            foreach (var artist in artists)
            {
                Console.WriteLine(artist.Name);

                foreach(var album in artist.Albums)
                {
                    Console.WriteLine($"\t{album.Title}");

                    foreach(var track in album.Tracks)
                    {
                        Console.WriteLine($"\t\t{track.Title}");
                    }
                }
            }


            Console.WriteLine("Experiments End");
            Console.ReadKey();

        }
    }
}
