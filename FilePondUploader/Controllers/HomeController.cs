using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FilePondUploader.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveFile()
        {
            string fileName = "";
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];
                var id = Request.Headers["id"];

                if (file != null && file.ContentLength > 0)
                {
                    fileName = file.FileName;
                    file.SaveAs(Server.MapPath($"/Content/{file.FileName}"));
                }
            }

            return Json(fileName);
        }

        public ActionResult DeleteFile()
        {
            var id = Request.Headers["id"];

            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    file.SaveAs(Server.MapPath($"/Content/{file.FileName}"));
                }
            }

            return Json(true);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}