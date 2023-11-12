using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWeb.Data;
using SupermarketWeb.Models;

namespace SupermarketWeb.Pages.Usuario
{
    public class IndexModel : PageModel
    {
        private readonly SumpermarketContext _Context;

        public IndexModel(SumpermarketContext context)
        {
            _Context = context;
        }

        public IList<User> Users { get; set; } = default!;
        public async Task OnGetAsync()
        {

            if (_Context.Users != null)
            {
                Users = await _Context.Users.ToListAsync();
            }

        }
    }
}
