using System.ComponentModel.DataAnnotations.Schema;

namespace Pass_It_Out.Models
{
    public class Post
    {
        public int Id { get; set; }

        //[ForeignKey("UserId")]
        public String UserId { get; set; }

        public string Title { get; set; }

        public int CategoryId { set; get; }
        public string Description { get; set; }
        public byte[] Upload_Images { set; get; }

        public string Location { set; get; }

        public string PostTo { get; set; }

        public string CreatedBy { set; get; }
        public string CreatedDate { set; get; }

        public bool Status { set; get; }

        //Navigation Properties

        public User User { set; get; }
    }
}
