using System.ComponentModel.DataAnnotations;

namespace AzMB101_Melek_Azizova.Models
{
    public class Service
    {
        public int Id { get; set; }
        [Required,MaxLength(128)]
        public string Image { get; set; }
        [Required, MaxLength(64)]
        public string Title { get; set; }
        [Required, MaxLength(64)]
        public string Position { get; set; }
        //public Position? Position {  get; set; }
        //public int PositionId { get; set; }
    }
}
