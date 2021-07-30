using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kitap_listeleme_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace kitap_listeleme_app.Pages.KitapListesi
{
    public class GuncelleEkleModel : PageModel
    {
        private readonly KLDbContext _db;
        public GuncelleEkleModel(KLDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Kitap kitap { get; set; }
        public async Task<IActionResult> OnGet(int? id)
        {
            kitap = new Kitap();
            if (id == null)
            {
                return Page();
            }
            kitap = await _db.Kitap.FirstOrDefaultAsync(x => x.Id == id);
            if (kitap == null)
            {
                return NotFound();
            }
            return Page();
                
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if(kitap.Id==0)
                {
                    _db.Kitap.Add(kitap);
                }
                else
                {
                    //var DBGelenKitap = await _db.Kitap.FindAsync(kitap.Id);
                    //DBGelenKitap.KitapAd = kitap.KitapAd;
                    //DBGelenKitap.Yazar = kitap.Yazar;
                    //DBGelenKitap.ISBN = kitap.ISBN;

                    _db.Kitap.Update(kitap);
                }
               

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
