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
    public class AlbumRepository: GenericRepository<Album>, IAlbumRepository
    {
        public AlbumRepository(ApplicationDbContext context) : base(context)
        {

        }
        public IEnumerable<Album> GetAlbumsWithEverything()
        {
            db.Tracks
                .Include(o => o.TrackGenres)
                .Include(o => o.Album)
                .ToList();

            return db.Albums
                .Include(o => o.AlbumGenres)
                .Include(o => o.Tracks)
                .ToList();
        }
    }
}
