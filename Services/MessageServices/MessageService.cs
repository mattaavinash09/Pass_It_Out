using Pass_It_Out.Context;
using Pass_It_Out.Models;

namespace Pass_It_Out.Services.MessageServices
{
    public class MessageService : IMessage
    {
        private Pass_It_Out_CTX ctx;

        public MessageService(Pass_It_Out_CTX ctx)
        {
            this.ctx = ctx;
        }
        public List<Message> GetAllMessages(string CurrentUserId)
        {
            List<Message> messages= ctx.Messages.Where(val => val.To == CurrentUserId).ToList();
            return messages;
        }

        public bool Save(Message message)
        {
            ctx.Messages.Add(message);
            int rowsupdated = ctx.SaveChanges();
            return rowsupdated > 0;
        }
    }
}
