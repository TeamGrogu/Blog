﻿namespace Blog.Models.Entities
{
    public class Makale:BaseEntity
    {
        public int KonuID { get; set; }
        public int YazarID { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public int OkunmaSayisi { get; set; }
        public int OkunmaSuresi { get; set; }
        public User? User { get; set; }
        public Konu? Konu { get; set;}
        public ICollection<UserMakale>? UserMakales { get; set; }
    }
}
