using Pass_It_Out.Models;

namespace Pass_It_Out.Services.MessageServices
{
    public interface IMessage
    {
        public bool Save(Message message);
        public List<Message> GetAllMessages(string CurrentUserId);
    }
}
