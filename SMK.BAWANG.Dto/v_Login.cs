
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace SMK.BAWANG.Dto
{
    public class v_Login : IDataMapper<v_Login>
    {
        #region v_Login Properties
        public string Username { get; set; }
        public string Nama { get; set; }
        public string Kelas { get; set; }
        public string NIS { get; set; }
        public string typeUser { get; set; }
        public string Password { get; set; }
        #endregion    
        public v_Login Map(System.Data.IDataReader reader)
        {
            v_Login obj = new v_Login();   
            obj.Username = string.Format("{0}",reader["Username"]);
            obj.Nama = reader["Nama"] == DBNull.Value ? null : reader["Nama"].ToString();
            obj.Kelas = reader["Kelas"] == DBNull.Value ? null : reader["Kelas"].ToString();
            obj.NIS = reader["NIS"] == DBNull.Value ? null : reader["NIS"].ToString();
            obj.typeUser = string.Format("{0}",reader["typeUser"]);
            obj.Password = reader["Password"] == DBNull.Value ? null : reader["Password"].ToString();
            return obj;
        }
    }
}