using Shop.Data.Models;
using System.Collections.Generic;

namespace Shop.Data.Interfaces {
    // Интерфейс, отвечающий за получение всех категорий из модели Category.cs
    public interface ICarsCategory { 
        IEnumerable<Category> AllCategories { get; }
    }
}
