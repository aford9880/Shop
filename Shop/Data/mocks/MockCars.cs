using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Data.mocks {
    /* Моксы позволяют создавать нужные нам объекты, функции и, по сути, создавать информацию внутри нашего проекта */
    /* в этом классе реализуем интерфейс IAllCars и его функции */
    public class MockCars : IAllCars {
        private readonly ICarsCategory _categoryCars = new MockCategory();
        public IEnumerable<Car> Cars {
            get {
                return new List<Car> {
                    new Car {
                        Name = "Tesla",
                        ShortDesc = "Быстрый автомобиль",
                        LongDesc = "Красивый, быстрый и очень тихий автомобиль компании Tesla",
                        Img = "/img/tesla.jpg",
                        Price = 45000,
                        IsFavorite = true,
                        Available = true,
                        Category = _categoryCars.AllCategories.First()
                    },
                    new Car {
                        Name = "Ford Fiesta",
                        ShortDesc = "Тихий и спокойный",
                        LongDesc = "Удобный автомобиль для городской жизни",
                        Img = "/img/fiesta.jpg",
                        Price = 11000,
                        IsFavorite = false,
                        Available = true,
                        Category = _categoryCars.AllCategories.Last()
                    },
                   new Car {
                        Name = "BMW M3",
                        ShortDesc = "Дерзкий и сильный",
                        LongDesc = "Удобный автомобиль для городской жизни",
                        Img = "/img/m3.jpg",
                        Price = 65000,
                        IsFavorite = true,
                        Available = true,
                        Category = _categoryCars.AllCategories.Last()
                    },
                   new Car {
                        Name = "Mercedes C class",
                        ShortDesc = "Уютный и большой",
                        LongDesc = "Удобный автомобиль для городской жизни",
                        Img = "/img/mercedes.jpg",
                        Price = 40000,
                        IsFavorite = false,
                        Available = false,
                        Category = _categoryCars.AllCategories.Last()
                    },
                   new Car {
                        Name = "Nissan Leaf",
                        ShortDesc = "Бесшумный и экономный",
                        LongDesc = "Удобный автомобиль для городской жизни",
                        Img = "/img/nissan.jpg",
                        Price = 14000,
                        IsFavorite = true,
                        Available = true,
                        Category = _categoryCars.AllCategories.First()
                    }
                };
            }
        }
        public IEnumerable<Car> GetFavCars { get; set; }

        public Car GetObjectCar(int carID) {
            throw new NotImplementedException();
        }
    }
}
