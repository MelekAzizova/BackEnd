using System.ComponentModel.DataAnnotations;

namespace AzMB101_Melek_Azizova.Models
{
    public class Worker
    {
        public int Id { get; set; }
        [Required, MaxLength(64)]
        public string Name { get; set; }
        [Required, MaxLength(128)]
        public string Image { get; set; }
        //public Position? Position { get; set; }
        //public int PositionId { get; set; }
    }
}
