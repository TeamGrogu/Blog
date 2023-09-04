using Blog.Models;

namespace Blog.Services
{
    public interface IUserService
    {
        bool IsEmailInUse(string email);
    }
}
