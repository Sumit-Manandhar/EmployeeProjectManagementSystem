using EMP.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMP.repository.Interface
{
    public interface IEmployeeRepo
    {
        void Add(Employee data);
        void Delete(Employee data);
        Employee GetById(int Id);
        List<Employee> GetList();
        void Update(Employee data);
    }
}
