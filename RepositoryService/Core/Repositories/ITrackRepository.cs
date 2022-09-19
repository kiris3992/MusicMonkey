using Entities.Models;
using MusicMonkeyWebApp.Models.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryService.Core.Repositories
{
    public interface ITrackRepository : IGenericRepository<Track>
    {
        IEnumerable<Track> GetTracksWithEverything(PagingModel pagingModel = null);
        Track GetTrackByIdWithEverything(int? id);
    }
}
