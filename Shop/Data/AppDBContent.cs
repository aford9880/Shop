using Microsoft.EntityFrameworkCore;
using Shop.Data.Models;

namespace Shop.Data {
    public class AppDBContent : DbContext {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options) { // получаем список опций и передаем их в базовый конструктор

        }
        public DbSet<Car> Car { get; set; } 
        public DbSet<Category> Category { get; set; }

    }
}
