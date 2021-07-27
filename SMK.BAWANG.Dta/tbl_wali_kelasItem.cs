
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using SMK.BAWANG.Dto;

namespace SMK.BAWANG.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_wali_kelas]
    /// </summary>    
    public partial class tbl_wali_kelasItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_wali_kelas]
        /// </summary>        
        public static tbl_wali_kelas Insert(tbl_wali_kelas obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_wali_kelas]([username], [nama], [password], [wali_kelas], [created], [creator], [edited], [editor]) 
VALUES      (@username, @nama, @password, @wali_kelas, @created, @creator, @edited, @editor)

SET @Err = @@Error

SELECT  username, nama, password, wali_kelas, created, creator, edited, editor
FROM    [tbl_wali_kelas]
WHERE   [username]  = @username";
            context.AddParameter("@username", string.Format("{0}", obj.username));
            context.AddParameter("@nama", string.Format("{0}", obj.nama));
            context.AddParameter("@password", string.Format("{0}", obj.password));
            context.AddParameter("@wali_kelas", string.Format("{0}", obj.wali_kelas));
            context.AddParameter("@created", obj.created);
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@edited", obj.edited);
            context.AddParameter("@editor", string.Format("{0}", obj.editor));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_wali_kelas>(context, new tbl_wali_kelas()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_wali_kelas]
        /// </summary>        
        public static tbl_wali_kelas Update(tbl_wali_kelas obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_wali_kelas]
SET         [nama] = @nama,
            [password] = @password,
            [wali_kelas] = @wali_kelas,
            
            [edited] = @edited,
            [editor] = @editor
WHERE       [username]  = @username

SET @Err = @@Error

SELECT  username, nama, password, wali_kelas, created, creator, edited, editor 
FROM    [tbl_wali_kelas]
WHERE   [username]  = @username";
            context.AddParameter("@nama", string.Format("{0}", obj.nama));
            context.AddParameter("@password", string.Format("{0}", obj.password));
            context.AddParameter("@wali_kelas", string.Format("{0}", obj.wali_kelas));
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@edited", obj.edited);
            context.AddParameter("@editor", string.Format("{0}", obj.editor));
            context.AddParameter("@username", string.Format("{0}", obj.username));            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_wali_kelas>(context, new tbl_wali_kelas()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_wali_kelas]
        /// </summary>        
        public static int Delete(string username)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_wali_kelas 
WHERE   [username]  = @username";
            context.AddParameter("@username",  string.Format("{0}", username));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteNonQuery(context);
        }
        public static int GetCount(int PageSize, int PageIndex)
        {
            return GetTotalRecord();
        }
        /// <summary>
        /// Get Total records from [tbl_wali_kelas]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_wali_kelas";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_wali_kelas]
        /// </summary>        
        public static List<tbl_wali_kelas> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT username, nama, password, wali_kelas, created, creator, edited, editor FROM tbl_wali_kelas";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_wali_kelas>(context, new tbl_wali_kelas());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_wali_kelas]
        /// </summary>        
        public static List<tbl_wali_kelas> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_wali_kelas] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_wali_kelas].[username] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_wali_kelas].*
                FROM    [tbl_wali_kelas]
            )

            SELECT      [Paging_tbl_wali_kelas].*
            FROM        [Paging_tbl_wali_kelas]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_wali_kelas>(context, new tbl_wali_kelas());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_wali_kelas] by Primary Key
        /// </summary>        
        public static tbl_wali_kelas GetByPK(string username)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT username, nama, password, wali_kelas, created, creator, edited, editor FROM tbl_wali_kelas
            WHERE [username]  = @username";
            context.AddParameter("@username", username);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_wali_kelas>(context, new tbl_wali_kelas()).FirstOrDefault();
        }

        #endregion

    }
}