using System.ComponentModel.DataAnnotations;

namespace MCQApplication.Models
{
    public class Feedback
    {
        [Required]
        public string ID { get; set; }
        [Required]
        public string Review { get; set; }
    }
}
