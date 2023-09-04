namespace Blog.Models.Entities
{
    public class Konu:BaseEntity
    {
        public string KonuAdi { get; set; }
        public ICollection<Makale>? Makale { get; set; }
    }
}
