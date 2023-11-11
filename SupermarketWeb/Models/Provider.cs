namespace SupermarketWeb.Models
{
    public class Provider
    {
        
        public int Id { get; set; }//Sera llave primaria
        public string Name { get; set; }
        public string? Descripcion { get; set; }

        //public ICollection<Product>? Products { get; set; } = default!; //Propiedad de navegacion

    }
}
