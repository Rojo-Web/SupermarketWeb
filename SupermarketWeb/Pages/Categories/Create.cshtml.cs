using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarketWeb.Data;
using SupermarketWeb.Models;

namespace SupermarketWeb.Pages.Categories
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
        public Category Category { get; set; } = default;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Categories == null || Category == null)
            {
                return Page();
            }

            _context.Categories.Add(Category);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
