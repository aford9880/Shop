using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;

namespace Shop.Data.Models {
    public class Order {
        [BindNever] // Это поле никогда не будет показано на странице
        public int Id { get; set; }
        
        // Поля для формы заказа
        [Display(Name = "Имя")] // Подпись, которая будет отображаться вместо Name
        [StringLength(25)] // Максимальная длина поля
        [Required(ErrorMessage = "Длина имени не более 25-ти символов")] // сообщение, выводимое при ошибке
        public string Name { get; set; }
        
        [Display(Name = "Фамилия")]
        [StringLength(25)]
        [Required(ErrorMessage = "Длина фамилии не более 25-ти символов")]
        public string Surname { get; set; }
        
        [Display(Name = "Адрес")]
        [StringLength(35)]
        [Required(ErrorMessage = "Длина адреса не более 35-ти символов")]
        public string Adress { get; set; }
        
        [Display(Name = "Телефон")]
        [DataType(DataType.PhoneNumber)] // Тип поля
        [StringLength(11)]
        [Required(ErrorMessage = "Длина номера не более 11-ти знаков")]
        public string Phone { get; set; }
        
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)] 
        [StringLength(25)]
        [Required(ErrorMessage = "Длина email не менее 5-ти символов")]
        public string Email { get; set; }
        
        [BindNever]
        [ScaffoldColumn(false)] // поле не будет отображено даже в исходном коде, т.е. чисто системное поле
        public DateTime OrderTime { get; set; }
        
        // Поля для описания приобретаемых товаров
        public List<OrderDetail> orderDetails { get; set; }
    }
}
