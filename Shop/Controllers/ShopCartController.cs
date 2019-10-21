using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.ViewModels;
using System.Linq;

namespace Shop.Controllers {
    public class ShopCartController : Controller {
        private IAllCars _carRep;
        private readonly ShopCart _shopCart;

        public ShopCartController(IAllCars carRep, ShopCart shopCart) {
            _carRep = carRep;
            _shopCart = shopCart;
        }
        // Функция для вызова Html-шаблона и отображения корзины
        public ViewResult Index() {
            var items = _shopCart.GetShopItems();
            _shopCart.ListShopItems = items;
            var obj = new ShopCartViewModel {
                shopCart = _shopCart
            };
            return View(obj);
        }
        // функция для переадресации на другую страницу
        public RedirectToActionResult addToCart(int id) {
            var item = _carRep.Cars.FirstOrDefault(i => i.Id == id);
            // Проверка если item <> null, то
            if (item != null) { // вызываем функцию добавления товара в корзину из модели
                _shopCart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }
    }
}
