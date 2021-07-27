
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace SMK.BAWANG.Dto
{
    public class tbl_point_siswa : IDataMapper<tbl_point_siswa>
    {
        #region tbl_point_siswa Properties
        public Int32 id_poin_siswa { get; set; }
        public string NIS { get; set; }
        public string kelas { get; set; }
        public Int32? id_tata_tertib { get; set; }
        public DateTime? created { get; set; }
        public string creator { get; set; }
        public DateTime? edited { get; set; }
        public string editor { get; set; }
        #endregion    
        public tbl_point_siswa Map(System.Data.IDataReader reader)
        {
            tbl_point_siswa obj = new tbl_point_siswa();   
            obj.id_poin_siswa = Convert.ToInt32(reader["id_poin_siswa"]);
            obj.NIS = reader["NIS"] == DBNull.Value ? null : reader["NIS"].ToString();
            obj.kelas = reader["kelas"] == DBNull.Value ? null : reader["kelas"].ToString();
            obj.id_tata_tertib = reader["id_tata_tertib"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["id_tata_tertib"]);
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.creator = reader["creator"] == DBNull.Value ? null : reader["creator"].ToString();
            obj.edited = reader["edited"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["edited"]);
            obj.editor = reader["editor"] == DBNull.Value ? null : reader["editor"].ToString();
            return obj;
        }
    }
}