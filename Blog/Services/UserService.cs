﻿using Blog.Models.DAL;

namespace Blog.Services
{
    public class UserService : IUserService
    {
        private readonly Context db;

        public UserService(Context db)
        {
            this.db = db;
        }

        public bool IsEmailInUse(string email)
        {
            return db.Users.Any(u => u.Email == email);
        }
    }
}
