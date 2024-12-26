using FirstApi.DTOs.Color;
using System.Linq.Expressions;

namespace FirstApi.Services.Interfaces
{
    public interface IColorService
    {
        Task<List<GetColorDTO>> GetAllAsync(int page, int take);
        Task<GetColorDetailDto> GetByIdAsync(int id);
        public Task<int> CreateAsync(CreateColorDTO colorDTO);
        public Task Delete(int id);
        public Task Update(int id, UpdateColorDTO colorDTO);


        public Task<bool> AnyAsync(Expression<Func<object, bool>> expression);
    }
}
