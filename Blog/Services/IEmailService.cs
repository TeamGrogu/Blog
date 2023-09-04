using Blog.Models;

namespace Blog.Services
{
    public interface IEmailService
    {
        void SendEmail(Message message);
    }
}
