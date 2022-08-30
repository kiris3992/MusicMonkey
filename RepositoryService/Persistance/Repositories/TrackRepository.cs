using Entities.Models;
using RepositoryService.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryService.Persistance.Repositories
{
    public class TrackRepository:GenericRepository<Track>, ITrackRepository
    {
    }
}
