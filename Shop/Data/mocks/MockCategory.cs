using Shop.Data.Interfaces;
using Shop.Data.Models;
using System.Collections.Generic;

namespace Shop.Data.mocks {
    /* Моксы позволяют создавать нужные нам объекты, функции и, по сути, создавать информацию внутри нашего проекта */
    /* в этом классе реализуем интерфейс ICarsCategory и его функции */   
    public class MockCategory : ICarsCategory {
        public IEnumerable<Category> AllCategories {
            get {
                return new List<Category> {
                    new Category { CategoryName = "Электромобили", Desc = "Современный вид транспорта" },
                    new Category { CategoryName = "Классические автомобили", Desc = "Машины с двигателем внутреннего сгорания"}
                };
            }
        }
    }
}
