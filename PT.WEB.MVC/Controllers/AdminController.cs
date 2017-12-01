using Microsoft.AspNet.Identity;
using PT.BL.AccountRepository;
using PT.Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PT.WEB.MVC.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            var roles = MemberShipTools.NewManager().Roles.ToList();
            var userManager = MemberShipTools.NewUserManager();
            var users = userManager.Users.ToList().Select(x => new UsersViewModel
             
            {
                Email=x.Email,
                Name=x.Name,
                RegisterDate=x.RegisterDate,
                Salary=x.Salary,
                Surname=x.Surname,
                UserName=x.UserName,
                UserId=x.Id,
                RoleId=x.Roles.FirstOrDefault().RoleId,
                RoleName=roles.FirstOrDefault(y=>y.Id==userManager.FindById(x.Id).Roles.FirstOrDefault().RoleId).Name

            }).ToList();


            return View(users);
        }


        public ActionResult EditUser(string id)
        {
            if (id == null)
                RedirectToAction("Index");

            var roles = MemberShipTools.NewManager().Roles.ToList();

            List<SelectListItem> rolist = new List<SelectListItem>();
            roles.ForEach(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id
            });
            ViewBag.roles = rolist;

            var userManager = MemberShipTools.NewUserManager();
            var user = userManager.FindById(id);

            if (user == null)
                return RedirectToAction("Index");


           

            var model = new UsersViewModel()
            {
                UserName=user.UserName,
                Email=user.Email,
                Name=user.Name,
                Surname=user.Surname,
                RegisterDate=user.RegisterDate,
                RoleId=user.Roles.ToList().FirstOrDefault().RoleId,
                RoleName = roles.FirstOrDefault(y => y.Id == userManager.FindById(user.Id).Roles.FirstOrDefault().RoleId).Name,
                Salary=user.Salary,
                UserId=user.Id
            };

            return View(model);

            
        }
    }
}