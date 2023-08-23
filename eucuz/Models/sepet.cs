﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eucuz.Models
{
    public class sepet
    {
        [Key]
        public int sepet_Id { get; set; }
       
        [ForeignKey("Urunler")]
        public int urun_Id { get; set; }
        public int adet { get; set; }
        public ICollection<Urunler> urunlers { get; set; }
    }
}
