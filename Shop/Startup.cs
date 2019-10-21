/* Чтобы добавить объекты в БД (если БД еще не создана - надо создать:
 * Вид -> Другие окна -> Консоль диспетчера пакетов, в нем вводим 
 * 1) "Add-Migration Initial" (Initial можно назвать как угодно, + миграции в проекте уже есть, этот шаг необязателен)
 * 2) "Update-database" (обновляем БД и создаем в ней таблицы)
 * Чтобы открыть таблицу в локальной БД, надо выбрать Вид -> SQL Server Object Explorer */
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data;
using Shop.Data.Interfaces;
using Shop.Data.Models;
//using Shop.Data.mocks; - Моксы не используем в связи с переходом на БД
using Shop.Data.Repository;

namespace Shop
{
    public class Startup {
        private IConfigurationRoot _confString;
        public Startup(IHostingEnvironment hostEnv) { // в конструткоре Startup-а получаем строку конфигурации из файла dbsettings.json)
            // SetBasePath - начальный путь
            // hostEnv.ContentRootPath - нужная папка
            // AddJsonFile("dbsettings.json") - указываем сам файл
            // Build() - получение строки
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) { // Ф-я для регистрации различных модулей, плагинов
            // подключаем файл коннекта к БД, _confString указывает с какой строкой мы работаем
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));
            // Связывание: 1-й параметр - с каким интерфейсом работаем, 2-й - какой класс реализует этот интерфейс
            services.AddTransient<IAllCars, CarRepository>(); // интерфейс IAllCars реализуется в классе /*MockCars*/ CarRepository
            services.AddTransient<ICarsCategory, CategoryRepository>(); // интерфейс ICarsCategory реализуется в классе /*MockCategory*/ CarRepository
            services.AddTransient<IAllOrders, OrdersRepository>();
            // Добавляем сервис, который позволяет работать с сессиями
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // Сервис, который делает так, что если 2 пользователя зайдут в корзину, то для двух пользователей будет выдана разная корзина
            // ShopCart.GetCart(sp) - какую конкретно мы вытягиваем корзину
            services.AddScoped(sp => ShopCart.GetCart(sp));
            // Подключаем поддержку MVC в проекте
            services.AddMvc();
            // Необходимо указать, что мы используем кэш и сессии
            services.AddMemoryCache();
            services.AddSession();            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env){
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // отображение страницы с ошибками
                app.UseStatusCodePages(); // отображение кодов страниц
                app.UseStaticFiles(); // использование статических файлов (css, картинки и т.д.)                
                app.UseSession(); // чтобы сессии работали
                // отслеживание URL: если в адресе не будет указан контроллер и вид, то исп. URL по умолчанию        
                //app.UseMvcWithDefaultRoute(); // В нашем случае попадаем на контроллер хоум
                // Пропишем свои адреса
                app.UseMvc(routes => {
                    // В {} параметры по умолчанию, если заданы пустые строки, без {} обязательные параметры
                    routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{Id?}"); // адрес по умолчанию, 3-й параметр не обязательный
                    // категории, если мы не передаем ничего, то будет вызван Car/List
                    routes.MapRoute(name: "categoryFilter", template: "Car/{action}/{category?}", defaults: new { Controller = "Car", action = "List" });                    
                });
                using (var scope = app.ApplicationServices.CreateScope()) { // создаем область (окружение) для использования сервиса AppDBContent
                    AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                    DBObjects.Initial(content); // Обращаемся к БД за товарами
                }                
            }
        }
    }
}
