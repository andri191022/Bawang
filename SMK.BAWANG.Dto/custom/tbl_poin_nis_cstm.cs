using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMK.BAWANG.Dto.custom
{
    public class tbl_poin_nis_cstm : IDataMapper<tbl_poin_nis_cstm>
    {
        public int? id_poin_siswa { get; set; }
        public string NIS { get; set; }
        public string Nama { get; set; }
        public string Kelas { get; set; }
        public int? id_tata_tertib { get; set; }
        public string tata_tertib { get; set; }
        public int? poin { get; set; }
        public string Aspek { get; set; }
        public string creator { get; set; }
        public DateTime? created { get; set; }
        public string editor { get; set; }
        public DateTime? edited { get; set; }

        public tbl_poin_nis_cstm Map(System.Data.IDataReader reader)
        {
            tbl_poin_nis_cstm obj = new tbl_poin_nis_cstm();

            obj.id_poin_siswa = reader["id_poin_siswa"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["id_poin_siswa"]);
            obj.NIS = reader["NIS"] == DBNull.Value ? null : reader["NIS"].ToString();
            obj.Nama = reader["Nama"] == DBNull.Value ? null : reader["Nama"].ToString();
            obj.Kelas = reader["Kelas"] == DBNull.Value ? null : reader["Kelas"].ToString();
            obj.id_tata_tertib = reader["id_tata_tertib"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["id_tata_tertib"]);
            obj.tata_tertib = reader["tata_tertib"] == DBNull.Value ? null : reader["tata_tertib"].ToString();
            obj.poin = reader["poin"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["poin"]);
            obj.Aspek = reader["Aspek"] == DBNull.Value ? null : reader["Aspek"].ToString();

            obj.creator = reader["creator"] == DBNull.Value ? null : reader["creator"].ToString();
            obj.created = reader["created"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["created"]);
            obj.editor = reader["editor"] == DBNull.Value ? null : reader["editor"].ToString();
            obj.edited = reader["edited"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["edited"]);

            return obj;
        }
    }
}
