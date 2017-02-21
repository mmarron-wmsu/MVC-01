using MuksanDemo.Areas.Security.Models;
using MuksanDemo.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MuksanDemo.Areas.Security.Controllers
{
    public class UsersController : Controller
    {
        // GET: security/Users
        public ActionResult Index()
        {
            using (var db = new DatabaseContext())
            {
                var users = (from user in db.Users
                             select new UserViewModel
                             {
                                 Id = user.Id,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Age = user.Age,
                                 Gender = user.Gender,
                                 EmploymentDate = user.EmploymentDate
                             }).ToList();
                return View(users);
            }

        }

        // GET: security/Users/Details/5
        public ActionResult Details(int id)
        {
            using (var db = new DatabaseContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Id == id);
                UserViewModel viewModel = new UserViewModel()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Age = user.Age,
                    Gender = user.Gender,
                    EmploymentDate = user.EmploymentDate
                };
                return View(viewModel);
            }
        }

        // GET: security/Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: security/Users/Create
        [HttpPost]
        public ActionResult Create(UserViewModel viewModel)
        {
            if (ModelState.IsValid == false)
            {
                return View();
            }
            try
            {
                using (var db = new DatabaseContext())
                {
                    db.Users.Add(new User
                    {
                        //Id = int.NewGuid(),
                        FirstName = viewModel.FirstName,
                        LastName = viewModel.LastName,
                        Age = viewModel.Age,
                        Gender = viewModel.Gender,
                        EmploymentDate = viewModel.EmploymentDate
                    });
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: security/Users/Edit/5
        public ActionResult Edit(int id)
        {
            using (var db = new DatabaseContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Id == id);
                UserViewModel viewModel = new UserViewModel()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Age = user.Age,
                    Gender = user.Gender,
                    EmploymentDate = user.EmploymentDate
                };
                return View(viewModel);
            }
        }

        // POST: security/Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UserViewModel viewModel)
        {
            try
            {
                using (var db = new DatabaseContext())
                {
                    var user = db.Users.FirstOrDefault(u => u.Id == id);
                    user.FirstName = viewModel.FirstName;
                    user.LastName = viewModel.LastName;
                    user.Age = viewModel.Age;
                    user.Gender = viewModel.Gender;
                    //EmploymentDate = viewModel.EmploymentDate;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: security/Users/Delete/5
        public ActionResult Delete(int id)
        {
            using (var db = new DatabaseContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Id == id);
                UserViewModel viewModel = new UserViewModel()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Age = user.Age,
                    Gender = user.Gender,
                    EmploymentDate = user.EmploymentDate
                };
                return View(viewModel);
            }
        }

        // POST: security/Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (var db = new DatabaseContext())
                {
                    var user = db.Users.FirstOrDefault(u => u.Id == id);
                    db.Users.Remove(user);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public int? EmploymentDate { get; set; }
    }
}
