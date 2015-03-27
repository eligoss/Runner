using Runner.BLL;
using Runner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Runner.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserProvider _userContext;

        public UsersController(IUserProvider users)
        {
            this._userContext = users;
        }

        public ActionResult Index()
        {
            return View(_userContext.GetAll());
        }

        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var user = _userContext.Get(id);
            return View(user);

        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Delete(Guid id)
        {
            _userContext.Remove(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            _userContext.Add(user);

            return RedirectToAction("Index");
        }
        

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }

            _userContext.Update(user);

            return RedirectToAction("Index");
        }
    }
}