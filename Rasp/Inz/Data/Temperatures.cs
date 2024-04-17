using System.ComponentModel.DataAnnotations;

namespace Inz.Data
{
    internal class Temperatures
    {
        [Required]
        public int id { get; set; }
        [Required] 
        public DateTime date { get; set; }
        [Required]
        public double outside_temperature { get; set; }
        [Required]
        public double inside_temperature { get; set; }
        [Required]
        public int measure_id { get; set; }
    }
}
