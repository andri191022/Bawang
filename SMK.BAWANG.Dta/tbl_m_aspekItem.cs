
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using SMK.BAWANG.Dto;

namespace SMK.BAWANG.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_m_aspek]
    /// </summary>    
    public partial class tbl_m_aspekItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_m_aspek]
        /// </summary>        
        public static tbl_m_aspek Insert(tbl_m_aspek obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_m_aspek]([Aspek]) 
VALUES      (@Aspek)

SET @Err = @@Error

DECLARE @_id Int
SELECT @_id = SCOPE_IDENTITY()

SELECT  id, Aspek
FROM    [tbl_m_aspek]
WHERE   [id]  = @_id";
            context.AddParameter("@Aspek", string.Format("{0}", obj.Aspek));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_m_aspek>(context, new tbl_m_aspek()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_m_aspek]
        /// </summary>        
        public static tbl_m_aspek Update(tbl_m_aspek obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_m_aspek]
SET         [Aspek] = @Aspek
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  id, Aspek 
FROM    [tbl_m_aspek]
WHERE   [id]  = @id";
            context.AddParameter("@Aspek", string.Format("{0}", obj.Aspek));
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_m_aspek>(context, new tbl_m_aspek()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_m_aspek]
        /// </summary>        
        public static int Delete(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_m_aspek 
WHERE   [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteNonQuery(context);
        }
        public static int GetCount(int PageSize, int PageIndex)
        {
            return GetTotalRecord();
        }
        /// <summary>
        /// Get Total records from [tbl_m_aspek]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_m_aspek";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_m_aspek]
        /// </summary>        
        public static List<tbl_m_aspek> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id, Aspek FROM tbl_m_aspek";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_m_aspek>(context, new tbl_m_aspek());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_m_aspek]
        /// </summary>        
        public static List<tbl_m_aspek> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_m_aspek] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_m_aspek].[id] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_m_aspek].*
                FROM    [tbl_m_aspek]
            )

            SELECT      [Paging_tbl_m_aspek].*
            FROM        [Paging_tbl_m_aspek]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_m_aspek>(context, new tbl_m_aspek());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_m_aspek] by Primary Key
        /// </summary>        
        public static tbl_m_aspek GetByPK(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id, Aspek FROM tbl_m_aspek
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_m_aspek>(context, new tbl_m_aspek()).FirstOrDefault();
        }

        #endregion

    }
}