using System.ComponentModel.DataAnnotations;

namespace Management_Restaurant.RestaurantManage.api.@internal.core.entity
{
    public class Table
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } 

        public int Seats { get; set; } 

        public bool IsAvailable { get; set; } = true; 
    }
}
