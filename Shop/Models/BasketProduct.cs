namespace Shop.Models
{
    public class BasketProduct
    {
        public long BasketId { set; get; }
        public Basket? Basket { set; get; }
        public long ProductId { set; get; }
        public Product? Product { set; get; }
    }
}
