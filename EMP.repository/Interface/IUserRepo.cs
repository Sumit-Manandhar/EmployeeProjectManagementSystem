using EMP.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMP.repository.Interface
{
    public interface IUserRepo
    {
     void Add(User data);
     void Delete(User data);
      User GetById(int Id);
      List<User> GetList();
      bool ValidateUser(string userName, string password);
     void Update(User data);
        User getUsername(string userName);





    }
}
