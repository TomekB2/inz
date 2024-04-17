using System.ComponentModel.DataAnnotations;

namespace Inz.Data
{
    public class User
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string password { get; set; }
    }
}