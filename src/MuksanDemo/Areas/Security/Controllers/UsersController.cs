using MuksanDemo.Areas.Security.Models;
using MuksanDemo.Dal;
using Mydudungcharing.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MuksanDemo.Areas.Security.Controllers
{
    public class UsersController : Controller
    {
        private IList<UserViewModel> Users
        {
            get
            {
                if (Session["data"] == null)
                {
                    Session["data"] = new List<UserViewModel>(){
                        new UserViewModel {
                             //Id = Guid.NewGuid(),
                             FirstName = "Lance",
                             Gender = "Male",
                             LastName = "Selot",
                             Age = 21
                        },
                        new UserViewModel {
                             //Id = Guid.NewGuid(),
                             FirstName = "Lance",
                             Gender = "Female",
                             LastName = "Oscar",
                             Age = 59
                        }
                    };
                }
                return Session["data"] as List<UserViewModel>;
            }
        }
        // GET: Security/Users
        public ActionResult Index()
        {
            using(var db = new DatabaseContext())
            {
                var users = (from user in db.Users
                             select new UserViewModel
                             {
                                 Id = user.Id,
                                 FirstName = user.Firstname,
                                 LastName = user.Lastname,
                                 Gender = user.Gender,
                                 Age = user.Age
                             }).ToList();
                return View(users);

            }
                    
        }

        // GET: Security/Users/Details/5
        public ActionResult Details(int id)
        {
            using (var db = new DatabaseContext())
            {
                var users = (from user in db.Users
                             where user.Id == id
                             select new UserViewModel
            {
                Id = user.Id,
                FirstName = user.Firstname,
                Gender = user.Gender,
                LastName = user.Lastname,
                Age = user.Age
            }).FirstOrDefault();
                return View(users);
            }
        }

        // GET: Security/Users/Create
        public ActionResult Create()
        {
            ViewBag.Gender = new List<SelectListItem>{
            {
                new SelectListItem
                {
                    Value ="Male",
                    Text = "Male"
                }
            },
            new SelectListItem
                {
                    Value = "Female",
                    Text = "Female"
                }
            
            };
             return View();
        }


        // POST: Security/Users/Create
        [HttpPost]
        public ActionResult Create(UserViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid == false)
                    return View();
                using (var db = new DatabaseContext())
                {
                    db.Users.Add(new User 
                    {
                        //ID = Guid.NewGuid(),
                        Firstname = viewModel.FirstName,
                        Gender = viewModel.Gender,
                        Lastname = viewModel.LastName,
                        Age = viewModel.Age
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

        // GET: Security/Users/Edit/5
        public ActionResult Edit(int id)
        {
            using (var db = new DatabaseContext())
            {
                var users = (from user in db.Users
                             where user.Id == id
                             select new UserViewModel
                             {
                                 Id = user.Id,
                                 FirstName = user.Firstname,
                                 Gender = user.Gender,
                                 LastName = user.Lastname,
                                 Age = user.Age
                             }).FirstOrDefault();
                return View(users);
            }
        }

        // POST: Security/Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UserViewModel viewModel)
        {
            try
            {
                // TODO: Add update logic here
             if (ModelState.IsValid == false)
                    return View();
                using (var db = new DatabaseContext())
                {
                    var users = (from user in db.Users
                                 where user.Id == id
                                 select user).FirstOrDefault();
               
                       //ID = Guid.NewGuid(),
                        users.Firstname = viewModel.FirstName;
                        users.Gender = viewModel.Gender;
                        users.Lastname = viewModel.LastName;
                        users.Age = viewModel.Age;

                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Security/Users/Delete/5
        public ActionResult Delete(int id)
        {
            using (var db = new DatabaseContext())
            {
                var users = (from user in db.Users where user.Id == id
                                 select new UserViewModel
                {
                    Id = user.Id,
                    FirstName = user.Firstname,
                    Gender = user.Gender,
                    LastName = user.Lastname,
                    Age = user.Age
                }).FirstOrDefault();
                return View(users);
            }
           
        }

        // POST: Security/Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            //try
            //{
                // TODO: Add delete logic here

                using (var db = new DatabaseContext())
                {
                    var users = (from user in db.Users
                                 where user.Id == id
                                 select user).FirstOrDefault();
                    db.Users.Remove(users);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }

    }
}
