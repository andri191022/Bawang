using SMK.BAWANG.Dta.custom;
using SMK.BAWANG.Dto;
using SMK.BAWANG.UI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMK.BAWANG.UI.Controllers
{
   
    public class HomeWKLController : BaseController
    {
        [CustomAuthorize("WKL")]
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            if (Session["usrTypeLogin"] != null) { if (Session["usrTypeLogin"].ToString().ToUpper() != "WKL") { Response.Redirect("~/Login"); } }

            List<tbl_pengumuman> obj = new List<tbl_pengumuman>();
            try
            {
                obj = tbl_pengumuman_cstmItem.GetByDateAktif();

                return View(obj);
            }
            catch
            {
                return View(obj);
            }
        }
    }
} 