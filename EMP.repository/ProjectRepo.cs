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
    public class ProjectRepo :IProjectRepo
    {
        private readonly Context context;
        public ProjectRepo()
        {
            context = new Context();
        }

        public void Add(Project data)
        {
            context.Projects.Add(data);
            context.SaveChanges();
        }

        public void Delete(Project data)
        {
            context.Projects.Attach(data);
            context.Entry(data).State = EntityState.Deleted;
            context.SaveChanges();

        }

        public Project GetById(int Id)
        {
            return context.Projects.FirstOrDefault(x => x.ID == Id);
        }

        public List<Project> GetList()
        {
            //IQueryable<Users> i = context.Users;
            //var test = i.ToList();


            return context.Projects.ToList();
        }

        public void Update(Project data)
        {
            var entity = GetById(data.ID);
            context.Entry(entity).State = EntityState.Detached;
            context.Projects.Attach(data);
            context.Entry(data).State = EntityState.Modified;

            context.SaveChanges();
        }

        //---

    }
}
