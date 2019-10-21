namespace Shop.Data.Models {
    public class Car {
        public int Id { set; get; }
        public string Name { set; get; }
        public string ShortDesc { set; get; }
        public string LongDesc { set; get; }
        public string Img { set; get; }
        public ushort Price { set; get; }
        public bool IsFavorite { set; get; }
        public bool Available { set; get; }
        public int CategoryID { set; get; }
        public virtual Category Category { set; get; } // Создаем объект со всеми значениями, которые есть в Category.cs
    }
}
