using DataAccessLayer;
using SMK.BAWANG.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMK.BAWANG.Dta.custom
{
    public class tbl_data_siswa_cstmItem
    {
        public static tbl_data_siswa GetByNo( string nis)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT username, password, NIS, nama, kelas, created, creator, edited, editor FROM tbl_data_siswa
            WHERE [NIS]  = @nis";
            context.AddParameter("@nis", nis);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_data_siswa>(context, new tbl_data_siswa()).FirstOrDefault();
        }

        public static tbl_data_siswa GetByNo(string username, string nis)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT username, password, NIS, nama, kelas, created, creator, edited, editor FROM tbl_data_siswa
            WHERE [NIS]  = @nis and username <> @username";
            context.AddParameter("@username", username);
            context.AddParameter("@nis", nis);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_data_siswa>(context, new tbl_data_siswa()).FirstOrDefault();
        }

        public static List<tbl_data_siswa> GetAllByKelas(string kelas)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT username, password, NIS, nama, kelas, created, creator, edited, editor FROM tbl_data_siswa where kelas = @kelas";
            context.AddParameter("@kelas", kelas);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_data_siswa>(context, new tbl_data_siswa());
        }

    }
}
