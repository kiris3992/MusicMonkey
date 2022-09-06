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

        public IEnumerable<Artist> GetArtistsWithEverything()
        {
            db.Tracks
                .Include(x => x.TrackGenres)
                .Include(x => x.Album)
                .ToList();

            db.Albums
                .Include(x => x.AlbumGenres)
                .Include(x => x.Tracks)
                .ToList();

            return db.Artists
                .Include(x => x.Albums)
                .Include(x => x.ArtistGenres)
                .ToList();
        }
    }
}
