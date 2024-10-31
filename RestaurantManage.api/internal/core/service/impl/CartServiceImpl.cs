using Management_Restaurant.RestaurantManage.api.@internal.core.data.repository;
using Management_Restaurant.RestaurantManage.api.@internal.core.dto;
using Management_Restaurant.RestaurantManage.api.@internal.core.service;
using Microsoft.EntityFrameworkCore;

public class CartService : ICartService
{
    private readonly ApplicationDbContext _context;

    public CartService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CartDto> GetCartAsync(int userId)
    {
        var cart = await _context.Carts.Include(c => c.Items).FirstOrDefaultAsync(c => c.UserId == userId);
        return new CartDto
        {
            Id = cart.Id,
            UserId = cart.UserId,
            Items = cart.Items.Select(item => new CartItemDto
            {
                Id = item.Id,
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                Price = item.Price
            }).ToList(),
            TotalPrice = cart.TotalPrice
        };
    }

    public async Task AddToCartAsync(int userId, CartItemDto cartItemDto)
    {
        var cart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == userId);
        if (cart == null)
        {
            cart = new Cart { UserId = userId };
            _context.Carts.Add(cart);
        }

        var existingItem = cart.Items.FirstOrDefault(i => i.ProductId == cartItemDto.ProductId);
        if (existingItem != null)
        {
            existingItem.Quantity += cartItemDto.Quantity; // update quantity
        }
        else
        {
            cart.Items.Add(new CartItem
            {
                ProductId = cartItemDto.ProductId,
                Quantity = cartItemDto.Quantity,
                Price = cartItemDto.Price
            });
        }

        await _context.SaveChangesAsync();
    }

    public async Task UpdateCartItemAsync(int userId, CartItemDto cartItemDto)
    {
        var cart = await _context.Carts.Include(c => c.Items).FirstOrDefaultAsync(c => c.UserId == userId);
        var existingItem = cart?.Items.FirstOrDefault(i => i.Id == cartItemDto.Id);
        if (existingItem != null)
        {
            existingItem.Quantity = cartItemDto.Quantity; // Cập nhật số lượng
            await _context.SaveChangesAsync();
        }
    }

    public async Task RemoveFromCartAsync(int userId, int cartItemId)
    {
        var cart = await _context.Carts.Include(c => c.Items).FirstOrDefaultAsync(c => c.UserId == userId);
        var itemToRemove = cart?.Items.FirstOrDefault(i => i.Id == cartItemId);
        if (itemToRemove != null)
        {
            cart.Items.Remove(itemToRemove); // Xóa mục khỏi giỏ hàng
            await _context.SaveChangesAsync();
        }
    }

    public async Task ClearCartAsync(int userId)
    {
        var cart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == userId);
        if (cart != null)
        {
            cart.Items.Clear(); // Xóa toàn bộ giỏ hàng
            await _context.SaveChangesAsync();
        }
    }

   
}
