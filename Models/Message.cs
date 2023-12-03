namespace Pass_It_Out.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string UserId { set; get; }
        public string To { get; set; }
        public string Msg { get; set; }
        
        //Navigation property
        public User User { get; set; }
    }
}
