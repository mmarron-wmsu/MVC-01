using dudungcharing.Areas.security.Models;
using Mydudungcharing.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dudungcharing.Areas.security.Controllers
{

    
    public class UsersController : Controller
    {
       
    private List<UserModel> users
        {
            get
            {
                if(Session["data"] == null){
                    Session["data"] = new List<UserModel>()
                    {
                        new UserModel() {id=Guid.NewGuid(), Firstname = "Ron", Lastname ="Cemine", Age = 24},
                        new UserModel() {id=Guid.NewGuid(), Firstname = "Ben", Lastname ="Tot", Age = 24}
                    };
                }
                return Session["data"] as List<UserModel>;
            }
            
        }

        // GET: security/Users
        public ActionResult Index()
        {
            using (var db = new DatabaseContext()   ) 
            {
                var users = (from user in db.Users
                             select new UserModel
                             {
                                 id = user.id,
                                 Firstname = user.Firstname,
                                 Lastname = user.Lastname,
                                 Age = user.Age
                             }).ToList();
                return View(users);
            }
           
        }
        
      
        // GET: security/Users/Details/5
        public ActionResult Details(Guid id)
        {
            UserModel model = users.Find(u => u.id == id);
            return View(model);
        }

        // GET: security/Users/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: security/Users/Create
        [HttpPost]
        public ActionResult Create(UserModel collection)
        {
            try
            {
                // TODO: Add insert logic here
                if(ModelState.IsValid == false){
                    return View();
                    using (var db = new DatabaseContext())
                    {
                        db.Users.Add(new User
                        {
                            id = Guid.NewGuid(),
                            Firstname = collection.Firstname,
                            Lastname = collection.Lastname,
                            Age = collection.Age
                        });
                    }
                }
               collection.id = Guid.NewGuid();
               users.Add(collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: security/Users/Edit/5
        public ActionResult Edit(String id)
        {
            try
            {
                UserModel model = users.Find(user => user.id == Guid.Parse(id));
                if (model == null)
                {
                    return View("Error");
                }
                return View(model);
            }
            catch
            {
                return View("Error");
            }
        }

        // POST: security/Users/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, UserModel collection)
        {
            try
            {
                // TODO: Add update logic here
                UserModel model = users.Find(user => user.id == id);
                model.Firstname = collection.Firstname;
                model.Lastname = collection.Lastname;
                model.Age = collection.Age;
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View("Error");
            }
        }

        // GET: security/Users/Delete/5
        public ActionResult Delete(Guid id)
        {
            UserModel model = users.Find(user => user.id == id);
            return View(model);
        }

        // POST: security/Users/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, UserModel collection)
        {
            try
            {
                // TODO: Add delete logic here
                UserModel model = users.Find(user => user.id == id);
                users.Remove(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
