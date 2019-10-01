using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Controllers {
    /* Этот класс должен заканчиваться на Controller, чтобы на система считала его контроллером и на сайте подбирался контроллер для введенного URl адреса, во как
     тут будут различные функциии, при вызове которых будет возвращаться тип данных ViewResult 
     это такой тип данных, который возвращает не просто некий объект, число или др, а результат, который идет в виде html-страницы,
     в эту html-страницу будем передавать объект со всеми товарами, которые есть в магазине */

    /* URL-адрес выглядит след. образом: https://localhost:44326/Cars/List 
                                  где:                |            |    |    
                                                      |       контроллер|    
                                                 адрес сайта    функция в контроллере */

    public class CarsController : Controller {
        // переменные на интерфейсы
        private readonly IAllCars _allCars; 
        private readonly ICarsCategory _allCategories;
        // т.к. мы связали интерфейсы и классы в Startup.cs, теперь можно задавать переменные на интерфейсы и передавать в конструктор
        // эти интерфейсы, вместе с тем передавая классы, которые их реализуют
        // по сути мы передаем уже готовые созданные объекты
        public CarsController(IAllCars iAllCars, ICarsCategory iCarsCat) {
            _allCars = iAllCars;
            _allCategories = iCarsCat;
        }
        // Возвращаем целую html страницу (через шаблон в папке Views/Cars)
        // Функция List ищет шаблоны c именем List внутри папки Views/Cars (CarsController -> Views/Cars)
        [Route("Cars/List")] // эти 2 строки для роутинга
        [Route("Cars/List/{category}")]
        public ViewResult List(string category) {
            string _category = category;
            IEnumerable<Car> cars = null;
            string currCategory = "";
            // Если строка с категорией пустая - возвращаем все автомобили, если нет, то по категориям
            if (string.IsNullOrEmpty(category)) {
                cars = _allCars.Cars.OrderBy(i => i.Id);
            } else { // StringComparison.OrdinalIgnoreCase игнорирует регистр
                if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase)) {
                    cars = _allCars.Cars.Where(i => i.Category.CategoryName.Equals("Электромобили")).OrderBy(i => i.Id);
                    currCategory = "Электромобили";
                } else if (string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase)) {
                    cars = _allCars.Cars.Where(i => i.Category.CategoryName.Equals("Классические автомобили")).OrderBy(i => i.Id);
                    currCategory = "Классические автомобили";
                }                
            }                            
            var carObj = new CarsListViewModel {
                AllCars = cars,
                CurrCategory = currCategory
            };
            // ViewBag - для передачи любых данных внутрь html-шаблона (не рекомендуется исп, если надо передать много значений)
            ViewBag.Title = "Страница с автомобилями"; 
            
            return View(carObj);
        }
    }
}
