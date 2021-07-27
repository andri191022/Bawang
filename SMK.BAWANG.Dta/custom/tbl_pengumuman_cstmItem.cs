using DataAccessLayer;
using SMK.BAWANG.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMK.BAWANG.Dta.custom
{
    public class tbl_pengumuman_cstmItem
    {
        public static tbl_pengumuman GetByNo(string no)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id_pengumuman, [no], tanggal, tanggal_hingga, judul, isi, creator, created, editor, edited FROM tbl_pengumuman
            WHERE [no]  = @no";
            context.AddParameter("@no", no);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_pengumuman>(context, new tbl_pengumuman()).FirstOrDefault();
        }

        public static List<tbl_pengumuman> GetByDateAktif()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id_pengumuman, [no], tanggal, tanggal_hingga, judul, isi, creator, created, editor, edited FROM tbl_pengumuman
            WHERE CONVERT(date, GETDATE()) between CONVERT(date, tanggal) and CONVERT(date, tanggal_hingga) ";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_pengumuman>(context, new tbl_pengumuman());
        }
    }
}
