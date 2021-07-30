using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kitap_listeleme_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace kitap_listeleme_app.Pages.KitapListesi
{
    public class DuzenleModel : PageModel
    {
        private readonly KLDbContext _db;
        public DuzenleModel(KLDbContext db)
        {
            _db = db;
        }
         [BindProperty]
        public Kitap kitap { get; set; }
        public async Task OnGet(int id)    
        {
            kitap = await _db.Kitap.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var DBGelenKitap = await _db.Kitap.FindAsync(kitap.Id);
                DBGelenKitap.KitapAd = kitap.KitapAd;
                DBGelenKitap.Yazar = kitap.Yazar;
                DBGelenKitap.ISBN = kitap.ISBN;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            else
            {
                return RedirectToPage();
            }
        }
    }
}
