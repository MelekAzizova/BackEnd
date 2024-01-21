using AzMB101_Melek_Azizova.Migrations;

namespace AzMB101_Melek_Azizova.ViewModels.ServiceVM
{
    public class ServiceListItemVM
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Position { get; set; }
       // public Position? Positions { get; set; }
    }
}
