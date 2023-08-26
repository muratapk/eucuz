using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eucuz.Models
{
    public class siparisler
    {
        [Key]
        public  int siparis_Id { get; set; }
        [ForeignKey("Urunler")]
        public int urun_Id { get; set; }
        public Urunler Urunler { get; set; }
        public int adet { get; set; }
       
    }
}
