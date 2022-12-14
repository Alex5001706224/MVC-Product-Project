
using System.ComponentModel.DataAnnotations;

namespace Assignment_12_1.Models
{
    public class Manufacture
    {
        [Key]
        public int MakeId { get; set; }
        public string? MakeName { get; set; }
        public virtual ICollection<Product>? Products { get; set; }
    }
}
