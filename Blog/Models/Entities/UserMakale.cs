namespace Blog.Models.Entities
{
    public class UserMakale:BaseEntity
    {
        public int UserID { get; set; }
        public int MakaleID { get; set; }
        public User? User { get; set; }
        public Makale? Makale { get; set; }
    }
}
