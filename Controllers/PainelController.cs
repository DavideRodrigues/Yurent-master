using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace YURent.Controllers
{
    public class PainelController : Controller
    {
        public IActionResult Index() // ENTRAR NO PAINEL
        {
            return View();
        }
    }
}
