namespace Supermarket.Core.DtoObjects.Api.Product
{
    public class ProductResponseDto: BaseDto
    {
        public string Id { get; set; }

        public string CategoryName { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
        
        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public bool LowQuantity { get; set; }

        public int Quantity { get; set; }
    }
}