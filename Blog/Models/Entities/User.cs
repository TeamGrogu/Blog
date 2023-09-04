using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Identity;

namespace Blog.Models.Entities
{
    public class User: IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
<<<<<<< HEAD
        public string? Aciklama { get; set; }
        public string? Image { get; set; }
=======
        public string Aciklama { get; set; }
        public string Image { get; set; }
>>>>>>> d7d51f3a9139dc4b5d0e06acc339d406c540fb95
        public ICollection<Makale>? Makales { get; set; }
        public ICollection<UserMakale>? UserMakales { get; set; }
    }
}
