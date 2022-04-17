namespace Supermarket.Core.DtoObjects.ViewModels.Cart
{
    public class CartPageVm
    {
        public CartPageVm()
        {
            Items = new();
        }

        public List<CartItemVM> Items { get; set; }
        public decimal Subtotal => Items.Select(i => i.Total).Aggregate((total, next) => total + next);
        public decimal Total => Subtotal * 1.2m;
    }
}
