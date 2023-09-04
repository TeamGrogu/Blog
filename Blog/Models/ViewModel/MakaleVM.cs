using Blog.Models.Entities;

namespace Blog.Models.ViewModel
{
    public class MakaleVM
    {
        public ICollection<Makale> Makaleler { get; set; }
        public Makale Makale { get; set; }
        public User Yazar { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Konu> Konular { get; set; }
    }
}
