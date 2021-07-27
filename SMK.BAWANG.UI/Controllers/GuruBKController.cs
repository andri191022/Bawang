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
    public class GuruBKController : BaseController
    {
        public string userLogin = string.Empty;
        public string usrTypeLogin = string.Empty;
        // GET: GuruBK
        [CustomAuthorize("GBK")]
        public ActionResult Index()
        {
            List<tbl_guru_bk> objAll = new List<tbl_guru_bk>();

            try
            {               

                objAll = tbl_guru_bkItem.GetAll();

                return View(objAll);
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // GET: Default/Details/5
        [CustomAuthorize("GBK")]
        public ActionResult Details(string id)
        {
            tbl_guru_bk objAll = new tbl_guru_bk();
            try
            {
                objAll = tbl_guru_bkItem.GetByPK(id);

                return View(new m_tbl_guru_bk(objAll));
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // GET: Default/Create
        [CustomAuthorize("GBK")]
        public ActionResult Create()
        {

            try
            {
                tbl_guru_bk obj = new tbl_guru_bk();
                return View(new m_tbl_guru_bk(obj));
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // POST: Default/Create
        [CustomAuthorize("GBK")]
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                tbl_guru_bk obj = new tbl_guru_bk();
                obj.username = Request.Form["username"];
                obj.nama = Request.Form["nama"];
                obj.password = Request.Form["password"];
                obj.creator = userLogin;
                obj.created = DateTime.Now;

                tbl_guru_bkItem.Insert(obj);

                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj);
                return RedirectToAction("Create");
            }
        }

        // GET: Default/Edit/5
        [CustomAuthorize("GBK")]
        public ActionResult Edit(string id)
        {
            tbl_guru_bk objAll = new tbl_guru_bk();
            try
            {
                objAll = tbl_guru_bkItem.GetByPK(id);
                return View(new m_tbl_guru_bk(objAll));
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // POST: Default/Edit/5
        [CustomAuthorize("GBK")]
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                tbl_guru_bk obj = new tbl_guru_bk();
                obj.username = id;
                obj.nama = Request.Form["nama"];
                obj.password = Request.Form["password"];
                obj.editor = userLogin;
                obj.edited = DateTime.Now;

                tbl_guru_bkItem.Update(obj);

                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // GET: Default/Delete/5
        [CustomAuthorize("GBK")]
        public ActionResult Delete(string id)
        {
            try
            {
                tbl_guru_bkItem.Delete(id);

                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        //Custom
        [Authorize]
        public JsonResult IsAlreadyUsername(string username, string aeMode)
        {
            bool status;
            try
            {
                if (aeMode == "EDIT") { return Json(true, JsonRequestBehavior.AllowGet); }

                status = CheckUserName.IsAlreadyUsername(username);
                return Json(status, JsonRequestBehavior.AllowGet);
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj);

                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }

    }
}