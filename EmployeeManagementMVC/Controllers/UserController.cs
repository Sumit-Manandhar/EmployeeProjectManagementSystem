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
    public class UserController : Controller
    {
        private readonly IUserRepo _repo;
        public UserController()
        {
            _repo = new UserRepo();
        }
        // GET: User
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                 return View(_repo.GetList());
                
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            if (Session["UserID"] != null)
            {
            return View(_repo.GetById(id));
               
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        // GET: User/Create
        public ActionResult Create()
        {
                return View();
           
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User data)
        {
            try
            {
                var keyNew = Helper.GeneratePassword(10);
                var password = Helper.EncodePassword(data.Password, keyNew);
                data.VCode = keyNew;
                data.Password = password;
                _repo.Add(data);
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["UserID"] != null)
            {
                return View(_repo.GetById(id));
                
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(User data)
        {
            try
            {
                var keyNew = Helper.GeneratePassword(10);
                var password = Helper.EncodePassword(data.Password, keyNew);
                data.VCode = keyNew;
                data.Password = password;
                _repo.Update(data);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["UserID"] != null)
            {
             return View(_repo.GetById(id));
                
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(User data)
        {
            try
            {
                _repo.Delete(data);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(User entity)
            {


            var getUser = _repo.getUsername(entity.Username);

            if(getUser != null)
            {
                var hashCode = getUser.VCode;
                var encodingPasswordString = Helper.EncodePassword(entity.Password, hashCode);


                var data = _repo.ValidateUser(entity.Username, encodingPasswordString);
                if (data == true)
                {
                    Session["UserID"] = getUser.ID.ToString();
                    Session["UserName"] = getUser.Username.ToString();
                    return RedirectToAction("Dashboard");
                }
                else
                {
                    ViewBag.ErrorMessage = "Invallid User Name or Password";
                    return View();
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Invallid User Name or Password";
                return View();
            }
            
            
        }

        public ActionResult Dashboard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        [HttpPost]
        public ActionResult dashboard()
        {
            Session["UserID"] =null;
            Session["UserName"] =null;
            return RedirectToAction("login");
            //return View();
        }
    }
}
