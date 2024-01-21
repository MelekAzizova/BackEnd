using System.ComponentModel.DataAnnotations;

namespace AzMB101_Melek_Azizova.Models
{
    public class Position
    {
        public int Id { get; set; }
        [Required,MaxLength(64)]
        public string Name { get; set; }
       // public List<Worker> Workers { get; set;}
    }
}
