
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace SMK.BAWANG.Dto
{
    public class tbl_pengumuman : IDataMapper<tbl_pengumuman>
    {
        #region tbl_pengumuman Properties
        public Int32 id_pengumuman { get; set; }
        public string no { get; set; }
        public DateTime? tanggal { get; set; }
        public DateTime? tanggal_hingga { get; set; }
        public string judul { get; set; }
        public string isi { get; set; }
        public DateTime? created { get; set; }
        public string creator { get; set; }
        public string editor { get; set; }
        public DateTime? edited { get; set; }
        #endregion    
        public tbl_pengumuman Map(System.Data.IDataReader reader)
        {
            tbl_pengumuman obj = new tbl_pengumuman();   
            obj.id_pengumuman = Convert.ToInt32(reader["id_pengumuman"]);
            obj.no = reader["no"] == DBNull.Value ? null : reader["no"].ToString();
            obj.tanggal = reader["tanggal"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["tanggal"]);
            obj.tanggal_hingga = reader["tanggal_hingga"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["tanggal_hingga"]);
            obj.judul = reader["judul"] == DBNull.Value ? null : reader["judul"].ToString();
            obj.isi = reader["isi"] == DBNull.Value ? null : reader["isi"].ToString();
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.creator = reader["creator"] == DBNull.Value ? null : reader["creator"].ToString();
            obj.editor = reader["editor"] == DBNull.Value ? null : reader["editor"].ToString();
            obj.edited = reader["edited"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["edited"]);
            return obj;
        }
    }
}