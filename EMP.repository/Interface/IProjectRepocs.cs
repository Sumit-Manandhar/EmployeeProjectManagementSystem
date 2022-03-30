using EMP.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMP.repository.Interface
{
    public interface IProjectRepo
    {
        void Add(Project data);
        void Delete(Project data);
        Project GetById(int Id);
        List<Project> GetList();
        void Update(Project data);
    }
}
