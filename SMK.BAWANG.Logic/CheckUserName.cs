using SMK.BAWANG.Dta;
using SMK.BAWANG.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMK.BAWANG.Logic
{
    public class CheckUserName
    {
        public static bool IsAlreadyUsername(string usename)
        {
            bool status;

            tbl_data_siswa objS = new tbl_data_siswa();
            objS = tbl_data_siswaItem.GetByPK(usename);

            tbl_wali_kelas objw = new tbl_wali_kelas();
            objw = tbl_wali_kelasItem.GetByPK(usename);

            tbl_guru_bk objg = new tbl_guru_bk();
            objg = tbl_guru_bkItem.GetByPK(usename);

            if (objS != null || objw != null || objg != null)
            {
                //Already registered  
                status = false;
            }
            else
            {
                //Available to use  
                status = true;
            }

            return status;
        }
    }
}
