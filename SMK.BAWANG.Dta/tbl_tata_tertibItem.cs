
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using SMK.BAWANG.Dto;

namespace SMK.BAWANG.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_tata_tertib]
    /// </summary>    
    public partial class tbl_tata_tertibItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_tata_tertib]
        /// </summary>        
        public static tbl_tata_tertib Insert(tbl_tata_tertib obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_tata_tertib]([tata_tertib], [poin], [aspek], [created], [creator], [edited], [editor]) 
VALUES      (@tata_tertib, @poin, @aspek, @created, @creator, @edited, @editor)

SET @Err = @@Error

DECLARE @_id_tata_tertib Int
SELECT @_id_tata_tertib = SCOPE_IDENTITY()

SELECT  id_tata_tertib, tata_tertib, poin, aspek, created, creator, edited, editor
FROM    [tbl_tata_tertib]
WHERE   [id_tata_tertib]  = @_id_tata_tertib";
            context.AddParameter("@tata_tertib", string.Format("{0}", obj.tata_tertib));
            context.AddParameter("@poin", obj.poin);
            context.AddParameter("@aspek", obj.aspek);
            context.AddParameter("@created", obj.created);
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@edited", obj.edited);
            context.AddParameter("@editor", string.Format("{0}", obj.editor));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_tata_tertib>(context, new tbl_tata_tertib()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_tata_tertib]
        /// </summary>        
        public static tbl_tata_tertib Update(tbl_tata_tertib obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_tata_tertib]
SET         [tata_tertib] = @tata_tertib,
            [poin] = @poin,
            [aspek] = @aspek,
           
            [edited] = @edited,
            [editor] = @editor
WHERE       [id_tata_tertib]  = @id_tata_tertib

SET @Err = @@Error

SELECT  id_tata_tertib, tata_tertib, poin, aspek, created, creator, edited, editor 
FROM    [tbl_tata_tertib]
WHERE   [id_tata_tertib]  = @id_tata_tertib";
            context.AddParameter("@tata_tertib", string.Format("{0}", obj.tata_tertib));
            context.AddParameter("@poin", obj.poin);
            context.AddParameter("@aspek", obj.aspek);
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@edited", obj.edited);
            context.AddParameter("@editor", string.Format("{0}", obj.editor));
            context.AddParameter("@id_tata_tertib", obj.id_tata_tertib);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_tata_tertib>(context, new tbl_tata_tertib()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_tata_tertib]
        /// </summary>        
        public static int Delete(Int32 id_tata_tertib)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_tata_tertib 
WHERE   [id_tata_tertib]  = @id_tata_tertib";
            context.AddParameter("@id_tata_tertib", id_tata_tertib);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteNonQuery(context);
        }
        public static int GetCount(int PageSize, int PageIndex)
        {
            return GetTotalRecord();
        }
        /// <summary>
        /// Get Total records from [tbl_tata_tertib]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_tata_tertib";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_tata_tertib]
        /// </summary>        
        public static List<tbl_tata_tertib> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id_tata_tertib, tata_tertib, poin, aspek, created, creator, edited, editor FROM tbl_tata_tertib";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_tata_tertib>(context, new tbl_tata_tertib());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_tata_tertib]
        /// </summary>        
        public static List<tbl_tata_tertib> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_tata_tertib] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_tata_tertib].[id_tata_tertib] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_tata_tertib].*
                FROM    [tbl_tata_tertib]
            )

            SELECT      [Paging_tbl_tata_tertib].*
            FROM        [Paging_tbl_tata_tertib]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_tata_tertib>(context, new tbl_tata_tertib());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_tata_tertib] by Primary Key
        /// </summary>        
        public static tbl_tata_tertib GetByPK(Int32 id_tata_tertib)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id_tata_tertib, tata_tertib, poin, aspek, created, creator, edited, editor FROM tbl_tata_tertib
            WHERE [id_tata_tertib]  = @id_tata_tertib";
            context.AddParameter("@id_tata_tertib", id_tata_tertib);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_tata_tertib>(context, new tbl_tata_tertib()).FirstOrDefault();
        }

        #endregion

    }
}