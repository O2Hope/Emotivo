using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Emotivo.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Emotivo.Web.Controllers
{
    public class PictureController : Controller
    {
        private EmitionContext _context;
        
        public PictureController()
        {
                
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

    }
}
