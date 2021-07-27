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
    public class DataSiswaSWAController : BaseController
    {
        // GET: DataSiswaSWA
        public string userLogin = string.Empty;
        public string usrTypeLogin = string.Empty;
        public string usrNIS = string.Empty;

        [CustomAuthorize("SWA")]
        public ActionResult Index()
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

                userLogin = Session["userLogin"].ToString();
                objAll = tbl_data_siswaItem.GetByPK(userLogin);
                return View(new m_tbl_data_siswa(objAll));
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        [CustomAuthorize("SWA")]
        [HttpPost]
        public ActionResult Index(string id, FormCollection collection)
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


    }
}