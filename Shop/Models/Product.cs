namespace Shop.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public int? Price { get; set; }
        public ICollection<ProductInfo> ProductInfos { get; set; } = new List<ProductInfo>();

        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public ICollection<Basket> Baskets { get; set; } = new List<Basket>();
        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public ICollection<BasketProduct> BasketProducts { get; set; } = new List<BasketProduct>();
    }
}
