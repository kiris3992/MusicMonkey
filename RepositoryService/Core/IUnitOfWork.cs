using RepositoryService.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryService.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IArtistRepository Artists { get; }
        IAlbumRepository Albums { get; }
        ITrackRepository Tracks { get; }
        IGenreRepository Genres { get; }
        int Complete();
    }
}
