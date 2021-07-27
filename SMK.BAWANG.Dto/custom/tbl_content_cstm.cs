using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMK.BAWANG.Dto.custom
{
    public class tbl_content_cstm : IDataMapper<tbl_content_cstm>
    {
        public string content_text { get; set; }
        public tbl_content_cstm Map(System.Data.IDataReader reader)
        {
            tbl_content_cstm obj = new tbl_content_cstm();
          
            obj.content_text = reader["content_text"] == DBNull.Value ? null : reader["content_text"].ToString();

            return obj;
        }
    }
}
