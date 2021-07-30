using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kitap_listeleme_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace kitap_listeleme_app.Pages.KitapListesi
{
    public class OlusturModel : PageModel
    {
        private readonly KLDbContext _db;
        public OlusturModel(KLDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Kitap Kitap { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                await _db.Kitap.AddAsync(Kitap);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }

    }
}
