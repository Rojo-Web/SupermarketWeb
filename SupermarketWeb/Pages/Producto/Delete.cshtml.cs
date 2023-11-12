using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWeb.Data;
using SupermarketWeb.Models;

namespace SupermarketWeb.Pages.Producto
{
    public class DeleteModel : PageModel
    {
        private readonly SumpermarketContext _context;

        public DeleteModel(SumpermarketContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Product Producto { get; set; } = default;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();

            }
            var producto = await _context.Products.FirstOrDefaultAsync(m => m.Id == id);

            if (producto == null)
            {
                return NotFound();
            }
            else
            {
                Producto = producto;

            }
            return Page();

        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }
            var producto = await _context.Products.FindAsync(id);

            if (producto != null)
            {
                Producto = producto;
                _context.Products.Remove(Producto);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
