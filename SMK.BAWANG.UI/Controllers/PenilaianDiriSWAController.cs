using SMK.BAWANG.UI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMK.BAWANG.UI.Controllers
{
    public class PenilaianDiriSWAController : Controller
    {
        // GET: PenilaianDiriSWA
        [CustomAuthorize("SWA")]
        public ActionResult Index()
        {
            return View();
        }
    }
}