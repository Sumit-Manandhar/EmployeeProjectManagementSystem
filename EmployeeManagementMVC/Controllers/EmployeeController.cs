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
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepo _repo;

        public EmployeeController()
        {
            _repo = new EmployeeRepo();
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

        // GET: Employee/Details/5
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

        // GET: Employee/Create
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

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee entity)
        {
            try
            {
                entity.UsersID = Convert.ToInt32( Session["UserID"]);
                _repo.Add(entity);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
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

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(Employee entity)
        {
            try
            {

                _repo.Update(entity);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
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

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(Employee entity)
        {
            try
            {
                _repo.Delete(entity);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
