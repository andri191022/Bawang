using SMK.BAWANG.Dta;
using SMK.BAWANG.Dta.custom;
using SMK.BAWANG.Dto;
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

    public class PengumumanController : BaseController
    {
        // GET: Pengumuman
        public string userLogin = string.Empty;
        public string usrTypeLogin = string.Empty;

        [CustomAuthorize("GBK")]
        public ActionResult Index()
        {
            List<tbl_pengumuman> obj = new List<tbl_pengumuman>();

            try
            {
                if (Session["usrTypeLogin"] != null) { if (Session["usrTypeLogin"].ToString().ToUpper() != "GBK") { Response.Redirect("~/Login"); } }

                obj = tbl_pengumumanItem.GetAll();

                return View(obj);
            }
            catch
            {
                return View(obj);
            }

        }

        // GET: Default/Details/5
        [CustomAuthorize("GBK")]
        public ActionResult Details(int id)
        {
            tbl_pengumuman objAll = new tbl_pengumuman();
            try
            {
                objAll = tbl_pengumumanItem.GetByPK(id);
                return View(new m_tbl_pengumuman(objAll));
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
            tbl_pengumuman objAll = new tbl_pengumuman();
            try
            {
                return View(new m_tbl_pengumuman(objAll));
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
                userLogin = Session["userLogin"].ToString();
                tbl_pengumuman obj = new tbl_pengumuman();
                obj.no = Request.Form["no"];
                obj.tanggal = Convert.ToDateTime(Request.Form["tanggal"]);
                obj.tanggal_hingga = Convert.ToDateTime(Request.Form["tanggal_hingga"]);
                obj.judul = Request.Form["judul"];
                obj.isi = Request.Form["isi"];
                obj.creator = userLogin;
                obj.created = DateTime.Now;

                tbl_pengumumanItem.Insert(obj);

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
        public ActionResult Edit(int id)
        {

            try
            {
                tbl_pengumuman objAll = new tbl_pengumuman();
                objAll = tbl_pengumumanItem.GetByPK(id);
                return View(new m_tbl_pengumuman(objAll));
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // POST: Default/Edit/5
        [CustomAuthorize("GBK")]
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                userLogin = Session["userLogin"].ToString();
                tbl_pengumuman obj = new tbl_pengumuman();
                obj.id_pengumuman = id;
                obj.no = Request.Form["no"];
                obj.tanggal = Convert.ToDateTime(Request.Form["tanggal"]);
                obj.tanggal_hingga = Convert.ToDateTime(Request.Form["tanggal_hingga"]);
                obj.judul = Request.Form["judul"];
                obj.isi = Request.Form["isi"];
                obj.editor = userLogin;
                obj.edited = DateTime.Now;

                tbl_pengumumanItem.Update(obj);

                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // GET: Default/Delete/5
        [CustomAuthorize("GBK")]
        public ActionResult Delete(int id)
        {
            try
            {
                tbl_pengumumanItem.Delete(id);

                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        //Custom
        [Authorize]
        public JsonResult IsAlreadyNo(string no)
        {
            try
            {
                bool status;

                tbl_pengumuman obj = new tbl_pengumuman();
                obj = tbl_pengumuman_cstmItem.GetByNo(no);
                if (obj != null)
                {
                    //Already registered  
                    status = false;
                }
                else
                {
                    //Available to use  
                    status = true;
                }

                return Json(status, JsonRequestBehavior.AllowGet);
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj);
                return Json(false, err.Message);
            }
        }


    }
}