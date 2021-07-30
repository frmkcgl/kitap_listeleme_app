using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kitap_listeleme_app.Models
{
    public class Kitap
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Lütfen bu alanı boş bırakmayınız...")]
        public string KitapAd { get; set; }
        public string Yazar { get; set; }
        public string ISBN { get; set; }
    }
}