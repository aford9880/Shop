using Shop.Data.Models;
using System.Collections.Generic;

namespace Shop.ViewModels {    
    public class CarsListViewModel {
        // ф-я, получающая все товары
        public IEnumerable<Car> AllCars { get; set; }
        public string CurrCategory { get; set; }
    }
}
