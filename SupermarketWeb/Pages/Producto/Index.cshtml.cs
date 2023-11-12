using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarketWeb.Data;
using SupermarketWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace SupermarketWeb.Pages.Producto
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly SumpermarketContext _Context;

        public IndexModel(SumpermarketContext context)
        {
            _Context = context;
        }

        public IList<Product> Products { get; set; } = default!;
        public async Task OnGetAsync()
        {

            if (_Context.Products != null)
            {
                Products = await _Context.Products.ToListAsync();
            }

        }
    }
}
