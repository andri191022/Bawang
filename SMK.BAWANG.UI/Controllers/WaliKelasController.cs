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
    public class WaliKelasController : BaseController
    {
        // GET: WaliKelas
        public string userLogin = string.Empty;
        public string usrTypeLogin = string.Empty;

        [CustomAuthorize("GBK")]
        public ActionResult Index()
        {
            List<tbl_wali_kelas> objA = new List<tbl_wali_kelas>();
            try
            {            
                objA = tbl_wali_kelasItem.GetAll();

                return View(objA);
            }
            catch(Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); 
                return View(objA);
            }
        }

        // GET: Default/Details/5
        [CustomAuthorize("GBK")]
        public ActionResult Details(string id)
        {
            try
            {
                tbl_wali_kelas obj = new tbl_wali_kelas();
                obj = tbl_wali_kelasItem.GetByPK(id);

                return View(new m_tbl_wali_kelas(obj));
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
            tbl_wali_kelas obj = new tbl_wali_kelas();
            try
            {
                List<tbl_m_kelas> objKelas = new List<tbl_m_kelas>();
                objKelas = tbl_m_kelasItem.GetAll();

                Dictionary<string, string> ooList = new Dictionary<string, string>();
                foreach (var xx in objKelas)
                {
                    ooList.Add(xx.kelas_id, xx.nama_kelas);
                }
                ViewBag.dataKelas = dropDownGenerate.toSelectCustom(ooList);

                return View(new m_tbl_wali_kelas(obj));
            }
            catch
            {
                return View(obj);
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

                tbl_wali_kelas obj = new tbl_wali_kelas();
                obj.username = Request.Form["username"];
                obj.nama = Request.Form["nama"];
                obj.password = Request.Form["password"];
                obj.wali_kelas = Request.Form["wali_kelas"];
                obj.creator = userLogin;
                obj.created = DateTime.Now;

                tbl_wali_kelasItem.Insert(obj);

                return RedirectToAction("Index");
            }
            catch(Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj);
                return RedirectToAction("Create");
            }
        }

        // GET: Default/Edit/5
        [CustomAuthorize("GBK")]
        public ActionResult Edit(string id)
        {

            try
            {
                tbl_wali_kelas obj = new tbl_wali_kelas();
                obj = tbl_wali_kelasItem.GetByPK(id);


                List<tbl_m_kelas> objKelas = new List<tbl_m_kelas>();
                objKelas = tbl_m_kelasItem.GetAll();

                Dictionary<string, string> ooList = new Dictionary<string, string>();
                foreach (var xx in objKelas)
                {
                    ooList.Add(xx.kelas_id, xx.nama_kelas);
                }
                ViewBag.dataKelas = dropDownGenerate.toSelectCustom(ooList);

                return View(new m_tbl_wali_kelas(obj));
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
                userLogin = Session["userLogin"].ToString();
                tbl_wali_kelas obj = new tbl_wali_kelas();
                obj.username = id;
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

        // GET: Default/Delete/5
        [CustomAuthorize("GBK")]
        public ActionResult Delete(string id)
        {
            try
            {
                tbl_wali_kelasItem.Delete(id);

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