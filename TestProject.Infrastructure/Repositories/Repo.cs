global using Microsoft.EntityFrameworkCore;
global using TestProject.Data;
global using TestProject.Infrastructure.Interfaces;

namespace TestProject.Infrastructure.Repositories
{
    public class Repo<T> : IRepo<T> where T : class
    {
        private readonly TestDbContext _db;
        private DbSet<T> entities;

        public Repo(TestDbContext db)
        {
            _db = db;
            entities = db.Set<T>();
        }
        public T Insert(T entity)
        {
            entities.Add(entity);
            _db.SaveChanges();
            return entity;
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();

        }
        public T GetById(object id)
        {
            return entities.Find(id);
        }

        public void Update(T entity)
        {
            entities.Update(entity);
            _db.SaveChanges();
        }
        public void Delete(object id)
        {
            T existing = entities.Find(id);
            entities.Remove(existing);
            _db.SaveChanges();
        }
    }
}
