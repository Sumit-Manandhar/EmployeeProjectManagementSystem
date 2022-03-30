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
   public  class EmployeeRepo :IEmployeeRepo
    {
        private readonly Context context;
        public EmployeeRepo()
        {
            context = new Context();
        }

        public void Add(Employee data)
        {
            context.Employees.Add(data);
            context.SaveChanges();
        }

        public void Delete(Employee data)
        {
            context.Employees.Attach(data);
            context.Entry(data).State = EntityState.Deleted;
            context.SaveChanges();

        }

        public Employee GetById(int Id)
        {
            return context.Employees.FirstOrDefault(x => x.ID == Id);
        }

        public List<Employee> GetList()
        {
            //IQueryable<Users> i = context.Users;
            //var test = i.ToList();


            return context.Employees.ToList();
        }

        public void Update(Employee data)
        {
            var entity = GetById(data.ID);
            context.Entry(entity).State = EntityState.Detached;
            context.Employees.Attach(data);
            context.Entry(data).State = EntityState.Modified;

            context.SaveChanges();
        }
    }
}
