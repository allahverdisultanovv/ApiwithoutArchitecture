using FirstApi.DTOs.Color;
using FirstApi.Repositories.Interfaces;
using FirstApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FirstApi.Services.Implementations
{
    public class ColorService : IColorService
    {
        private readonly IColorRepository _colorRepository;

        public ColorService(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

        public async Task<List<GetColorDTO>> GetAllAsync(int page, int take)
        {
            var colors = await _colorRepository.GetAll(skip: (page - 1) * 5, take: take).ToListAsync();
            List<GetColorDTO> colorDTOs = colors.Select(c => new GetColorDTO { Name = c.Name, Id = c.Id }).ToList();
            return colorDTOs;
        }



        public async Task<GetColorDetailDto> GetByIdAsync(int id)
        {
            Color color = await _colorRepository.GetByIdAsync(id);
            return new GetColorDetailDto { Id = id, Name = color.Name };
        }
        public async Task<int> CreateAsync(CreateColorDTO colorDTO)
        {
            Color color = new Color()
            {
                Name = colorDTO.Name,
            };
            await _colorRepository.AddAsync(color);
            return await _colorRepository.SaveChangesAsync();

        }

        public async Task<bool> AnyAsync(Expression<Func<object, bool>> expression)
        {
            return await _colorRepository.AnyAsync(expression);
        }

        public async Task Delete(int id)
        {
            Color color = await _colorRepository.GetByIdAsync(id);
            _colorRepository.Delete(color);
            await _colorRepository.SaveChangesAsync();
        }

        public async Task Update(int id, UpdateColorDTO colorDTO)
        {
            Color color = new()
            {
                Name = colorDTO.Name,
                Id = id
            };
            _colorRepository.Update(color);
            await _colorRepository.SaveChangesAsync();
        }


    }
}
