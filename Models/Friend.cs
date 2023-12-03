namespace Pass_It_Out.Models
{
    public class Friend
    {
        public int Id { set; get; }
        public string UserId { set; get; }
        public string FriendId { set; get; }
        public string Status { set; get; }

        public DateTime RequestDate { set; get; }
        public DateTime? ConfirmDate { set; get; }

        // Navigation Property

        public User User { set; get; }
    }
}
