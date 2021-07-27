using DataAccessLayer;
using SMK.BAWANG.Dto.custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMK.BAWANG.Dta.custom
{
    public class tbl_point_cstmItem
    {
        public static List<tbl_point_cstm> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"select distinct a.NIS, a.Kelas, Nama, isnull(SUM(poin),0) as Jumlah_Point from [dbo].[tbl_data_siswa] a 
                left outer join[dbo].[tbl_point_siswa] b on a.NIS = b.NIS and a.kelas = b.Kelas
                left outer join[dbo].[tbl_tata_tertib] c on b.id_tata_tertib = c.id_tata_tertib
                group by a.NIS,nama, a.kelas
                order by a.NIS";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_point_cstm>(context, new tbl_point_cstm());
        }

        public static List<tbl_point_cstm> GetAllByKelas(string kelas)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"select distinct a.NIS, a.Kelas, Nama, isnull(SUM(poin),0) as Jumlah_Point from [dbo].[tbl_data_siswa] a 
                left outer join[dbo].[tbl_point_siswa] b on a.NIS = b.NIS and a.kelas = b.Kelas
                left outer join[dbo].[tbl_tata_tertib] c on b.id_tata_tertib = c.id_tata_tertib
                where a.Kelas = @kelas
                group by a.NIS,nama, a.kelas
                order by a.NIS";

            context.AddParameter("@kelas", kelas);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_point_cstm>(context, new tbl_point_cstm());
        }


        public static List<tbl_poin_nis_cstm> getAllByNISKelas(string NIS, string Kelas)
        {
            List<tbl_poin_nis_cstm> obj = new List<tbl_poin_nis_cstm>();

            IDBHelper context = new DBHelper();
            string sqlQuery = @"select b.id_poin_siswa, a.NIS, a.Kelas, Nama, c.id_tata_tertib, c.tata_tertib, c.poin, d.Aspek, b.created, b.creator, b.edited, b.editor  from 
                [dbo].[tbl_data_siswa] a 
				left outer join [dbo].[tbl_point_siswa] b on a.NIS = b.NIS and a.kelas = b.Kelas 
				left outer join [dbo].[tbl_tata_tertib] c on b.id_tata_tertib = c.id_tata_tertib
				left outer join [dbo].[tbl_m_aspek] d on c.aspek = d.id
                 where a.NIS=@nis and a.kelas=@kelas";
            context.CommandText = sqlQuery;
            context.AddParameter("@nis", NIS);
            context.AddParameter("@kelas", Kelas);
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_poin_nis_cstm>(context, new tbl_poin_nis_cstm());
        }

        public static List<tbl_poin_nis_cstm> getAllByNIS(string NIS)
        {
            List<tbl_poin_nis_cstm> obj = new List<tbl_poin_nis_cstm>();

            IDBHelper context = new DBHelper();
            string sqlQuery = @"select b.id_poin_siswa, a.NIS, a.Kelas, Nama, c.id_tata_tertib, c.tata_tertib, c.poin, d.Aspek, b.created, b.creator, b.edited, b.editor  from 
                [dbo].[tbl_data_siswa] a 
				left outer join [dbo].[tbl_point_siswa] b on a.NIS = b.NIS and a.kelas = b.Kelas 
				left outer join [dbo].[tbl_tata_tertib] c on b.id_tata_tertib = c.id_tata_tertib
				left outer join [dbo].[tbl_m_aspek] d on c.aspek = d.id
                 where a.NIS=@nis";
            context.CommandText = sqlQuery;
            context.AddParameter("@nis", NIS);
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_poin_nis_cstm>(context, new tbl_poin_nis_cstm());
        }

        public static tbl_poin_nis_cstm getByID(Int32 id_poin_siswa)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"select b.id_poin_siswa, a.NIS, a.Kelas, Nama, c.id_tata_tertib, c.tata_tertib, c.poin, d.Aspek, b.created, b.creator, b.edited, b.editor  from 
                [dbo].[tbl_data_siswa] a 
				left outer join [dbo].[tbl_point_siswa] b on a.NIS = b.NIS and a.kelas = b.Kelas 
				left outer join [dbo].[tbl_tata_tertib] c on b.id_tata_tertib = c.id_tata_tertib
				left outer join [dbo].[tbl_m_aspek] d on c.aspek = d.id
                where b.id_poin_siswa= @id_poin_siswa";

            context.AddParameter("@id_poin_siswa", id_poin_siswa);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_poin_nis_cstm>(context, new tbl_poin_nis_cstm()).FirstOrDefault();
        }

    }
}
