// Модель корзины
namespace Shop.Data.Models {
    public class ShopCartItem {
        public int Id { get; set; } // Id товара
        public Car car { get; set; }
        public int Price { get; set; }
        public string ShopCartId { get; set; } // Id товара в корзине
    }
}
