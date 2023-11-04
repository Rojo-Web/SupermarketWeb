namespace SupermarketWeb.Models
{
    public class Category
    {
        public int Id { get; set; }//Sera llave primaria
        public string Name { get; set; }
        public string? Description { get; set; }

        public ICollection<Product> Products { get; set; } //Propiedad de navegacion

    }
}
