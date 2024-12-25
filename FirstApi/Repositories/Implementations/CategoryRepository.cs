using FirstApi.Repositories.Interfaces;

namespace FirstApi.Repositories.Implementations
{
    public class CategoryRepository:Repository<Category>,ICategoryRepository
    {
        public CategoryRepository(AppDbContext context):base(context) { }
       
    }
}
