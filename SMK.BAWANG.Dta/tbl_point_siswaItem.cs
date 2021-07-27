
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using SMK.BAWANG.Dto;

namespace SMK.BAWANG.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_point_siswa]
    /// </summary>    
    public partial class tbl_point_siswaItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_point_siswa]
        /// </summary>        
        public static tbl_point_siswa Insert(tbl_point_siswa obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_point_siswa]([NIS], [kelas], [id_tata_tertib], [created], [creator], [edited], [editor]) 
VALUES      (@NIS, @kelas, @id_tata_tertib, @created, @creator, @edited, @editor)

SET @Err = @@Error

DECLARE @_id_poin_siswa Int
SELECT @_id_poin_siswa = SCOPE_IDENTITY()

SELECT  id_poin_siswa, NIS, kelas, id_tata_tertib, created, creator, edited, editor
FROM    [tbl_point_siswa]
WHERE   [id_poin_siswa]  = @_id_poin_siswa";
            context.AddParameter("@NIS", string.Format("{0}", obj.NIS));
            context.AddParameter("@kelas", string.Format("{0}", obj.kelas));
            context.AddParameter("@id_tata_tertib", obj.id_tata_tertib);
            context.AddParameter("@created", obj.created);
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@edited", obj.edited);
            context.AddParameter("@editor", string.Format("{0}", obj.editor));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_point_siswa>(context, new tbl_point_siswa()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_point_siswa]
        /// </summary>        
        public static tbl_point_siswa Update(tbl_point_siswa obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_point_siswa]
SET         [NIS] = @NIS,
            [kelas] = @kelas,
            [id_tata_tertib] = @id_tata_tertib,
           
            [edited] = @edited,
            [editor] = @editor
WHERE       [id_poin_siswa]  = @id_poin_siswa

SET @Err = @@Error

SELECT  id_poin_siswa, NIS, kelas, id_tata_tertib, created, creator, edited, editor 
FROM    [tbl_point_siswa]
WHERE   [id_poin_siswa]  = @id_poin_siswa";
            context.AddParameter("@NIS", string.Format("{0}", obj.NIS));
            context.AddParameter("@kelas", string.Format("{0}", obj.kelas));
            context.AddParameter("@id_tata_tertib", obj.id_tata_tertib);
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@edited", obj.edited);
            context.AddParameter("@editor", string.Format("{0}", obj.editor));
            context.AddParameter("@id_poin_siswa", obj.id_poin_siswa);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_point_siswa>(context, new tbl_point_siswa()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_point_siswa]
        /// </summary>        
        public static int Delete(Int32 id_poin_siswa)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_point_siswa 
WHERE   [id_poin_siswa]  = @id_poin_siswa";
            context.AddParameter("@id_poin_siswa", id_poin_siswa);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteNonQuery(context);
        }
        public static int GetCount(int PageSize, int PageIndex)
        {
            return GetTotalRecord();
        }
        /// <summary>
        /// Get Total records from [tbl_point_siswa]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_point_siswa";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_point_siswa]
        /// </summary>        
        public static List<tbl_point_siswa> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id_poin_siswa, NIS, kelas, id_tata_tertib, created, creator, edited, editor FROM tbl_point_siswa";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_point_siswa>(context, new tbl_point_siswa());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_point_siswa]
        /// </summary>        
        public static List<tbl_point_siswa> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_point_siswa] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_point_siswa].[id_poin_siswa] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_point_siswa].*
                FROM    [tbl_point_siswa]
            )

            SELECT      [Paging_tbl_point_siswa].*
            FROM        [Paging_tbl_point_siswa]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_point_siswa>(context, new tbl_point_siswa());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_point_siswa] by Primary Key
        /// </summary>        
        public static tbl_point_siswa GetByPK(Int32 id_poin_siswa)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id_poin_siswa, NIS, kelas, id_tata_tertib, created, creator, edited, editor FROM tbl_point_siswa
            WHERE [id_poin_siswa]  = @id_poin_siswa";
            context.AddParameter("@id_poin_siswa", id_poin_siswa);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_point_siswa>(context, new tbl_point_siswa()).FirstOrDefault();
        }

        #endregion

    }
}