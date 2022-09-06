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
    public class TrackRepository:GenericRepository<Track>, ITrackRepository
    {
        public TrackRepository(ApplicationDbContext context) : base(context)
        {

        }

        public IEnumerable<Track> GetTracksWithEverything()
        {
            return db.Tracks
                .Include(x => x.TrackGenres)
                .Include(x => x.Album)
                .ToList();
        }
    }
}
