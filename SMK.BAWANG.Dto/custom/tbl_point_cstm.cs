using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMK.BAWANG.Dto.custom
{
    public class tbl_point_cstm : IDataMapper<tbl_point_cstm>
    {
        public string NIS { get; set; }
        public string Nama { get; set; }
        public string Kelas { get; set; }
        public int? Jumlah_Point { get; set; }        
        public tbl_point_cstm Map(System.Data.IDataReader reader)
        {
            tbl_point_cstm obj = new tbl_point_cstm();

            obj.NIS = reader["NIS"] == DBNull.Value ? null : reader["NIS"].ToString();
            obj.Nama = reader["Nama"] == DBNull.Value ? null : reader["Nama"].ToString();
            obj.Kelas = reader["Kelas"] == DBNull.Value ? null : reader["Kelas"].ToString();
            obj.Jumlah_Point = reader["Jumlah_Point"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["Jumlah_Point"]);

            return obj;
        }
    }
}
