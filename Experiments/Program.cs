using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities.Enums;
using Entities.Models;
using RepositoryService.Persistance;

namespace Experiments
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            GetAllGenres(db);
        }

        private static void GetAllArtists(ApplicationDbContext context)
        {

            var tracks = context.Tracks
                .Include(x => x.TrackGenres)
                .ToList();

            var albums = context.Albums
                .Include(x => x.AlbumGenres)
                .Include(x => x.Tracks)
                .ToList();

            var artists = context.Artists
                .Include(x => x.ArtistGenres)
                .Include(x => x.Albums)
                .ToList();

            foreach (var artist in artists)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Artist: ");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{artist.Name,15}");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Genres: ");
                Console.ResetColor();
                foreach (var genre in artist.ArtistGenres)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{genre.Type,15}");
                    Console.ResetColor();
                }

                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Albums: ");
                Console.ResetColor();
                foreach (var album in artist.Albums)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{album.Title,20}");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{"Tracks: ",25}");
                    Console.ResetColor();
                    foreach (var track in album.Tracks)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"{track.Title,40}");
                        Console.ResetColor();
                    }
                    Console.WriteLine();
                }
            }
        }

        private static void GetAllGenres(ApplicationDbContext context)
        {
            var genres = context.Genres
                .Include(x => x.Albums)
                .Include(x => x.Artists)
                .Include(x => x.Tracks)
                .ToList();

            foreach (var genre in genres)
            {
                Console.WriteLine($"Genre: {genre.Type}");
            }
            Console.WriteLine(genres.Count);
        }
    }
}
