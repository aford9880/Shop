using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.ViewModels;

namespace Shop.Controllers {
    // Этот контроллер автоматически становится главным и 
    // вызывается когда мы переходим на гл. страницу сайта,
    // а в нем уже вызываетс яфункция Index
    public class HomeController : Controller {
        private IAllCars _carRep;       

        public HomeController(IAllCars carRep) {
            _carRep = carRep;            
        }
        // Функция для возвращения шаблона
        public ViewResult Index() {
            var homeCars = new HomeViewModel {
                FavCars = _carRep.GetFavCars
            };
            return View(homeCars);
        }             
    }
}
