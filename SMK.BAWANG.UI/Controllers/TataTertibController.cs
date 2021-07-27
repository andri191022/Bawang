using Newtonsoft.Json;
using SMK.BAWANG.Dta;
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
    public class TataTertibController : BaseController
    {
        // GET: TataTertib
        public string userLogin = string.Empty;
        public string usrTypeLogin = string.Empty;

        [CustomAuthorize("GBK")]
        public ActionResult Index()
        {
            List<tbl_tata_tertib> objAll = new List<tbl_tata_tertib>();
            List<tbl_m_aspek> objaspek = new List<tbl_m_aspek>();
            List<tbl_tata_tertib_cstm> objRs = new List<tbl_tata_tertib_cstm>();

            try
            {
                if (Session["usrTypeLogin"] != null) { if (Session["usrTypeLogin"].ToString().ToUpper() != "GBK") { Response.Redirect("~/Login"); } }

                objAll = tbl_tata_tertibItem.GetAll();
                objaspek = tbl_m_aspekItem.GetAll();

                if (objAll.Count > 0)
                {
                    var objQry = from tata in objAll
                                 join aspk in objaspek on tata.aspek equals aspk.id into g
                                 from d in g.DefaultIfEmpty()
                                 select new
                                 { id_tata_tertib = tata.id_tata_tertib, tata_tertib = tata.tata_tertib, poin = tata.poin, Aspek = d.Aspek, creator = tata.creator, created = tata.created, edited = tata.edited, editor = tata.editor };

                    foreach (var o in objQry) { objRs.Add(new tbl_tata_tertib_cstm() { id_tata_tertib = o.id_tata_tertib, tata_tertib = o.tata_tertib, poin = o.poin, aspek = o.Aspek, creator = o.creator, created = o.created, edited = o.edited, editor = o.editor }); }
                }

                return View(objRs);
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); 
                return View(objRs);
            }
        }

        // GET: Default/Details/5
        [CustomAuthorize("GBK")]
        public ActionResult Details(int id)
        {
            tbl_tata_tertib objAll = new tbl_tata_tertib();
            tbl_m_aspek objA = new tbl_m_aspek();

            tbl_tata_tertib_cstm objRes = new tbl_tata_tertib_cstm();
            try
            {
                objAll = tbl_tata_tertibItem.GetByPK(id);

                if (objAll != null)
                {
                    objA = tbl_m_aspekItem.GetByPK(objAll.aspek == null ? default(int) : objAll.aspek.Value);

                    objRes.id_tata_tertib = objAll.id_tata_tertib;
                    objRes.tata_tertib = objAll.tata_tertib;
                    objRes.poin = objAll.poin; 
                    objRes.aspek = objA.Aspek;
                    objRes.created = objAll.created;
                    objRes.creator = objAll.creator;
                    objRes.edited = objAll.edited;
                    objRes.editor = objAll.editor;
                }

                return View(new m_tbl_tata_tertib_cstm(objRes));
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); 
                return View(objAll);
            }
        }

        // GET: Default/Create
        [CustomAuthorize("GBK")]
        public ActionResult Create()
        {
            tbl_tata_tertib objAll = new tbl_tata_tertib();
            try
            {
                List<tbl_m_aspek> objAspek = new List<tbl_m_aspek>();

                objAspek = tbl_m_aspekItem.GetAll();
                Dictionary<string, string> ooList = new Dictionary<string, string>();
                foreach (var oo in objAspek)
                {
                    ooList.Add(oo.id.ToString(), oo.id.ToString() + " - " + oo.Aspek); ;
                }

                ViewBag.dataAspek = dropDownGenerate.toSelectCustom(ooList);

                return View(new m_tbl_tata_tertib(objAll));
            }
            catch(Exception err)
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
                tbl_tata_tertib obj = new tbl_tata_tertib();
                obj.tata_tertib = Request.Form["tata_tertib"];
                obj.poin = Convert.ToInt32(Request.Form["poin"]);
                obj.aspek = Convert.ToInt32(Request.Form["aspek"]);
                obj.creator = userLogin;
                obj.created = DateTime.Now;

                tbl_tata_tertibItem.Insert(obj);

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
            tbl_tata_tertib objAll = new tbl_tata_tertib();
            try
            {
                objAll = tbl_tata_tertibItem.GetByPK(id);

                //aspek
                List<tbl_m_aspek> objAspek = new List<tbl_m_aspek>();
                objAspek = tbl_m_aspekItem.GetAll();
                Dictionary<string, string> ooList = new Dictionary<string, string>();
                foreach (var oo in objAspek)
                {
                    ooList.Add(oo.id.ToString(), oo.id.ToString() + " - " + oo.Aspek); ;
                }

                ViewBag.dataAspek = dropDownGenerate.toSelectCustom(ooList);
                //aspek

                return View(new m_tbl_tata_tertib(objAll));
            }
            catch(Exception err)
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
                tbl_tata_tertib objAll = new tbl_tata_tertib();
                objAll.id_tata_tertib = id;
                objAll.tata_tertib = Request.Form["tata_tertib"];
                objAll.poin = Convert.ToInt32(Request.Form["poin"]);
                objAll.aspek = Convert.ToInt32(Request.Form["aspek"]);
                objAll.editor = userLogin;
                objAll.edited = DateTime.Now;

                tbl_tata_tertibItem.Update(objAll);

                return RedirectToAction("Index");
            }
            catch(Exception err)
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
                tbl_tata_tertibItem.Delete(id);

                return RedirectToAction("Index");
            }
            catch(Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        [Authorize]
        [HttpPost]
        public string GetTataTertib(string id_tata_tertib)
        {
            tbl_tata_tertib table = new tbl_tata_tertib();
            try
            {
                Int32 ID = 0;
                Int32.TryParse(id_tata_tertib, out ID);

                table = tbl_tata_tertibItem.GetByPK(ID);

                return JsonConvert.SerializeObject(table);
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return err.Message;
           
            }


        }



    }
}