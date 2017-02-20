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
        private IList<UserViewModel> Users
        {
            get
            {
                if (Session["data"] == null)
                {
                    Session["data"] = new List<UserViewModel>(){
                        new UserViewModel {
                             Id = Guid.NewGuid(),
                             FirstName = "Lance",
                             Gender = "Male",
                             LastName = "Selot",
                             Age = 21
                        },
                        new UserViewModel {
                             Id = Guid.NewGuid(),
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
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Gender = user.Gender,
                                 Age = user.Age
                             }).ToList();
                return View(users);

            }
                    
        }

        // GET: Security/Users/Details/5
        public ActionResult Details(Guid id)
        {
            var m = Users.FirstOrDefault(user => user.Id == id);
            return View(m);
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
                        Id = Guid.NewGuid(),
                        FirstName = viewModel.FirstName,
                        Gender = viewModel.Gender,
                        LastName = viewModel.LastName,
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
        public ActionResult Edit(Guid Id)
        {
            var e = Users.FirstOrDefault(user => user.Id == Id);
            return View(e);
        }

        // POST: Security/Users/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid Id, UserViewModel usermodel)
        {
            try
            {
                // TODO: Add update logic here
              var e = Users.FirstOrDefault(user => user.Id == Id);

              e.FirstName = usermodel.FirstName;
              e.LastName = usermodel.LastName;
              e.Gender = usermodel.Gender;
              e.Age = usermodel.Age;

               
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Security/Users/Delete/5
        public ActionResult Delete(Guid id)
        {
            var u = Users.FirstOrDefault(user => user.Id == id);
            return View(u);
        }

        // POST: Security/Users/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var u = Users.FirstOrDefault(user => user.Id == id);
                Users.Remove(u);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
