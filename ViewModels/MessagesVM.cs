using System.ComponentModel.DataAnnotations;

namespace Pass_It_Out.ViewModels
{
    public class MessagesVM
    {
        
        [Required]
        public string To { get; set; }
        [Required]
        public string Msg { get; set; }
    }
}
