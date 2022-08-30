using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryService.Core
{
    public interface IGenericRepository<T> where T : MusicEntity
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Create(T entity);
        void Update(T entity);
        void DeleteById(object id);
        void DeleteAll();
        void Save();
    }
}
