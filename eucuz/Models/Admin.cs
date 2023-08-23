using System.ComponentModel.DataAnnotations;

namespace eucuz.Models
{
    public class Admin
    {
        [Key]
        public int admin_Id { get; set; }
        public string email { get; set; }

        public string password { get; set; }    
    }
}
