
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using SMK.BAWANG.Dto;

namespace SMK.BAWANG.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_guru_bk]
    /// </summary>    
    public partial class tbl_guru_bkItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_guru_bk]
        /// </summary>        
        public static tbl_guru_bk Insert(tbl_guru_bk obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_guru_bk]([username], [nama], [password], [created], [creator], [edited], [editor]) 
VALUES      (@username, @nama, @password, @created, @creator, @edited, @editor)

SET @Err = @@Error

SELECT  username, nama, password, created, creator, edited, editor
FROM    [tbl_guru_bk]
WHERE   [username]  = @username";
            context.AddParameter("@username", string.Format("{0}", obj.username));
            context.AddParameter("@nama", string.Format("{0}", obj.nama));
            context.AddParameter("@password", string.Format("{0}", obj.password));
            context.AddParameter("@created", obj.created);
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@edited", obj.edited);
            context.AddParameter("@editor", string.Format("{0}", obj.editor));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_guru_bk>(context, new tbl_guru_bk()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_guru_bk]
        /// </summary>        
        public static tbl_guru_bk Update(tbl_guru_bk obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_guru_bk]
SET         [nama] = @nama,
            [password] = @password,
           
            [edited] = @edited,
            [editor] = @editor
WHERE       [username]  = @username

SET @Err = @@Error

SELECT  username, nama, password, created, creator, edited, editor 
FROM    [tbl_guru_bk]
WHERE   [username]  = @username";
            context.AddParameter("@nama", string.Format("{0}", obj.nama));
            context.AddParameter("@password", string.Format("{0}", obj.password));
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@edited", obj.edited);
            context.AddParameter("@editor", string.Format("{0}", obj.editor));
            context.AddParameter("@username", string.Format("{0}", obj.username));            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_guru_bk>(context, new tbl_guru_bk()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_guru_bk]
        /// </summary>        
        public static int Delete(string username)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_guru_bk 
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
        /// Get Total records from [tbl_guru_bk]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_guru_bk";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_guru_bk]
        /// </summary>        
        public static List<tbl_guru_bk> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT username, nama, password, created, creator, edited, editor FROM tbl_guru_bk";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_guru_bk>(context, new tbl_guru_bk());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_guru_bk]
        /// </summary>        
        public static List<tbl_guru_bk> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_guru_bk] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_guru_bk].[username] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_guru_bk].*
                FROM    [tbl_guru_bk]
            )

            SELECT      [Paging_tbl_guru_bk].*
            FROM        [Paging_tbl_guru_bk]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_guru_bk>(context, new tbl_guru_bk());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_guru_bk] by Primary Key
        /// </summary>        
        public static tbl_guru_bk GetByPK(string username)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT username, nama, password, created, creator, edited, editor FROM tbl_guru_bk
            WHERE [username]  = @username";
            context.AddParameter("@username", username);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_guru_bk>(context, new tbl_guru_bk()).FirstOrDefault();
        }

        #endregion

    }
}