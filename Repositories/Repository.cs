using lab_app_web_servidor_istea.Database;
using lab_app_web_servidor_istea.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lab_app_web_servidor_istea.Repositories
{
  public class Repository<T>(RestauranteContext context) : IRepository<T> where T : class
  {
    protected readonly RestauranteContext _context = context;

    public async Task Add(T entity)
    {
      await _context.Set<T>().AddAsync(entity);
    }

    public void Delete(T entity)
    {
      _context.Set<T>().Remove(entity);
    }

    public void Edit(T entity)
    {
      _context.Set<T>().Update(entity);
    }

    public async Task<List<T>> GetAll()
    {
      return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetId(int id)
    {
      return await _context.Set<T>().FindAsync(id);
    }
  }
}
