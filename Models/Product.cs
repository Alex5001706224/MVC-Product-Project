using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_12_1.Models
{
    public enum Make
    {
        Benz = 1,
        Bugatti,
        Lamborghini,
        McLaren
    }
    public class Product
    {
        [Display(Name ="Product Id")]
        [Required(ErrorMessage ="Please fill in id")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int MakeId { get; set; }
        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Please fill in name")]
        [MaxLength(100)]
        [AllLetters(ErrorMessage = "Please enter letters only!")]
        public string? PName { get; set; }
        [Display(Name = "Product Description")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Cannot leave with blank")]
        [MaxLength(500, ErrorMessage = "Please limit with 500 character")]
        public string? PDescription { get; set; }
        public double Price { get; set; }
        public string? ImageName { get; set; }
        public Make Manufacture { get; set; }
    }
}
