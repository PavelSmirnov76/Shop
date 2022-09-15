namespace Shop.Models
{
    public class ProductInfo
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public Product? Product { get; set; }
        public string? Hedder { get; set; }
        public string? Description { get; set; }
        
    }
}
