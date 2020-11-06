using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using T3_N00020449.Models;

namespace T3_N00020449.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly N00020449Context _context;
        public BaseController(N00020449Context context)
        {
            this._context = context;
        }
        protected User LoggedUser()
        {
            var claim = HttpContext.User.Claims.FirstOrDefault();
            var user = _context.Users.Where(o => o.Username == claim.Value).FirstOrDefault();
            return user;
        }
    }
}
