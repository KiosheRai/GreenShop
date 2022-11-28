﻿using GreenShop.DataContext;
using GreenShop.Models;
using System;
using System.Linq;

namespace GreenShop.Service
{
    public class GreenShopManager
    {
        private readonly GreenShopDbContext _context;

        public GreenShopManager() =>
            _context = new GreenShopDbContext();

        public void RegisterUser(User user)
        {
            user.Id = new Guid();
            user.Password = Hash.Generate(user.Password);
            user.Role = GetDefaultRole();

            _context.Add(user);
            _context.SaveChanges();
        }

        public User GetUserWithPassword(string login, string password)
        {
            var hashPassword = Hash.Generate(password);
            var user = _context.User.FirstOrDefault(x => x.Login == login && x.Password == hashPassword);
            return user;
        }

        public bool IsUserExists(string login)
        {
            var user = _context.User.FirstOrDefault(x => x.Login == login);
            if (user == null)
                return true;
            return false;
        }

        public Role GetDefaultRole()
        {
            return _context.Role.First(x=>x.Id == Guid.Parse("50D40CB8-17C6-4829-9505-5D99AE9E0F66")); ;
        }
    }
}