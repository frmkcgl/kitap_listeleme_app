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
    public class IndexModel : PageModel
    {
        private readonly KLDbContext _db;
        public IndexModel(KLDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Kitap> Kitaplar { get; set; }
        public async Task OnGet()
        {
            Kitaplar = await _db.Kitap.ToListAsync();
        }

        public async Task<IActionResult> OnPostSil (int id)
        {
            var kitap = await _db.Kitap.FindAsync(id);
            if(kitap==null)
            {
                return NotFound();
            }
            _db.Kitap.Remove(kitap);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
