
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using SMK.BAWANG.Dto;

namespace SMK.BAWANG.Dta
{
    /// <summary>
    /// Dta Class of VIEW [v_Login]
    /// </summary>    
    public partial class v_LoginItem
    {

        #region Data Access
        public static v_Login GetByPK(string userid)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @" SELECT  [Username]
                  ,[Nama]
                  ,[Kelas]
                  ,[NIS]
                  ,[typeUser]
                  ,[Password]
              FROM [v_Login] where  [Username] = @ID";
            context.AddParameter("@ID", userid);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<v_Login>(context, new v_Login()).FirstOrDefault();
        }

        #endregion

    }
}