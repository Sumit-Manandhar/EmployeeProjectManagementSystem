using EMP.model;
using EMP.repository;
using EMP.repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagementMVC.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        private readonly IProjectRepo _repo;
        public ProjectController()
        {

            _repo = new ProjectRepo();
        }
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                return View(_repo.GetList());

            }
            else
            {
                return Redirect("~/user/login");
            }
            
        }

        // GET: Project/Details/5
        public ActionResult Details(int id)
        {
            if (Session["UserID"] != null)
            {
             return View(_repo.GetById(id));
                

            }
            else
            {
                return Redirect("~/user/login");
            }

        }

        // GET: Project/Create
        public ActionResult Create()
        {
            if (Session["UserID"] != null)
            {
                return View();

            }
            else
            {
                return Redirect("~/user/login");
            }
            
        }

        // POST: Project/Create
        [HttpPost]
        public ActionResult Create(Project data)
        {
            try
            {
                data.UserID = Convert.ToInt32(Session["UserID"]);
                _repo.Add(data);

                return RedirectToAction("Index");
            }
            catch
            {
                
                return Redirect("~/user/login");
            }
        }

        // GET: Project/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["UserID"] != null)
            {
              
            return View(_repo.GetById(id));

            }
            else
            {
                return Redirect("~/user/login");
            }
        }

        // POST: Project/Edit/5
        [HttpPost]
        public ActionResult Edit(Project data)
        {
            try
            {
                // TODO: Add update logic here
                data.UserID = Convert.ToInt32(Session["UserID"]);
                _repo.Update(data);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Project/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["UserID"] != null)
            {

                return View(_repo.GetById(id));

            }
            else
            {
                return Redirect("~/user/login");
            }
        }

        // POST: Project/Delete/5
        [HttpPost]
        public ActionResult Delete()
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
