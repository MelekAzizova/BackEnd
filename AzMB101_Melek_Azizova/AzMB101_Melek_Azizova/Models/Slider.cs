using System.ComponentModel.DataAnnotations;

namespace AzMB101_Melek_Azizova.Models
{
	public class Slider
	{
		public int Id { get; set; }
		[Required,MaxLength(64)]
		public string Title { get; set; }
	}
}
