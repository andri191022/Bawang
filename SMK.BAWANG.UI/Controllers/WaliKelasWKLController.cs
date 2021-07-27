using SMK.BAWANG.Dta;
using SMK.BAWANG.Dto;
using SMK.BAWANG.Logic;
using SMK.BAWANG.UI.Infrastructure;
using SMK.BAWANG.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace SMK.BAWANG.UI.Controllers
{
    public class WaliKelasWKLController : BaseController
    {
        public string userLogin = string.Empty;
        public string usrTypeLogin = string.Empty;

        [CustomAuthorize("WKL")]
        // GET: WaliKelasWKL
        public ActionResult Index()
        {
            try
            {               
                userLogin = Session["userLogin"].ToString();

                tbl_wali_kelas obj = new tbl_wali_kelas();
                obj = tbl_wali_kelasItem.GetByPK(userLogin);
                return View(new m_tbl_wali_kelas(obj));
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        [CustomAuthorize("WKL")]
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                userLogin = Session["userLogin"].ToString();

                tbl_wali_kelas obj = new tbl_wali_kelas();
                obj.username = Request.Form["username"];
                obj.nama = Request.Form["nama"];
                obj.password = Request.Form["password"];
                obj.wali_kelas = Request.Form["wali_kelas"];
                obj.editor = userLogin;
                obj.edited = DateTime.Now;

                tbl_wali_kelasItem.Update(obj);

                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }


    }
}