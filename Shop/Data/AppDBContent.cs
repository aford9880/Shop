using Microsoft.EntityFrameworkCore;
using Shop.Data.Models;

namespace Shop.Data {
    public class AppDBContent : DbContext {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options) { // получаем список опций и передаем их в базовый конструктор

        }
        public DbSet<Car> Car { get; set; } 
        public DbSet<Category> Category { get; set; }
        public DbSet<ShopCartItem> ShopCartItem { get; set; }
        // Чтобы выполнить обновление БД после добавления ShopCartItem нужно выполнить миграцию и потом обновление:
        // Вид -> Другие окна -> Консоль диспетчера пакетов, ввести EntityFrameworkCore\Add-migration ShopCart
        // Название может быть любое, потом ввести EntityFrameworkCore\Update-database
    }
}
