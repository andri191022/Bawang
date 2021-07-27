
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace SMK.BAWANG.Dto
{
    public class tbl_guru_bk : IDataMapper<tbl_guru_bk>
    {
        #region tbl_guru_bk Properties
        public string username { get; set; }
        public string nama { get; set; }
        public string password { get; set; }
        public DateTime? created { get; set; }
        public string creator { get; set; }
        public DateTime? edited { get; set; }
        public string editor { get; set; }
        #endregion    
        public tbl_guru_bk Map(System.Data.IDataReader reader)
        {
            tbl_guru_bk obj = new tbl_guru_bk();   
            obj.username = string.Format("{0}",reader["username"]);
            obj.nama = reader["nama"] == DBNull.Value ? null : reader["nama"].ToString();
            obj.password = reader["password"] == DBNull.Value ? null : reader["password"].ToString();
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.creator = reader["creator"] == DBNull.Value ? null : reader["creator"].ToString();
            obj.edited = reader["edited"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["edited"]);
            obj.editor = reader["editor"] == DBNull.Value ? null : reader["editor"].ToString();
            return obj;
        }
    }
}