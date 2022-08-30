using RepositoryService.Core;
using RepositoryService.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryService.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        public IArtistRepository Artists => throw new NotImplementedException();

        public IAlbumRepository Albums => throw new NotImplementedException();

        public ITrackRepository Tracks => throw new NotImplementedException();

        public int Complete()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
