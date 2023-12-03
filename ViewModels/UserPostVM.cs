using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pass_It_Out.ViewModels
{
    public class UserPostVM
    {
        [Required(ErrorMessage = "Title cant be empty")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Category Id cant be empty")]
        public int CategoryId { set; get; }
        public string? Description { get; set; }
        public IFormFile? Upload_Images { set; get; }
        public string? Location { set; get;}
        public string? PostTo { get; set; }
        [Required(ErrorMessage = "Creater Name cant be empty")]
        public string? CreatedBy { set; get; }
        [Required(ErrorMessage = "Date cant be empty")]
        public DateTime CreatedDate { set; get; }
        public bool Status {  get; set; }
    }
}
