using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWeb.Data;
using SupermarketWeb.Models;

namespace SupermarketWeb.Pages.Provedores
{
    public class DeleteModel : PageModel
    {
        private readonly SumpermarketContext _context;

        public DeleteModel(SumpermarketContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Provider Provider { get; set; } = default;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Providers == null)
            {
                return NotFound();

            }
            var provider = await _context.Providers.FirstOrDefaultAsync(m => m.Id == id);

            if (provider == null)
            {
                return NotFound();
            }
            else
            {
                Provider = provider;

            }
            return Page();

        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Providers == null)
            {
                return NotFound();
            }
            var provider = await _context.Providers.FindAsync(id);

            if (provider != null)
            {
                Provider = provider;
                _context.Providers.Remove(provider);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
