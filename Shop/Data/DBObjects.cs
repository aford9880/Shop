using Shop.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Data {
    public class DBObjects {
        public static void Initial(AppDBContent content) {           
            if (!content.Category.Any()) // проверяем на доступность всех категорий, если в БД их нет - добавляем
                content.Category.AddRange(Categories.Select(c => c.Value)); // AddRange позволяет добавить набор объектов
            if (!content.Car.Any()) { // если товаров в БД нет - добавляем
                content.AddRange(
                    new Car {
                        Name = "Tesla",
                        ShortDesc = "Быстрый автомобиль",
                        LongDesc = "Красивый, быстрый и очень тихий автомобиль компании Tesla",
                        Img = "/img/tesla.jpg",
                        Price = 45000,
                        IsFavorite = true,
                        Available = true,
                        Category = Categories["Электромобили"]
                    },
                    new Car {
                        Name = "Ford Fiesta",
                        ShortDesc = "Тихий и спокойный",
                        LongDesc = "Удобный автомобиль для городской жизни",
                        Img = "/img/fiesta.jpg",
                        Price = 11000,
                        IsFavorite = false,
                        Available = true,
                        Category = Categories["Классические автомобили"]
                    },
                   new Car {
                       Name = "BMW M3",
                       ShortDesc = "Дерзкий и сильный",
                       LongDesc = "Удобный автомобиль для городской жизни",
                       Img = "/img/m3.jpg",
                       Price = 65000,
                       IsFavorite = true,
                       Available = true,
                       Category = Categories["Классические автомобили"]
                   },
                   new Car {
                       Name = "Mercedes C class",
                       ShortDesc = "Уютный и большой",
                       LongDesc = "Удобный автомобиль для городской жизни",
                       Img = "/img/mercedes.jpg",
                       Price = 40000,
                       IsFavorite = false,
                       Available = false,
                       Category = Categories["Классические автомобили"]
                   },
                   new Car {
                       Name = "Nissan Leaf",
                       ShortDesc = "Бесшумный и экономный",
                       LongDesc = "Удобный автомобиль для городской жизни",
                       Img = "/img/nissan.jpg",
                       Price = 14000,
                       IsFavorite = true,
                       Available = true,
                       Category = Categories["Электромобили"]
                   }
                );
            }
            content.SaveChanges(); // сохраняем все изменения в БД
        }
        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories {
            get {
                if(category == null) {  // если категория заполнена, то просто возвращаем ее, иначе заполняем и возвращаем
                    var list = new Category[] {
                        new Category { CategoryName = "Электромобили", Desc = "Современный вид транспорта" },
                        new Category { CategoryName = "Классические автомобили", Desc = "Машины с двигателем внутреннего сгорания"}
                    };
                    category = new Dictionary<string, Category>(); // выделяем память
                    foreach (Category el in list) // добавляем категории в category
                        category.Add(el.CategoryName, el);                    
                }
                return category;
            }
        }
    }
}
