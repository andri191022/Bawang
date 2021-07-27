
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace SMK.BAWANG.Dto
{
    public class tbl_data_siswa : IDataMapper<tbl_data_siswa>
    {
        #region tbl_data_siswa Properties
        public string username { get; set; }
        public string password { get; set; }
        public string NIS { get; set; }
        public string nama { get; set; }
        public string kelas { get; set; }
        public DateTime? created { get; set; }
        public string creator { get; set; }
        public DateTime? edited { get; set; }
        public string editor { get; set; }
        #endregion    
        public tbl_data_siswa Map(System.Data.IDataReader reader)
        {
            tbl_data_siswa obj = new tbl_data_siswa();   
            obj.username = string.Format("{0}",reader["username"]);
            obj.password = reader["password"] == DBNull.Value ? null : reader["password"].ToString();
            obj.NIS = reader["NIS"] == DBNull.Value ? null : reader["NIS"].ToString();
            obj.nama = reader["nama"] == DBNull.Value ? null : reader["nama"].ToString();
            obj.kelas = reader["kelas"] == DBNull.Value ? null : reader["kelas"].ToString();
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.creator = reader["creator"] == DBNull.Value ? null : reader["creator"].ToString();
            obj.edited = reader["edited"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["edited"]);
            obj.editor = reader["editor"] == DBNull.Value ? null : reader["editor"].ToString();
            return obj;
        }
    }
}