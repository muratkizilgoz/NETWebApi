using System.ComponentModel.DataAnnotations;

namespace FiltersSample.Models
{
    public class Product : Base
    {
        [Required] public int Quantity { get; set; }

        [Required] public decimal Price { get; set; }
    }
}