
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using SMK.BAWANG.Dto;

namespace SMK.BAWANG.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_data_siswa]
    /// </summary>    
    public partial class tbl_data_siswaItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_data_siswa]
        /// </summary>        
        public static tbl_data_siswa Insert(tbl_data_siswa obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_data_siswa]([username], [password], [NIS], [nama], [kelas], [created], [creator], [edited], [editor]) 
VALUES      (@username, @password, @NIS, @nama, @kelas, @created, @creator, @edited, @editor)

SET @Err = @@Error

SELECT  username, password, NIS, nama, kelas, created, creator, edited, editor
FROM    [tbl_data_siswa]
WHERE   [username]  = @username";
            context.AddParameter("@username", string.Format("{0}", obj.username));
            context.AddParameter("@password", string.Format("{0}", obj.password));
            context.AddParameter("@NIS", string.Format("{0}", obj.NIS));
            context.AddParameter("@nama", string.Format("{0}", obj.nama));
            context.AddParameter("@kelas", string.Format("{0}", obj.kelas));
            context.AddParameter("@created", obj.created);
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@edited", obj.edited);
            context.AddParameter("@editor", string.Format("{0}", obj.editor));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_data_siswa>(context, new tbl_data_siswa()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_data_siswa]
        /// </summary>        
        public static tbl_data_siswa Update(tbl_data_siswa obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_data_siswa]
SET         [password] = @password,
            [NIS] = @NIS,
            [nama] = @nama,
            [kelas] = @kelas,
          
            [edited] = @edited,
            [editor] = @editor
WHERE       [username]  = @username

SET @Err = @@Error

SELECT  username, password, NIS, nama, kelas, created, creator, edited, editor 
FROM    [tbl_data_siswa]
WHERE   [username]  = @username";
            context.AddParameter("@password", string.Format("{0}", obj.password));
            context.AddParameter("@NIS", string.Format("{0}", obj.NIS));
            context.AddParameter("@nama", string.Format("{0}", obj.nama));
            context.AddParameter("@kelas", string.Format("{0}", obj.kelas));
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@edited", obj.edited);
            context.AddParameter("@editor", string.Format("{0}", obj.editor));
            context.AddParameter("@username", string.Format("{0}", obj.username));            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_data_siswa>(context, new tbl_data_siswa()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_data_siswa]
        /// </summary>        
        public static int Delete(string username)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_data_siswa 
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
        /// Get Total records from [tbl_data_siswa]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_data_siswa";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_data_siswa]
        /// </summary>        
        public static List<tbl_data_siswa> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT username, password, NIS, nama, kelas, created, creator, edited, editor FROM tbl_data_siswa";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_data_siswa>(context, new tbl_data_siswa());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_data_siswa]
        /// </summary>        
        public static List<tbl_data_siswa> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_data_siswa] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_data_siswa].[username] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_data_siswa].*
                FROM    [tbl_data_siswa]
            )

            SELECT      [Paging_tbl_data_siswa].*
            FROM        [Paging_tbl_data_siswa]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_data_siswa>(context, new tbl_data_siswa());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_data_siswa] by Primary Key
        /// </summary>        
        public static tbl_data_siswa GetByPK(string username)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT username, password, NIS, nama, kelas, created, creator, edited, editor FROM tbl_data_siswa
            WHERE [username]  = @username";
            context.AddParameter("@username", username);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_data_siswa>(context, new tbl_data_siswa()).FirstOrDefault();
        }

        #endregion

    }
}