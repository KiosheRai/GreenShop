using GreenShop.DataContext;
using GreenShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            var user = _context.Users.Include(x => x.Role).FirstOrDefault(x => x.Login == login && x.Password == hashPassword);
            return user;
        }

        public bool IsUserExists(string login)
        {
            var user = _context.Users.FirstOrDefault(x => x.Login == login);
            if (user == null)
                return false;
            return true;
        }

        public Role GetDefaultRole()
        {
            return _context.Roles.First(x=>x.Id == Guid.Parse("50D40CB8-17C6-4829-9505-5D99AE9E0F66")); ;
        }

        public List<Good> GetGoods()
        {
            return _context.Goods.ToList();
        }

        public Good GetGoodById(Guid id)
        {
            return _context.Goods.First(x=>x.Id == id); 
        }

        public void AddOrder(List<GoodsList> goodsList, Order order)
        {
            order.Status = Status.Confirmed;
            _context.Orders.Add(order);
            _context.GoodsLists.AddRange(goodsList);
            _context.SaveChanges();
        }

        public List<Order> GetOrdersByUser(Guid id)
        {
            return _context.Orders.Where(x => x.User.Id == id).ToList();
        }
    }
}
