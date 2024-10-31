using Management_Restaurant.RestaurantManage.api.@internal.core.data.repository;
using Management_Restaurant.RestaurantManage.api.@internal.core.dto;
using Management_Restaurant.RestaurantManage.api.@internal.core.entity;
using Management_Restaurant.RestaurantManage.api.@internal.core.service;
using Microsoft.EntityFrameworkCore;

public class CategoryService : ICategoryService
{
    private readonly ApplicationDbContext _context;

    public CategoryService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<CategoryDto>> GetAllCategoriesAsync()
    {
        return await _context.Categories
            .Select(category => new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            })
            .ToListAsync();
    }

    public async Task<CategoryDto> GetCategoryByIdAsync(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null) return null;

        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name
        };
    }

    public async Task<CategoryDto> CreateCategoryAsync(CategoryDto categoryDto)
    {
        if (categoryDto == null)
        {
            throw new ArgumentNullException(nameof(categoryDto), "Category DTO cannot be null");
        }

        var category = new Category
        {
            Name = categoryDto.Name
        };

        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();

        categoryDto.Id = category.Id; 
        return categoryDto; // Return the created CategoryDto
    }

    public async Task<bool> UpdateCategoryAsync(int id, CategoryDto categoryDto)
    {
        if (categoryDto == null)
        {
            throw new ArgumentNullException(nameof(categoryDto), "Category DTO cannot be null");
        }

        var category = await _context.Categories.FindAsync(id);
        if (category == null)
        {
            return false; // Category not found
        }

        category.Name = categoryDto.Name;
        await _context.SaveChangesAsync();

        return true; // Indicate successful update
    }

    public async Task<bool> DeleteCategoryAsync(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null)
        {
            return false; // Category not found
        }

        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();

        return true; // Indicate successful deletion
    }
}
