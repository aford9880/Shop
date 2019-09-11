using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.mocks
{
    public class MockCars : IAllCars
    {
        private readonly ICarsCategory _categoryCars = new MockCategory();
        public IEnumerable<Car> Cars
        {
            get
            {
                return new List<Car>
                {
                    new Car
                    {
                        name = "Tesla",
                        shortDesc = "Быстрый автомобиль",
                        longDesc = "Красивый, быстрый и очень тихий автомобиль компании Tesla",
                        img = "/img/tesla.jpg",
                        price = 45000,
                        isFavorite = true,
                        available = true,
                        Category = _categoryCars.AllCategories.First()
                    },
                    new Car
                    {
                        name = "Ford Fiesta",
                        shortDesc = "Тихий и спокойный",
                        longDesc = "Удобный автомобиль для городской жизни",
                        img = "/img/fiesta.jpg",
                        price = 11000,
                        isFavorite = false,
                        available = true,
                        Category = _categoryCars.AllCategories.Last()
                    },
                   new Car
                    {
                        name = "BMW M3",
                        shortDesc = "Дерзкий и сильный",
                        longDesc = "Удобный автомобиль для городской жизни",
                        img = "/img/m3.jpg",
                        price = 65000,
                        isFavorite = true,
                        available = true,
                        Category = _categoryCars.AllCategories.Last()
                    },
                   new Car
                    {
                        name = "Mercedes C class",
                        shortDesc = "Уютный и большой",
                        longDesc = "Удобный автомобиль для городской жизни",
                        img = "/img/mercedes.jpg",
                        price = 40000,
                        isFavorite = false,
                        available = false,
                        Category = _categoryCars.AllCategories.Last()
                    },
                   new Car
                    {
                        name = "Nissan Leaf",
                        shortDesc = "Бесшумный и экономный",
                        longDesc = "Удобный автомобиль для городской жизни",
                        img = "/img/nissan.jpg",
                        price = 14000,
                        isFavorite = true,
                        available = true,
                        Category = _categoryCars.AllCategories.First()
                    }
                };
            }
        }
        public IEnumerable<Car> getFavCars { get; set; }

        public Car getObjectCar(int carID)
        {
            throw new NotImplementedException();
        }
    }
}
