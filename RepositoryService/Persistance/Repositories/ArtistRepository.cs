using DAL;
using Entities.Models;
using RepositoryService.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace RepositoryService.Persistance.Repositories
{
    public class ArtistRepository: GenericRepository<Artist>, IArtistRepository
    {
        public ArtistRepository(ApplicationDbContext context):base(context)
        {

        }

        public Artist GetArtistByIdWithEverything(int? id)
        {
            return db.Artists
                .Include("ArtistGenres")
                .Include("Albums.AlbumGenres")
                .Include("Albums.Tracks.TrackGenres")
                .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Artist> GetArtistsWithEverything()
        {
            return db.Artists
                .Include("ArtistGenres")
                .Include("Albums.AlbumGenres")
                .Include("Albums.Tracks.TrackGenres")
                .ToList();
        }
    }
}
