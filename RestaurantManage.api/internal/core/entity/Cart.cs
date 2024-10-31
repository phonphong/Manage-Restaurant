public class Cart
{
    public int Id { get; set; }

    public int UserId { get; set; }  

    public List<CartItem> Items { get; set; } = new List<CartItem>();

    public decimal TotalPrice => Items.Sum(item => item.Price * item.Quantity); 
}
