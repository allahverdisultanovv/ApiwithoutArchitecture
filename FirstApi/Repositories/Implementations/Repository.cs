using FirstApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Cryptography.Xml;

namespace FirstApi.Repositories.Implementations
{
    public class Repository<T>  : IRepository<T> where T : BaseEntity, new()
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _table;
        public Repository(AppDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }
        public IQueryable<T> GetAll()
        {
            return _table;
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _table.FirstOrDefaultAsync(c => c.Id == id);
        }
        public void Update(T entity)
        {
            _table.Update(entity);
        }
        public async Task AddAsync(T entity)
        {
            await _table.AddAsync(entity);
        }
        public void Delete(T entity)
        {
            _table.Remove(entity);
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<object, bool>> expression)
        {
            return await _table.AnyAsync(expression);
        }
    }
}
