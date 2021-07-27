
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using SMK.BAWANG.Dto;

namespace SMK.BAWANG.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_m_kelas]
    /// </summary>    
    public partial class tbl_m_kelasItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_m_kelas]
        /// </summary>        
        public static tbl_m_kelas Insert(tbl_m_kelas obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_m_kelas]([kelas_id], [nama_kelas]) 
VALUES      (@kelas_id, @nama_kelas)

SET @Err = @@Error

SELECT  kelas_id, nama_kelas
FROM    [tbl_m_kelas]
WHERE   [kelas_id]  = @kelas_id";
            context.AddParameter("@kelas_id", string.Format("{0}", obj.kelas_id));
            context.AddParameter("@nama_kelas", string.Format("{0}", obj.nama_kelas));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_m_kelas>(context, new tbl_m_kelas()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_m_kelas]
        /// </summary>        
        public static tbl_m_kelas Update(tbl_m_kelas obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_m_kelas]
SET         [nama_kelas] = @nama_kelas
WHERE       [kelas_id]  = @kelas_id

SET @Err = @@Error

SELECT  kelas_id, nama_kelas 
FROM    [tbl_m_kelas]
WHERE   [kelas_id]  = @kelas_id";
            context.AddParameter("@nama_kelas", string.Format("{0}", obj.nama_kelas));
            context.AddParameter("@kelas_id", string.Format("{0}", obj.kelas_id));            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_m_kelas>(context, new tbl_m_kelas()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_m_kelas]
        /// </summary>        
        public static int Delete(string kelas_id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_m_kelas 
WHERE   [kelas_id]  = @kelas_id";
            context.AddParameter("@kelas_id",  string.Format("{0}", kelas_id));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteNonQuery(context);
        }
        public static int GetCount(int PageSize, int PageIndex)
        {
            return GetTotalRecord();
        }
        /// <summary>
        /// Get Total records from [tbl_m_kelas]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_m_kelas";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_m_kelas]
        /// </summary>        
        public static List<tbl_m_kelas> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT kelas_id, nama_kelas FROM tbl_m_kelas";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_m_kelas>(context, new tbl_m_kelas());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_m_kelas]
        /// </summary>        
        public static List<tbl_m_kelas> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_m_kelas] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_m_kelas].[kelas_id] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_m_kelas].*
                FROM    [tbl_m_kelas]
            )

            SELECT      [Paging_tbl_m_kelas].*
            FROM        [Paging_tbl_m_kelas]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_m_kelas>(context, new tbl_m_kelas());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_m_kelas] by Primary Key
        /// </summary>        
        public static tbl_m_kelas GetByPK(string kelas_id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT kelas_id, nama_kelas FROM tbl_m_kelas
            WHERE [kelas_id]  = @kelas_id";
            context.AddParameter("@kelas_id", kelas_id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_m_kelas>(context, new tbl_m_kelas()).FirstOrDefault();
        }

        #endregion

    }
}