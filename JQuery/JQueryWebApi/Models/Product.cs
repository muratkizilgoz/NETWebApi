namespace JQueryWebApi.Models
{
    public class Product : Base
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}