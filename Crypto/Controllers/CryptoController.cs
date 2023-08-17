using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Crypto.Controllers
{
    public class CryptoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}