using System.ComponentModel.DataAnnotations;

namespace MCQApplication.Models
{
	public class Syit
	{
		[Key]
		public string Question { get; set; }
		[Required]
		public string OptionA { get; set; }
		[Required]
		public string OptionB { get; set; }
		[Required]
		public string OptionC { get; set; }
		[Required]
		public string OptionD { get; set; }
		[Required]
		public string Answer { get; set; }
	}
}
