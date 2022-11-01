using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Infrastructure.Interfaces
{
    public interface IRepo<T> where T : class
    {
        T Insert(T entity);
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Update(T entity);

        void Delete(object id);
    }
}
