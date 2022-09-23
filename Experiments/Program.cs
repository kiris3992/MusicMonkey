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
using Stripe;

namespace Experiments
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            UnitOfWork unit = new UnitOfWork(db);

            var genres = GetTracks(unit);
            foreach (var genre in genres)
            {
                Console.WriteLine(genre.Type);
                foreach (var artist in genre.Artists)
                {
                    Console.WriteLine($"{artist.Name, 15}");
                }

            }

        }

        private static Dictionary<int, double> MostFamousArtistsDTOModel(List<Artist> artists)
        {
            Dictionary<int, double> artistTrackAverage = new Dictionary<int, double>();

            foreach (var artist in artists)
            {
                List<double> PopAvgOfAllAlbums = new List<double>();
                double PopAvgByArtist = 0;


                foreach (var album in artist.Albums)
                {
                    int PopByAlbum = 0;
                    double PopAvgByAlbum = 0;

                    foreach (var track in album.Tracks)
                    {
                        PopByAlbum = PopByAlbum + track.Popularity;
                    }

                    PopAvgByAlbum = PopByAlbum / album.Tracks.Count;
                    PopAvgOfAllAlbums.Add(PopAvgByAlbum);
                }

                PopAvgByArtist = PopAvgOfAllAlbums.Sum() / PopAvgOfAllAlbums.Count;
                artistTrackAverage.Add(artist.Id, Math.Round(PopAvgByArtist, 1));
            }

            return artistTrackAverage;
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

        private static IEnumerable<Genre> GetTracks(UnitOfWork unit) => unit.Genres.GetGenresWithEverything();
    }
}
