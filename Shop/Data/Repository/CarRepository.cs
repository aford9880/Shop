﻿using Microsoft.EntityFrameworkCore;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Data.Repository {
    public class CarRepository : IAllCars { // Наследуемся от IAllCars и реализуем его функции
        private readonly AppDBContent appDBContent; 
        public CarRepository(AppDBContent appDBContent) { // В конструкторе устанавливаем значение на appDBContent
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Car> Cars => appDBContent.Car.Include(c => c.Category); // в переменную с получаем все данные определенной категории
        public IEnumerable<Car> GetFavCars => appDBContent.Car.Where(p => p.IsFavorite).Include(c => c.Category);
        public Car GetObjectCar(int carID) => appDBContent.Car.FirstOrDefault(p => p.Id == carID); // выбираем один элемент или элемент по умолчанию в котором ID = carID
    }
}
