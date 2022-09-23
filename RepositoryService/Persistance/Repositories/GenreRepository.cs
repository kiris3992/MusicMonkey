using DAL;
using Entities.Models;
using RepositoryService.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryService.Persistance.Repositories
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(ApplicationDbContext context) : base(context)
        {
            
        }

        public IEnumerable<object> GetGenres()
        {
            return db.Genres.Select(g => new { g.Id, g.Type });
        }

        public IEnumerable<Genre> GetGenresWithEverything()
        {
            return db.Genres
                .Include("Artists")
                .Include("Albums")
                .Include("Tracks")
                .ToList();
        }
    }
}
