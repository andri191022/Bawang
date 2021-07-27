
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using SMK.BAWANG.Dto;

namespace SMK.BAWANG.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_pengumuman]
    /// </summary>    
    public partial class tbl_pengumumanItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_pengumuman]
        /// </summary>        
        public static tbl_pengumuman Insert(tbl_pengumuman obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_pengumuman]([no], [tanggal], [tanggal_hingga], [judul], [isi], [created], [creator], [editor], [edited]) 
VALUES      (@no, @tanggal, @tanggal_hingga, @judul, @isi, @created, @creator, @editor, @edited)

SET @Err = @@Error

DECLARE @_id_pengumuman Int
SELECT @_id_pengumuman = SCOPE_IDENTITY()

SELECT  id_pengumuman, no, tanggal, tanggal_hingga, judul, isi, created, creator, editor, edited
FROM    [tbl_pengumuman]
WHERE   [id_pengumuman]  = @_id_pengumuman";
            context.AddParameter("@no", string.Format("{0}", obj.no));
            context.AddParameter("@tanggal", obj.tanggal);
            context.AddParameter("@tanggal_hingga", obj.tanggal_hingga);
            context.AddParameter("@judul", string.Format("{0}", obj.judul));
            context.AddParameter("@isi", string.Format("{0}", obj.isi));
            context.AddParameter("@created", obj.created);
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@editor", string.Format("{0}", obj.editor));
            context.AddParameter("@edited", obj.edited);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_pengumuman>(context, new tbl_pengumuman()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_pengumuman]
        /// </summary>        
        public static tbl_pengumuman Update(tbl_pengumuman obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_pengumuman]
SET         [no] = @no,
            [tanggal] = @tanggal,
            [tanggal_hingga] = @tanggal_hingga,
            [judul] = @judul,
            [isi] = @isi,
            [creator] = @creator,
            [editor] = @editor,
            [edited] = @edited
WHERE       [id_pengumuman]  = @id_pengumuman

SET @Err = @@Error

SELECT  id_pengumuman, no, tanggal, tanggal_hingga, judul, isi, created, creator, editor, edited 
FROM    [tbl_pengumuman]
WHERE   [id_pengumuman]  = @id_pengumuman";
            context.AddParameter("@no", string.Format("{0}", obj.no));
            context.AddParameter("@tanggal", obj.tanggal);
            context.AddParameter("@tanggal_hingga", obj.tanggal_hingga);
            context.AddParameter("@judul", string.Format("{0}", obj.judul));
            context.AddParameter("@isi", string.Format("{0}", obj.isi));
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@editor", string.Format("{0}", obj.editor));
            context.AddParameter("@edited", obj.edited);
            context.AddParameter("@id_pengumuman", obj.id_pengumuman);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_pengumuman>(context, new tbl_pengumuman()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_pengumuman]
        /// </summary>        
        public static int Delete(Int32 id_pengumuman)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_pengumuman 
WHERE   [id_pengumuman]  = @id_pengumuman";
            context.AddParameter("@id_pengumuman", id_pengumuman);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteNonQuery(context);
        }
        public static int GetCount(int PageSize, int PageIndex)
        {
            return GetTotalRecord();
        }
        /// <summary>
        /// Get Total records from [tbl_pengumuman]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_pengumuman";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_pengumuman]
        /// </summary>        
        public static List<tbl_pengumuman> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id_pengumuman, no, tanggal, tanggal_hingga, judul, isi, created, creator, editor, edited FROM tbl_pengumuman";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_pengumuman>(context, new tbl_pengumuman());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_pengumuman]
        /// </summary>        
        public static List<tbl_pengumuman> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_pengumuman] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_pengumuman].[id_pengumuman] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_pengumuman].*
                FROM    [tbl_pengumuman]
            )

            SELECT      [Paging_tbl_pengumuman].*
            FROM        [Paging_tbl_pengumuman]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_pengumuman>(context, new tbl_pengumuman());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_pengumuman] by Primary Key
        /// </summary>        
        public static tbl_pengumuman GetByPK(Int32 id_pengumuman)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id_pengumuman, no, tanggal, tanggal_hingga, judul, isi, created, creator, editor, edited FROM tbl_pengumuman
            WHERE [id_pengumuman]  = @id_pengumuman";
            context.AddParameter("@id_pengumuman", id_pengumuman);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_pengumuman>(context, new tbl_pengumuman()).FirstOrDefault();
        }

        #endregion

    }
}