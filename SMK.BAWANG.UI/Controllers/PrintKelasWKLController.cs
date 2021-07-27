using SMK.BAWANG.Dta;
using SMK.BAWANG.Dta.custom;
using SMK.BAWANG.Dto;
using SMK.BAWANG.Dto.custom;
using SMK.BAWANG.Logic;
using SMK.BAWANG.UI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace SMK.BAWANG.UI.Controllers
{
    public class PrintKelasWKLController : BaseController
    {
        public string userLogin = string.Empty;
        public string usrTypeLogin = string.Empty;
        public string usrKelas = string.Empty;
        // GET: PrintKelasWKL
        [CustomAuthorize("WKL")]
        public ActionResult Index()
        {
            try
            {              
                userLogin = Session["userLogin"].ToString();
                usrKelas = Session["usrKLS"].ToString();

                tbl_content_cstm obj = new tbl_content_cstm();

                DataTable dt = new DataTable();
                dt = NilaiIKarakter_cstmItem.getAllbyKelas(usrKelas);

                obj = GenerateTableHTML.generatePageTableData(dt);

                return View(obj);
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // GET: Default/Details/5
        [CustomAuthorize("WKL")]
        public ActionResult Prints(string id, string kelas)
        {
            try
            {
                List<tbl_poin_nis_cstm> obj = new List<tbl_poin_nis_cstm>();

                obj = tbl_point_cstmItem.getAllByNISKelas(id, kelas);

                return View(obj);
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }


    }
}