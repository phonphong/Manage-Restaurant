using System.ComponentModel.DataAnnotations;

namespace Management_Restaurant.RestaurantManage.api.@internal.core.entity
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } 
        [Required]
        [EmailAddress]
        public string Email { get; set; } 

        [StringLength(15)]
        public string PhoneNumber { get; set; } 

        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>(); 
    }
}
