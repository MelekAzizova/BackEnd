using AzMB101_Melek_Azizova.Models;

namespace AzMB101_Melek_Azizova.ViewModels.HomeVM
{
	public class HomeVM
	{
		public ICollection<Service> Services { get; set; }
		public ICollection<Worker> Workers { get; set; }
		public ICollection<Slider> Sliders { get; set; }
		public ICollection<Message> Messages { get; set; }

	}
}
