using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YURent.Areas.Identity.Data;
using YURent.Data;
using YURent.Models;

namespace YURent.Controllers
{
    public class PainelController : Controller
    {
        private readonly YURentContext _context;

        public PainelController(YURentContext context)
        {
            _context = context;
        }

        public IActionResult Index() // ENTRAR NO PAINEL
        {
            return View();
        }

        
       



    }
}
