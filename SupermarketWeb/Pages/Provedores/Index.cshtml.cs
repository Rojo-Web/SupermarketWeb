using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWeb.Data;
using SupermarketWeb.Models;

namespace SupermarketWeb.Pages.Provedores
{
    public class IndexModel : PageModel
    {
        private readonly SumpermarketContext _Context;

        public IndexModel(SumpermarketContext context)
        {
            _Context = context;
        }

        public IList<Provider> Provedores { get; set; } = default!;
        public async Task OnGetAsync()
        {

            if (_Context.Providers != null)
            {
                Provedores = await _Context.Providers.ToListAsync();
            }

        }
    }
}
