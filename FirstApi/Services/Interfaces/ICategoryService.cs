using System.Linq.Expressions;

namespace FirstApi.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task<List<Category>> GetAllAsync(int page,int take);
        public Task<Category> GetByIdAsync (int id);
        public Task<int> CreateAsync ( CreateCategoryDTO categoryDTO);
        public Task Delete(int id);
        public Task Update(int id,Category category);


        public Task<bool> AnyAsync(Expression<Func<object, bool>> expression);

  
    }
}
