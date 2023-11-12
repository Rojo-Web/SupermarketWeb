using System.ComponentModel.DataAnnotations.Schema;

namespace SupermarketWeb.Models
{
    public class Product
    {
        // [Key] -> Anotacion si la propiedad no se llama Id, Ejemplo ProductId

        public int Id { get; set; }
        public string Name { get; set; }

        //[Column(TypeName = "decimal(6,2)")]

        public int Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        //public Category Category { get; set; }

        public ICollection<Category>? Categories { get; set; } = default!; //Propiedad de navegacion
    }
}
