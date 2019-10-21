using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models {
    public class OrderDetail {
        public int Id { get; set; } // Id для БД
        public int OrderId { get; set; } // Id заказа
        public int CarId { get; set; } // Id товара
        public uint Price { get; set; } // Цена
        // Переменные для связки списка заказа с объектом товара и объектом заказа (с Order и Car)
        // они больше нужны для БД, чтобы мы понимали как взаимодействуют эти классы
        public virtual Car Car { get; set; }
        public virtual Order Order { get; set; }        
    }
}
