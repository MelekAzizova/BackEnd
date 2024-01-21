using System.ComponentModel.DataAnnotations;

namespace AzMB101_Melek_Azizova.Models
{
    public class Message
    {
        public int Id { get; set; }
        [Required,MaxLength(64)]
        public string Name { get; set; }
        [Required, MaxLength(64)]
        public string Email { get; set; }
        [Required, MaxLength(128)]
        public string Subject { get; set; }
        [Required, MaxLength(256)]
        public string Messages { get; set; }
    }
}
