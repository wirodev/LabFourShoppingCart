namespace LabFourShoppingCart.Models
{
    public class ShoppingCart
    {
        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();

        public void AddItem(ProductItem product, int quantity = 1)
        {
            var existingItem = Items.FirstOrDefault(i => i.ProductCode == product.ProductCode);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                Items.Add(new ShoppingCartItem
                {
                    ProductCode = product.ProductCode,
                    Description = product.Description,
                    Price = product.Price,
                    Quantity = quantity
                });
            }
        }

        public decimal CalculateTotalPrice()
        {
            return Items.Sum(item => item.Price * item.Quantity);
        }
    }

}
