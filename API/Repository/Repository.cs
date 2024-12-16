using Data.AppicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<object>> GetAll_table();
        Task  CreateAll<T>(T entity) where T : class;   
        Task EditAll<T>(T entity) where T : class;
        Task DeketeAll<T>(int id) where T : class;
        Task<object> GetById<T>(int id) where T : class;  
    }

    public class Repository : IRepository
    {
        private readonly AppDbContext _db;

        public Repository(AppDbContext db)
        {
            _db = db;
        }

        public async Task CreateAll<T>(T entity) where T : class
        {
            await _db.Set<T>().AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public  async Task DeketeAll<T>(int id) where T : class
        {
            var entity = await _db.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _db.Set<T>().Remove(entity);
                await _db.SaveChangesAsync();
            }
        }

        public async Task EditAll<T>(T entity) where T : class
        {
             _db.Set<T>().Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<object>> GetAll_table()
        {
            return await _db.Products
                .Include(c => c.Categories)
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Price,    
                    p.Quantity,
                    p.Date,
                    p.Description,
                    CategoryName = string.Join(", ", p.Categories.Select(x => x.CateGoryName)) // kết hợp các danh mục thành một chuỗi
                }).ToListAsync();
        }

        public async Task<object> GetById<T>(int id) where T : class
        {
            var entity = await _db.Set<T>().FindAsync(id);
            return entity;
        }
    }
}
