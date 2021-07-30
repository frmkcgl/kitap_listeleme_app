using kitap_listeleme_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kitap_listeleme_app.Controllers
{
    [Route("api/Kitap")]
    [ApiController]
    public class KitapController : Controller
    {
        private readonly KLDbContext _db;
        public KitapController(KLDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Kitap.ToListAsync() });
        }


        public async Task<IActionResult> Sil(int id)
        {
            var DBGelenKitap = await _db.Kitap.FirstOrDefaultAsync(x => x.Id == id);
            if(DBGelenKitap==null)
            {
                return Json(new { success = false, message = "Silme işleminde hata oluştu...!" });
            }

            _db.Kitap.Remove(DBGelenKitap);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Silme işlemi başarılı.." });

        }

    }
}
