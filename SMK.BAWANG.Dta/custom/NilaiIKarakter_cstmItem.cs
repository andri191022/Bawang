using DataAccessLayer;
using System.Data;

namespace SMK.BAWANG.Dta.custom
{
    public class NilaiIKarakter_cstmItem
    {
        public static DataTable getAll()
        {
            IDBHelper context = new DBHelper();
            context.CommandText = @"sp_generateNilaiKarakter";
            context.CommandType = CommandType.StoredProcedure;         
            DataSet ds = DBUtil.ExecuteDataSet(context);

            if (ds != null)
            {
                return ds.Tables[0];
            }

            return null;
        }

        public static DataTable getAllbyKelas(string kelas)
        {
            IDBHelper context = new DBHelper();
            context.CommandText = @"sp_generateNilaiKarakterKelas";

            context.AddParameter("@kelas", kelas);
            context.CommandType = CommandType.StoredProcedure;
            DataSet ds = DBUtil.ExecuteDataSet(context);

            if (ds != null)
            {
                return ds.Tables[0];
            }

            return null;
        }

    }
}
