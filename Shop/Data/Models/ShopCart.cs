using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Data.Models {
    public class ShopCart {
        private readonly AppDBContent appDBContent;
        public ShopCart(AppDBContent appDBContent) { // В конструкторе устанавливаем значение на appDBContent
            this.appDBContent = appDBContent; // это необходимо для того, чтобы мы могли работать с БД
        }
        public string ShopCartId { get; set; }
        // список всех элементов, которые будут отображены внутри корзины
        public List<ShopCartItem> ListShopItems { get; set; }            
        public static ShopCart GetCart(IServiceProvider services) { // класс служит для работы с сессиями, 
            // если пользователь не добавил ни одного товара в корзину - создаем новую сессию, либо используем ту
            // при первом вызове GetCart будет создано новое значение и будет установлена сессия CartId
            // а при следующих вызовах GetCart будет возвращать какое-то определенное значение сессии
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session; // создаем новую сессию
            var context = services.GetService<AppDBContent>();
            // если не существует CartId, то создаем новый идентификатор
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            // устанавливаем новую сессию (CartId - ключ, shopCartId - значение)
            session.SetString("CartId", shopCartId);
            // возвращаем объект на основе класса ShopCart
            return new ShopCart(context) { ShopCartId = shopCartId };
        }
        // Функция для добавления товаров в корзину
        public void AddToCart(Car car) {
            appDBContent.ShopCartItem.Add(new ShopCartItem {
                ShopCartId = ShopCartId,
                car = car,
                Price = car.Price
            });
            appDBContent.SaveChanges(); // Сохраняем изменения
        }
        // Функция для отображения всех товаров в корзине
        public List<ShopCartItem> GetShopItems() {
            // выбираем те элементы, у которых Id корзины равен Id корзины в сессии
            return appDBContent.ShopCartItem.Where(c => c.ShopCartId == ShopCartId).Include(s => s.car).ToList();
        }
    }
}
