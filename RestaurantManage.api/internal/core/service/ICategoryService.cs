
using Management_Restaurant.RestaurantManage.api.@internal.core.dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Management_Restaurant.RestaurantManage.api.@internal.core.service
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto> GetCategoryByIdAsync(int id);
        Task <CategoryDto>CreateCategoryAsync(CategoryDto categoryDto);
        Task <bool>UpdateCategoryAsync(int id, CategoryDto categoryDto);
        Task <bool>DeleteCategoryAsync(int id);
    }
}
