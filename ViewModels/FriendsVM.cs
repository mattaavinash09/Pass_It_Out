using System.ComponentModel.DataAnnotations;

namespace Pass_It_Out.ViewModels
{
    public class FriendsVM
    {
        //[Required(ErrorMessage ="UserId Cant be empty")]
        //public string UserId { set; get; }

        [Required(ErrorMessage = "FriendId Cant be empty")]
        public string FriendId { set; get; }
        public string Status { set; get; }

        public DateTime RequestDate { set; get; }
        public DateTime ConfirmDate { set; get; }
    }
}
