
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace SMK.BAWANG.Dto
{
    public class tbl_m_aspek : IDataMapper<tbl_m_aspek>
    {
        #region tbl_m_aspek Properties
        public Int32 id { get; set; }
        public string Aspek { get; set; }
        #endregion    
        public tbl_m_aspek Map(System.Data.IDataReader reader)
        {
            tbl_m_aspek obj = new tbl_m_aspek();   
            obj.id = Convert.ToInt32(reader["id"]);
            obj.Aspek = reader["Aspek"] == DBNull.Value ? null : reader["Aspek"].ToString();
            return obj;
        }
    }
}