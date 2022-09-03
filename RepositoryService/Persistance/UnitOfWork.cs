using DAL;
using RepositoryService.Core;
using RepositoryService.Core.Repositories;
using RepositoryService.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryService.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            context = dbContext;
            Artists = new ArtistRepository(context);
            Albums = new AlbumRepository(context);
            Tracks = new TrackRepository(context);
        }
        public IArtistRepository Artists { get; private set; }

        public IAlbumRepository Albums { get; private set; }

        public ITrackRepository Tracks { get; private set; }

        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
