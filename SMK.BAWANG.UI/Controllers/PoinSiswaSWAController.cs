﻿using SMK.BAWANG.Dta;
using SMK.BAWANG.Dta.custom;
using SMK.BAWANG.Dto;
using SMK.BAWANG.Dto.custom;
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
    public class PoinSiswaSWAController : BaseController
    {
        // GET: PoinSiswaSWA
        public string userLogin = string.Empty;
        public string usrTypeLogin = string.Empty;
        public string usrNIS = string.Empty;

        [CustomAuthorize("SWA")]
        public ActionResult Index()
        {
            try
            {
                if (Session["usrTypeLogin"] != null) { if (Session["usrTypeLogin"].ToString().ToUpper() != "SWA") { Response.Redirect("~/Login"); } }

                List<tbl_poin_nis_cstm> obj = new List<tbl_poin_nis_cstm>();
                usrNIS = Session["usrNIS"].ToString();
                obj = tbl_point_cstmItem.getAllByNIS(usrNIS);

                return View(obj);
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // GET: Default/Details/5
        [CustomAuthorize("SWA")]
        public ActionResult Details(int id)
        {
            try
            {
                tbl_poin_nis_cstm obj = new tbl_poin_nis_cstm();

                obj = tbl_point_cstmItem.getByID(id);

                return View(new m_tbl_poin_nis_cstm(obj));
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // GET: Default/Create
        [CustomAuthorize("SWA")]
        public ActionResult Create(string id, string kelas)
        {
            try
            {
                tbl_poin_nis_cstm obj = new tbl_poin_nis_cstm();
                tbl_poin_nis_cstm objNIS = new tbl_poin_nis_cstm();

                objNIS = tbl_point_cstmItem.getAllByNISKelas(id, kelas).FirstOrDefault();
                obj.NIS = objNIS.NIS; obj.Nama = objNIS.Nama; obj.Kelas = objNIS.Kelas;

                List<tbl_tata_tertib> objtt = tbl_tata_tertibItem.GetAll();
                Dictionary<string, string> ooList = new Dictionary<string, string>();
                foreach (var oo in objtt)
                {
                    ooList.Add(oo.id_tata_tertib.ToString(), oo.tata_tertib.ToString()); ;
                }

                ViewBag.dataTataTertib = dropDownGenerate.toSelectCustom(ooList);

                return View(new m_tbl_poin_nis_cstm(obj));
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // POST: Default/Create
        [CustomAuthorize("SWA")]
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                tbl_point_siswa obj = new tbl_point_siswa();

                userLogin = Session["userLogin"].ToString();
                obj.NIS = Request.Form["NIS"];
                obj.kelas = Request.Form["kelas"];
                obj.id_tata_tertib = Convert.ToInt32(Request.Form["id_tata_tertib"]);
                obj.creator = userLogin;
                obj.created = DateTime.Now;

                tbl_point_siswaItem.Insert(obj);

                // TODO: Add insert logic here

                return RedirectToAction("Index", "PoinSiswaSWA", new { id = obj.NIS, kelas = obj.kelas });
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj);
                return RedirectToAction("Create");
            }
        }

        // GET: Default/Edit/5
        [CustomAuthorize("SWA")]
        public ActionResult Edit(int id)
        {
            try
            {
                tbl_poin_nis_cstm obj = new tbl_poin_nis_cstm();

                obj = tbl_point_cstmItem.getByID(id);

                List<tbl_tata_tertib> objtt = tbl_tata_tertibItem.GetAll();
                Dictionary<string, string> ooList = new Dictionary<string, string>();
                foreach (var oo in objtt)
                {
                    ooList.Add(oo.id_tata_tertib.ToString(), oo.tata_tertib.ToString()); ;
                }

                ViewBag.dataTataTertib = dropDownGenerate.toSelectCustom(ooList);

                return View(new m_tbl_poin_nis_cstm(obj));
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // POST: Default/Edit/5
        [CustomAuthorize("SWA")]
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                tbl_point_siswa obj = new tbl_point_siswa();

                userLogin = Session["userLogin"].ToString();
                obj.id_poin_siswa = id;
                obj.NIS = Request.Form["NIS"];
                obj.kelas = Request.Form["kelas"];
                obj.id_tata_tertib = Convert.ToInt32(Request.Form["id_tata_tertib"]);
                obj.editor = userLogin;
                obj.edited = DateTime.Now;

                tbl_point_siswaItem.Update(obj);

                return RedirectToAction("Details", "PoinSiswaSWA", new { id = obj.id_poin_siswa });
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // GET: Default/Delete/5
        [CustomAuthorize("SWA")]
        public ActionResult Delete(int id)
        {
            try
            {
                tbl_point_siswa obj = new tbl_point_siswa();

                obj = tbl_point_siswaItem.GetByPK(id);

                tbl_point_siswaItem.Delete(id);

                return RedirectToAction("Index", "PoinSiswaSWA", new { id = obj.NIS, kelas = obj.kelas });
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }

        }

    }
}