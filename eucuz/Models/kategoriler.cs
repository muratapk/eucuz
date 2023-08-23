using System.ComponentModel.DataAnnotations;

namespace eucuz.Models
{
    public class kategoriler
    {
        [Key]
        public int kategori_Id { get; set; }
        public string kategori_Ad {get; set; }

        public Urunler Urunler { get; set; }
    }
}
