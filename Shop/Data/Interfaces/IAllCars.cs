using Shop.Data.Models;
using System.Collections.Generic;

namespace Shop.Data.Interfaces {
    public interface IAllCars {
        IEnumerable<Car> Cars { get; } // ф-я возвращает все товары
        IEnumerable<Car> GetFavCars { get; } // ф-я возвращает избранные товары
        Car GetObjectCar(int carID); // ф-я возвращает товар по Id
    }
}
