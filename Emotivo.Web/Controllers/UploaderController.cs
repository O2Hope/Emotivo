using System.IO;
using System.Threading.Tasks;
using Emotivo.Web.Helpers;
using Emotivo.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Emotivo.Web.Controllers
{
    public class UploaderController : Controller
    {
        private EmotionHelper _helper;
        private string key = "2afa168d4b6447838e234e43924a0cbe";
        private EmitionContext _context = new EmitionContext();

        public UploaderController()
        {
            _helper = new EmotionHelper(key);
        }
        
        // GET
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(IFormFile file )
        {

            var path = Path.GetTempFileName();
            
            if (file.Length > 0)
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);

                   var picture = await _helper.DetectAndExtractAsync(stream);

                    picture.Name = file.FileName;
                    picture.Path = path;

                    await _context.Pictures.AddAsync(picture);

                }
            }
            
            
            
            return View();
        }
    }
}