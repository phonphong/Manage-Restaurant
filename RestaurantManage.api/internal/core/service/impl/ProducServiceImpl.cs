using Management_Restaurant.RestaurantManage.api.@internal.core.data.repository;
using Management_Restaurant.RestaurantManage.api.@internal.core.dto;
using Management_Restaurant.RestaurantManage.api.@internal.core.entity;
using Management_Restaurant.RestaurantManage.api.@internal.core.service;
using Microsoft.EntityFrameworkCore;

public class ProductService : IProductService
{
    private readonly ApplicationDbContext _context;

    public ProductService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProductDto>> GetAllProductsAsync()
    {
        return await _context.Products.Select(product => new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            CategoryId = product.CategoryId
        }).ToListAsync();
    }

    public async Task<ProductDto> GetProductByIdAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null) return null;

        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            CategoryId = product.CategoryId
        };
    }

    public async Task<ProductDto> CreateProductAsync(ProductDto productDto)
    {
        var product = new Product
        {
            Name = productDto.Name,
            Price = productDto.Price,
            CategoryId = productDto.CategoryId
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        productDto.Id = product.Id; 
        return productDto;
    }

    public async Task<ProductDto> UpdateProductAsync(int id, ProductDto productDto)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null) return null;

        product.Name = productDto.Name;
        product.Price = productDto.Price;
        product.CategoryId = productDto.CategoryId;

        await _context.SaveChangesAsync();
        return productDto;
    }

    public async Task DeleteProductAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product != null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }

}
