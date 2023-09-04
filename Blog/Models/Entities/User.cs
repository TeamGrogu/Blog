using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Identity;

namespace Blog.Models.Entities
{
    public class User: IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public string Aciklama { get; set; }
        public string Image { get; set; }
        public ICollection<Makale>? Makales { get; set; }
        public ICollection<UserMakale>? UserMakales { get; set; }
    }
}
