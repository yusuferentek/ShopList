using RepositoryLesson.Interfaces;
using RepositoryLesson.Models;
using System.Linq.Expressions;

namespace RepositoryLesson.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ShoppingDbContext _context;
        public GenericRepository(ShoppingDbContext context)
        {
            _context = context;
        }

        public async void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
            //sor neden set?
        }

        public T getByID(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public async void Update(T entity, int id)
        {
            T? entity2 = await _context.Set<T>().FindAsync(id);
            if (entity2 != null)
            {
                _context.Entry(entity2).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
