using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WMS.Domain.Interfaces;
using WMS.Infrastructure.Data;

namespace WMS.Infrastructure.Repositories {
  public class Repository<T> : IRepository<T> where T : class {
    protected readonly ApplicationDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public Repository(ApplicationDbContext context) {
      _context = context;
      _dbSet = context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes) {
      IQueryable<T> query = _dbSet;
      foreach (var include in includes) {
        query = query.Include(include);
      }
      return await query.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id) {
      return await _dbSet.FindAsync(id);
    }

    public async Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes) {
      IQueryable<T> query = _dbSet;
      foreach (var include in includes) {
        query = query.Include(include);
      }
      return await query.FirstOrDefaultAsync(expression);
    }

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes) {
      IQueryable<T> query = _dbSet;
      foreach (var include in includes) {
        query = query.Include(include);
      }
      return await query.Where(expression).ToListAsync();
    }

    public async Task AddAsync(T entity) {
      await _dbSet.AddAsync(entity);
    }

    public void Update(T entity) {
      _dbSet.Update(entity);
    }

    public void Delete(T entity) {
      _dbSet.Remove(entity);
    }

    public async Task SaveChangesAsync() {
      await _context.SaveChangesAsync();
    }
  }
}