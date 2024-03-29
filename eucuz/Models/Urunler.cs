﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eucuz.Models
{
    public class Urunler
    {
        [Key]
        public int urun_Id { get; set; }
        public string urun_Adi { get; set; }
        public int urun_Kodu { get; set; }
        public int urun_fiyat { get; set; }
        public string resim { get; set; }
        public string aciklama { get; set; }
        public int indirim { get; set; }
        [ForeignKey("kategoriler")]
        public int kategori_Id { get; set; }
        public virtual kategoriler kategoriler { get; set; }    
        public string birim { get; set; }
        public string olcut { get; set; }
        [NotMapped]
        [Display(Name ="Resim Seçiniz")]
        
        public IFormFile resimyukle { get; set; }
        

        
        





    }
}
