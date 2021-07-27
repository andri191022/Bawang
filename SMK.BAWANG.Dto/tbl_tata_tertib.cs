
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace SMK.BAWANG.Dto
{
    public class tbl_tata_tertib : IDataMapper<tbl_tata_tertib>
    {
        #region tbl_tata_tertib Properties
        public Int32 id_tata_tertib { get; set; }
        public string tata_tertib { get; set; }
        public Int32? poin { get; set; }
        public Int32? aspek { get; set; }
        public DateTime? created { get; set; }
        public string creator { get; set; }
        public DateTime? edited { get; set; }
        public string editor { get; set; }
        #endregion    
        public tbl_tata_tertib Map(System.Data.IDataReader reader)
        {
            tbl_tata_tertib obj = new tbl_tata_tertib();   
            obj.id_tata_tertib = Convert.ToInt32(reader["id_tata_tertib"]);
            obj.tata_tertib = reader["tata_tertib"] == DBNull.Value ? null : reader["tata_tertib"].ToString();
            obj.poin = reader["poin"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["poin"]);
            obj.aspek = reader["aspek"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["aspek"]);
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.creator = reader["creator"] == DBNull.Value ? null : reader["creator"].ToString();
            obj.edited = reader["edited"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["edited"]);
            obj.editor = reader["editor"] == DBNull.Value ? null : reader["editor"].ToString();
            return obj;
        }
    }
}