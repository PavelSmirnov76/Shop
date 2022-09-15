namespace Shop.Models
{
    public class Basket
    {
        public long Id { get; set; }
        public long UserId { get; set; }    
        public ICollection<Product>? Products { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public ICollection<BasketProduct>? BasketProducts { get; set; }
    }
}
