using System.ComponentModel.DataAnnotations;

namespace AzMB101_Melek_Azizova.ViewModels.MessageVM
{
    public class MessageListItemVM
    {
        public int Id { get; set; }
       
        public string Name { get; set; }
       
        public string Email { get; set; }
       
        public string Subject { get; set; }
        
        public string Messages { get; set; }
    }
}
