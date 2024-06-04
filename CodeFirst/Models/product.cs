using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
    public class product
    {
        [Key]
        [Required]
        public int product_Id { get; set; }
        [Required]
        [MaxLength(8)]
        public string product_Name { get; set; }
        [Required]
        [Range(100, 5000)]
        public int product_Price { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateOnly ProductPurchase_date { get; set; }
        [Required]
        [MaxLength(8)]
        //[RegularExpression(@"^[A-Z]{3}[a-z]{3}[0-9]{2}#")]
        public string product_code { get; set; }
    }
}
