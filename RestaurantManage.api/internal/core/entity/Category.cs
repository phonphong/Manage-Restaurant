
using System.ComponentModel.DataAnnotations;

namespace Management_Restaurant.RestaurantManage.api.@internal.core.entity
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Description { get; set; } 

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
