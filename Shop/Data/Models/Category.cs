using System.Collections.Generic;

namespace Shop.Data.Models {
    public class Category {
        public int Id { set; get; }
        public string CategoryName { set; get; }
        public string Desc { set; get; }
        public List<Car> Cars { set; get; } // У каждой категории есть большой список (List) товаров, которые в нее входят
    }
}
