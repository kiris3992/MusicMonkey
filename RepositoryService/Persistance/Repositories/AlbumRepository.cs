using DAL;
using Entities.Models;
using RepositoryService.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryService.Persistance.Repositories
{
    public class AlbumRepository: GenericRepository<Album>, IAlbumRepository
    {
        public AlbumRepository(ApplicationDbContext context) : base(context)
        {

        }

        public Album GetAlbumByIdWithEverything(int? id)
        {
            return db.Albums
                .Include("AlbumGenres")
                .Include("Tracks.TrackGenres")
                .Include("Artist.ArtistGenres")
                .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Album> GetAlbumsWithEverything()
        {
            return db.Albums
                .Include("AlbumGenres")
                .Include("Tracks.TrackGenres")
                .Include("Artist.ArtistGenres")
                .ToList();
        }
    }
}
