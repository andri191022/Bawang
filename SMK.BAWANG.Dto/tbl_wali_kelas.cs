
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace SMK.BAWANG.Dto
{
    public class tbl_wali_kelas : IDataMapper<tbl_wali_kelas>
    {
        #region tbl_wali_kelas Properties
        public string username { get; set; }
        public string nama { get; set; }
        public string password { get; set; }
        public string wali_kelas { get; set; }
        public DateTime? created { get; set; }
        public string creator { get; set; }
        public DateTime? edited { get; set; }
        public string editor { get; set; }
        #endregion    
        public tbl_wali_kelas Map(System.Data.IDataReader reader)
        {
            tbl_wali_kelas obj = new tbl_wali_kelas();   
            obj.username = string.Format("{0}",reader["username"]);
            obj.nama = reader["nama"] == DBNull.Value ? null : reader["nama"].ToString();
            obj.password = reader["password"] == DBNull.Value ? null : reader["password"].ToString();
            obj.wali_kelas = reader["wali_kelas"] == DBNull.Value ? null : reader["wali_kelas"].ToString();
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.creator = reader["creator"] == DBNull.Value ? null : reader["creator"].ToString();
            obj.edited = reader["edited"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["edited"]);
            obj.editor = reader["editor"] == DBNull.Value ? null : reader["editor"].ToString();
            return obj;
        }
    }
}