namespace Supermarket.Core.DtoObjects.ViewModels.Cart
{
    public class CartItemVM
    {
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total => Price * Quantity;
    }
}
