using System.ComponentModel.DataAnnotations;

namespace Inz.Data
{
    internal class Measures
    {
        [Required]
        public int id { get; set; }
        [Required]
        public bool is_active { get; set; }
        public DateTime start_time { get; set; }
        public DateTime? end_time { get; set; }
    }
}
