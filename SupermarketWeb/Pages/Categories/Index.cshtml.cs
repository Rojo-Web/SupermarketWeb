using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWeb.Data;
using SupermarketWeb.Models;

namespace SupermarketWeb.Pages.Categories
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly SumpermarketContext _Context;

        public IndexModel(SumpermarketContext context)
        {
            _Context = context;
        }

        public IList<Category> Categories { get; set; } = default!;
        public async Task OnGetAsync()
        {

            if(_Context.Categories != null)
            {
                Categories = await _Context.Categories.ToListAsync();
            }

        }
    }
}
