
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace SMK.BAWANG.Dto
{
    public class tbl_m_kelas : IDataMapper<tbl_m_kelas>
    {
        #region tbl_m_kelas Properties
        public string kelas_id { get; set; }
        public string nama_kelas { get; set; }
        #endregion    
        public tbl_m_kelas Map(System.Data.IDataReader reader)
        {
            tbl_m_kelas obj = new tbl_m_kelas();   
            obj.kelas_id = string.Format("{0}",reader["kelas_id"]);
            obj.nama_kelas = reader["nama_kelas"] == DBNull.Value ? null : reader["nama_kelas"].ToString();
            return obj;
        }
    }
}