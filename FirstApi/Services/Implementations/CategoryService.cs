using FirstApi.Repositories.Interfaces;
using FirstApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FirstApi.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository _repository;

        public CategoryService(IRepository repository)
        {
            _repository = repository;
        }

     

        public async Task<List<Category>> GetAllAsync(int page,int take)
        {
            var categories = await _repository.GetAll().ToListAsync();
            return categories;
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            Category category = await _repository.GetByIdAsync(id);
            if (category == null) throw new Exception("SALAM. ERROR .TAPIlADI");
            return category;
        }
        public async Task<int> CreateAsync(CreateCategoryDTO categoryDTO)
        {
            Category category = new Category()
            {
                Name = categoryDTO.Name,
            };
            await _repository.AddAsync(category);
            return await _repository.SaveChangesAsync();

        }

        public async Task<bool> AnyAsync(Expression<Func<object, bool>> expression)
        {
            return await _repository.AnyAsync(expression);
        }

        public async Task Delete(int id)
        {
            Category category =await _repository.GetByIdAsync(id);
            _repository.Delete(category);
            await _repository.SaveChangesAsync();
        }

        public async Task Update(int id, Category category)
        {
            _repository.Update(category);
            await _repository.SaveChangesAsync();
        }
    }
}
