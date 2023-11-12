using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWeb.Data;
using SupermarketWeb.Models;

namespace SupermarketWeb.Pages.PayModee
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly SumpermarketContext _Context;

        public IndexModel(SumpermarketContext context)
        {
            _Context = context;
        }

        public IList<PayMode> PayMode { get; set; } = default!;
        public async Task OnGetAsync()
        {

            if (_Context.PayModes != null)
            {
                PayMode = await _Context.PayModes.ToListAsync();
            }

        }
    }
}
