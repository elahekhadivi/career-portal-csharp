using Microsoft.EntityFrameworkCore;

using CareerCloud.DataAccessLayer;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class EFGenericRepository<T> : IDataRepository<T> where T : class
    {
        private readonly CareerCloudContext _context;
        public EFGenericRepository() => _context = new CareerCloudContext();
       
        public void Add(params T[] items)
        {
            foreach(T item in items)
            {
                _context.Add<T>(item);
            }
            _context.SaveChanges();
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            return  _context.Set<T>().ToList<T>(); 
        }

        public IList<T> GetList(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            return _context.Set<T>().Where(where).ToList<T>();
        }

        public T GetSingle(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            return _context.Set<T>().Where(where).SingleOrDefault<T>();
        }

        public void Remove(params T[] items)
        {
            foreach (var item in items)
            {
                _context.Remove<T>(item);
            }
            _context.SaveChanges();
        }

        public void Update(params T[] items)
        {
            foreach (var item in items)
            {
                _context.Update<T>(item);
            }
            _context.SaveChanges();
        }
    }

}
