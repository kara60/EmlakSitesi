using EmlakProject.Identity;
using EmlakProject.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmlakProject.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;
        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            UserManager = new UserManager<ApplicationUser>(userStore);
            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            RoleManager = new RoleManager<ApplicationRole>(roleStore);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login model, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = UserManager.Find(model.Username, model.Password);
                if (user != null)
                {
                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var identityclaims = UserManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = model.RememberMe;
                    authManager.SignIn(authProperties, identityclaims);
                    if (!String.IsNullOrEmpty(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("LoginUserError", "Kullanıcı bulunamadı!");
                }
            }
            return View(model);
        }

        public ActionResult LogOut()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
        //user get Register
        public ActionResult Register()
        {
            return View();
        }
        //user post register
        [HttpPost]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid) //Kullanıcı zorunlu alanları doldurmuşsa kayıt işlemleri yerine getiriliyor.
            {
                var user = new ApplicationUser();
                user.Name = model.Name;
                user.UserName = model.Username;
                user.Surname = model.Surname;
                user.Email = model.Email;
                var result = UserManager.Create(user, model.Password);
                if (result.Succeeded) //kayıt işleminin başarılı olup olmadığına bakıyorum.
                {
                    if (RoleManager.RoleExists("user")) // oluşturduğumuz rollerde user rolü var mı diye bakıyor
                    {
                        UserManager.AddToRole(user.Id, "user"); //yeni kullanıcıya default user rolü veriliyor
                    }
                    return RedirectToAction("Login", "Account"); // kayıt olunca logine git
                }
                else
                {
                    ModelState.AddModelError("RegisterUserError", "Kullanıcı oluşturma hatası!"); // hata varsa error ver
                }
            }
            return View(model);
        }
        //emlakci get register2
        public ActionResult Register2()
        {
            return View();
        }
        //emlakci post register2
        [HttpPost]
        public ActionResult Register2(Register model)
        {
            if (ModelState.IsValid) //Kullanıcı zorunlu alanları doldurmuşsa kayıt işlemleri yerine getiriliyor.
            {
                var user = new ApplicationUser();
                user.Name = model.Name;
                user.UserName = model.Username;
                user.Surname = model.Surname;
                user.Email = model.Email;
                var result = UserManager.Create(user, model.Password);
                if (result.Succeeded) //kayıt işleminin başarılı olup olmadığına bakıyorum.
                {
                    if (RoleManager.RoleExists("emlakci")) // oluşturduğumuz rollerde user rolü var mı diye bakıyor
                    {
                        UserManager.AddToRole(user.Id, "emlakci"); //yeni kullanıcıya default user rolü veriliyor
                    }
                    return RedirectToAction("Login", "Account"); // kayıt olunca logine git
                }
                else
                {
                    ModelState.AddModelError("RegisterUserError", "Kullanıcı oluşturma hatası!"); // hata varsa error ver
                }
            }
            return View(model);
        }

        //Get
        public ActionResult Profile()
        {
            var id = HttpContext.GetOwinContext().Authentication.User.Identity.GetUserId(); //Giriş yapan kullanıcının id sini verir.
            var user = UserManager.FindById(id); //Kullanıcıyı buluyoruz
            var data = new EditProfile()
            {
                id = user.Id,
                Name = user.Name,
                Username = user.UserName,
                Surname = user.Surname,
                Email = user.Email
            };

            return View(data);
        }
        [HttpPost]
        public ActionResult Profile(EditProfile model)
        {
            var user = UserManager.FindById(model.id); // Kullanıcıyı bulduk
            user.Name = model.Name;
            user.Surname = model.Surname;
            user.UserName = model.Username;
            user.Email = model.Email;
            UserManager.Update(user);

            return View("Update");
        }
        [HttpGet]

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult ChangePassword(ChangePassword model)
        {
            if (ModelState.IsValid) // Zorunlu alanlar doldurulmuş mu
            {
                var user = UserManager.ChangePassword(User.Identity.GetUserId(), model.OldPassword, model.NewPassword); //Kullanıcıyı bulur ve eski şifreyi yeni şifreyle değiştirir.
                return View("Update");
            }
            return View(model);
        }

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
    }
}