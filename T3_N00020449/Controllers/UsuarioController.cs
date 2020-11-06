using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using T3_N00020449.Models;

namespace T3_N00020449.Controllers
{
   
    public class UsuarioController : BaseController
    {
        private readonly N00020449Context _context;
        private readonly IConfiguration _configuration;
        public UsuarioController(N00020449Context context, IConfiguration configuration) : base(context)
        {
            this._context = context;
            this._configuration = configuration;

        }
        [HttpGet]
        public string LoggedUserView()
        {

            return "El usuario logueado es: " + LoggedUser().Id;
        }
        [HttpGet]
        public string Index(string input)
        {
            return CreateHash(input);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _context.Users.Where(o => o.Username == username && o.Password == CreateHash(password))
            .FirstOrDefault();
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username)
                };
                var claimsIdentity = new ClaimsIdentity(claims, "Login");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                HttpContext.SignInAsync(claimsPrincipal);

                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("Login", "Usuario o contraseña Incorrectos");
            return View();

        }
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
        private string CreateHash(string input)
        {
            var sha = SHA256.Create();
            input += _configuration.GetValue<string>("Token");
            var hash = sha.ComputeHash(Encoding.Default.GetBytes(input));
            return Convert.ToBase64String(hash);
        }
        [HttpGet]
        public ActionResult Registrar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registrar(User user, string password, string passwordConf, string email)
        {
            if (password != passwordConf) // <-- para convalidar contraseña y confirmacion de contraseña
                ModelState.AddModelError("PasswordConf", "Las contraseñas no coinciden");

            if (ModelState.IsValid)
            {
                user.Password = CreateHash(password);
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View("Registrar", user);
        }

    }
}
