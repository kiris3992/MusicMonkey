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
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(ApplicationDbContext context) : base(context)
        {
            
        }
        public IEnumerable<Genre> GetGenresWithEverything()
        {
            return db.Genres
                .Include("Tracks")
                .Include("Albums")
                .Include("Artists")
                .ToList();
        }
    }
}
