using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarketWeb.Data;
using SupermarketWeb.Models;


namespace SupermarketWeb.Pages.Provedores
{
    public class CreateModel : PageModel
    {
        private readonly SumpermarketContext _context;

        public CreateModel(SumpermarketContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        [BindProperty]
        public Provider Provider { get; set; } = default;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Providers == null || Provider == null)
            {
                return Page();
            }

            _context.Providers.Add(Provider);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
