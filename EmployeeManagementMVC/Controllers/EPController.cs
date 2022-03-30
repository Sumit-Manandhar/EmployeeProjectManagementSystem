using EMP.model;
using EMP.repository;
using EMP.repository.Interface;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagementMVC.Controllers
{
    public class EPController : Controller
    {
        private readonly IEPRepo _repo;
        public class model
        {
            public List<Project> projectsddl { get; set; }
            public List<Employee> Employeeddl { get; set; }
        }
        public EPController()
        {
            _repo = new EPRepo();
        }
        // GET: EP
        public ActionResult Index()
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

        // GET: EP/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EP/Create
        public ActionResult Create()
        {
            if (Session["UserID"] != null)
            {

                return View() ;

            }
            else
            {
                return Redirect("~/user/login");
            }


        }

        // POST: EP/Create
        [HttpPost]
        public ActionResult Create(EmployeeProjectMaster entity)
        {
            try
            {
                
                _repo.insertUpdateEP(entity);
                // TODO: Add insert logic here

                string message = "SUCCESS";
                return Json(new { Message = message, JsonRequestBehavior.AllowGet });
            }
            catch
            {
               
                return View();
            }
        }

        // GET: EP/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EP/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EP/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EP/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
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
        public JsonResult GetEmployee()
        {
            EmployeeProjectMaster EList = new EmployeeProjectMaster
            {
                EmployeeList = _repo.EmployeeDDL(),

            };
            return Json(EList.EmployeeList, JsonRequestBehavior.AllowGet);
        } public JsonResult GetProject()
        {
            EmployeeProjectDetails Plist = new EmployeeProjectDetails
            {
                ProjectList = _repo.ProjectDDL(),

            };
            return Json(Plist.ProjectList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetReport(String Name)
        {
            

            return Json(_repo.getReports(Name), JsonRequestBehavior.AllowGet);
        }

    }
}
