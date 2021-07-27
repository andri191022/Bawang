using SMK.BAWANG.Dta;
using SMK.BAWANG.Dto;
using SMK.BAWANG.Dto.custom;
using SMK.BAWANG.UI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace SMK.BAWANG.UI.Controllers
{
    public class TataTertibSWAController : BaseController
    {
        // GET: TataTertibSWA
        public string userLogin = string.Empty;
        public string usrTypeLogin = string.Empty;
        public string usrNIS = string.Empty;

        [CustomAuthorize("SWA")]
        public ActionResult Index()
        {
            List<tbl_tata_tertib> objAll = new List<tbl_tata_tertib>();
            List<tbl_m_aspek> objaspek = new List<tbl_m_aspek>();
            List<tbl_tata_tertib_cstm> objRs = new List<tbl_tata_tertib_cstm>();

            try
            {               
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
    }
}