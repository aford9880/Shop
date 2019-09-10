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
                        img = "https://www.tesla.com/content/dam/tesla-site/sx-redesign/img/socialcard/MS.jpg",
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
                        img = "https://www.winnerauto.ua/uploads/gallery_photo/0170/91.jpg",
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
                        img = "https://img.tipcars.com/fotky_velke/33550669_9/2018/E/bmw-m3-top-m-perfomance-paket.jpg",
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
                        img = "https://en.wikipedia.org/wiki/Mercedes-Benz_C-Class#/media/File:2014_Mercedes-Benz_C200_SE_Executive_Automatic_2.0_Front.jpg",
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
                        img = "https://ru.wikipedia.org/wiki/Nissan_LEAF#/media/%D0%A4%D0%B0%D0%B9%D0%BB:2018_Nissan_Leaf_Tekna_Front.jpg",
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
