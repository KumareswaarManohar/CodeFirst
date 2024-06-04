using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
    public class order
    {
        public int orderid { get; set; }
        [ForeignKey("Product")]
        public int id { get; set; }
        [Required]
        public string ordername { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateOnly orderdate { get; set; }
        [Required]
        public double orderamount { get; set; }
    }
}
