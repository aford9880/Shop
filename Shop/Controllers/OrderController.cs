using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers {
    public class OrderController : Controller {
        private readonly IAllOrders allOrders;
        private readonly ShopCart shopCart;

        public OrderController(IAllOrders allOrders, ShopCart shopCart) {
            this.allOrders = allOrders;
            this.shopCart = shopCart;
        }
        // Ф-я, которая возвращает View (html-шаблон, но при этом мы знаем, что в нем будут производиться какие-либо действия
        public IActionResult Checkout() {
            return View();
        }
        // Ф-я, которая будет срабатывать только при http post методе
        [HttpPost]
        public IActionResult Checkout(Order order) {
            shopCart.ListShopItems = shopCart.GetShopItems();
            if (shopCart.ListShopItems.Count == 0) { // если товаров в корзине нет - выдаем ошибку
                ModelState.AddModelError(/*ключ:*/"", /*сообщение:*/"В корзине нет товаров!"); // модельная ошибка               
            }
            // если товары есть - следующая проверка
            if (ModelState.IsValid/*вернет true, если все поля ввода прошли проверку*/) {
                allOrders.CreateOrder(order/*объект, который мы получаем от пользователя*/);
                return RedirectToAction("Complete");
            }
            // если не попали в предыдущее условие, то возвращаем просто view с объектом order
            return View(order); // т.е. после перезагрузки страницы, введенные данные будут вставлены заново                        
        }

        public IActionResult Complete() {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }
    }
}
