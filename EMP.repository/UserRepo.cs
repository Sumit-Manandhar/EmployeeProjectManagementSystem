using EMP.core;
using EMP.model;
using EMP.repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMP.repository
{
    public class UserRepo :IUserRepo
    {
        private readonly Context context;
        public UserRepo()
        {
            context = new Context();
        }

        public void Add(User data)
        {
            context.Users.Add(data);
            context.SaveChanges();
        }

        public void Delete(User data)
        {
            context.Users.Attach(data);
            context.Entry(data).State = EntityState.Deleted;
            context.SaveChanges();

        }

        public User GetById(int Id)
        {
            return context.Users.FirstOrDefault(x => x.ID == Id);
        }

        public List<User> GetList()
        {
            IQueryable<User> i = context.Users;
            var test = i.ToList();


            return context.Users.ToList();
        }

        public bool ValidateUser(string userName, string password)
        {
            IQueryable<User> i = context.Users;
            var test = i.ToList().Where(u => u.Username == userName && u.Password == password).FirstOrDefault();
            if (test != null)
            {
                return true;
            }
            return false;
        }
        public User getUsername (string userName)
        {
            IQueryable<User> i = context.Users;
            var test = i.ToList().Where(u => u.Username == userName ).FirstOrDefault();
            return test;
        }

        public void Update(User data)
        {
            var entity = GetById(data.ID);
            context.Entry(entity).State = EntityState.Detached;
            context.Users.Attach(data);
            context.Entry(data).State = EntityState.Modified;

            context.SaveChanges();
        }

        public User GetByName(String username)
        {
            return context.Users.FirstOrDefault(x => x.Username == username);
        }
    }
}
