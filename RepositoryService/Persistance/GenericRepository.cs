using DAL;
using Entities.Models;
using RepositoryService.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryService.Persistance
{
    public class GenericRepository<T> : IGenericRepository<T> where T : MusicEntity
    {
        public ApplicationDbContext db;
        public DbSet<T> table;

        public GenericRepository(ApplicationDbContext context)
        {
            db = context;
            table = db.Set<T>();
        }
        public void Create(T entity) => table.Add(entity);
        

        public void DeleteAll() => table.RemoveRange(GetAll());
       

        public void DeleteById(object id) => table.Remove(GetById(id));


        public IEnumerable<T> GetAll() => table.ToList();
       

        public T GetById(object id)=> table.Find(id);
      

        public void Save()=> db.SaveChanges();
       

        public void Update(T entity)
        {
            table.Attach(entity);
            db.Entry(entity).State= EntityState.Modified;
        }
    }
}
