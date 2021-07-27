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
    public class DataSiswaController : BaseController
    {
        // GET: Siswa
        public string userLogin = string.Empty;
        public string usrTypeLogin = string.Empty;

        [CustomAuthorize("GBK")]
        public ActionResult Index()
        {
            List<tbl_data_siswa> objAll = new List<tbl_data_siswa>();

            try
            {               
                objAll = tbl_data_siswaItem.GetAll();

                return View(objAll);
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // GET: Siswa/Details/5
        [CustomAuthorize("GBK")]
        public ActionResult Details(string id)
        {
            tbl_data_siswa objAll = new tbl_data_siswa();
            try
            {
                objAll = tbl_data_siswaItem.GetByPK(id);

                return View(new m_tbl_data_siswa(objAll));
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // GET: Siswa/Create
        [CustomAuthorize("GBK")]
        public ActionResult Create()
        {
            tbl_data_siswa objAll = new tbl_data_siswa();
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

                return View(new m_tbl_data_siswa(objAll));
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // POST: Siswa/Create
        [CustomAuthorize("GBK")]
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                userLogin = Session["userLogin"].ToString();
                tbl_data_siswa obj = new tbl_data_siswa();
                obj.username = Request.Form["username"];
                obj.password = Request.Form["password"];
                obj.NIS = Request.Form["NIS"];
                obj.nama = Request.Form["nama"];
                obj.kelas = Request.Form["kelas"];
                obj.creator = userLogin;
                obj.created = DateTime.Now;

                tbl_data_siswaItem.Insert(obj);

                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj);
                return RedirectToAction("Create");
            }
        }

        // GET: Siswa/Edit/5
        [CustomAuthorize("GBK")]
        public ActionResult Edit(string id)
        {
            tbl_data_siswa objAll = new tbl_data_siswa();
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

                objAll = tbl_data_siswaItem.GetByPK(id);
                return View(new m_tbl_data_siswa(objAll));
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // POST: Siswa/Edit/5
        [CustomAuthorize("GBK")]
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                userLogin = Session["userLogin"].ToString();
                tbl_data_siswa obj = new tbl_data_siswa();
                obj.username = id;
                obj.password = Request.Form["password"];
                obj.NIS = Request.Form["NIS"];
                obj.nama = Request.Form["nama"];
                obj.kelas = Request.Form["kelas"];
                obj.editor = userLogin;
                obj.edited = DateTime.Now;

                tbl_data_siswaItem.Update(obj);

                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // GET: Siswa/Delete/5
        [CustomAuthorize("GBK")]
        public ActionResult Delete(string id)
        {
            try
            {
                tbl_data_siswaItem.Delete(id);

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
                //return Json(true, JsonRequestBehavior.AllowGet);
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj);
                return Json(true, JsonRequestBehavior.AllowGet);
            }

        }

        [Authorize]
        public JsonResult IsAlreadyNIS(string username, string NIS, string aeMode)
        {
            bool status;
            try
            {
                status = CheckNIS.IsAlreadyUsernameNIS(username, NIS, aeMode);

                return Json(status, JsonRequestBehavior.AllowGet);
            }
            catch (Exception err)
            {
                //return Json(true, JsonRequestBehavior.AllowGet);
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj);
                return Json(true, JsonRequestBehavior.AllowGet);
            }

        }

    }
}