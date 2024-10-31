namespace Management_Restaurant.RestaurantManage.api.@internal.core.entity
{
    using System.ComponentModel.DataAnnotations;
    using BCrypt.Net; 

    public enum Role
    {
        Admin,
        Staff,
        Customer
    }

    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Username { get; set; }

        [Required]
        [StringLength(100)]
        public string? Password { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public Role Role { get; set; } 

        public void SetPassword(string password)
        {
            Password = BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password)
        {
            return BCrypt.Verify(password, Password);
        }
    }
}