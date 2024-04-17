using System.ComponentModel.DataAnnotations;

namespace Inz.Data
{
    internal class Settings
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string value { get; set; }
    }
}
