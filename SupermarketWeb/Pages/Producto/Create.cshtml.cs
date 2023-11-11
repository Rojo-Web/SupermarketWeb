using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using SupermarketWeb.Data;
using SupermarketWeb.Models;

namespace SupermarketWeb.Pages.Producto
{
    public class CreateModel : PageModel
    {
        private readonly SumpermarketContext _context;
        public List<string> categorias = new List<string>();

        public CreateModel(SumpermarketContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SupermarketEF;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Consultar las categorías desde la base de datos
                using (SqlCommand command = new SqlCommand("select concat(id,'-',Name) from Categories", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {


                        // Leer las categorías y agregarlas a la lista
                        while (reader.Read())
                        {
                            string categoria = reader.GetString(0);

                            categorias.Add(categoria);
                        }

                        // Pasar la lista de categorías a la vista
                        //cat = categorias;
                    }
                }
            }

            return Page();

        }
        [BindProperty]
        public Product Producto { get; set; } = default;
        //public Product Producto_final { get; set; } = default;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Products == null || Producto == null)
            {
                return Page();
            }

            //Producto_final.Name = Producto.Name;
            //Producto_final.Price = Convert.ToDecimal(Producto.Price);
            //Producto_final.Stock = Convert.ToInt32(Producto.Stock);
            //Producto_final.CategoryId = Producto.CategoryId;

            _context.Products.Add(Producto);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
