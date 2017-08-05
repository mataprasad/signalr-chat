using RentNDeal.Chat.Server.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace RentNDeal.Chat.Server.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Session["XYZ"] = "";
            return View();
        }

        public ActionResult Download(string fn, string afn)
        {
            var fileSavePath = HostingEnvironment.MapPath("~/Content/Uploads/" + afn);
            if (System.IO.File.Exists(fileSavePath))
            {
                return this.File(System.IO.File.ReadAllBytes(fileSavePath), "application/octet-stream", fn);
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Upload()
        {
            var fileName = Guid.NewGuid();
            var fileSavePath = HostingEnvironment.MapPath("~/Content/Uploads/");

            foreach (string postedFile in Request.Files)
            {
                HttpPostedFileBase file = Request.Files[postedFile];
                fileSavePath = Path.Combine(fileSavePath, fileName.ToString() + Path.GetExtension(file.FileName));
                file.SaveAs(fileSavePath);
            }

            return Json(new { Name = Path.GetFileName(fileSavePath) }, JsonRequestBehavior.AllowGet);
        }

        public void I1ndex()
        {
            try
            {
                var a = 0;
                var b = 9 / a;
            }
            catch (Exception e)
            {
                ExceptionManager.Instance.HandleException(e, "Exception @ GetProductSubCategories");
            }
            Response.Write(DateTime.Now);
        }
    }
}
