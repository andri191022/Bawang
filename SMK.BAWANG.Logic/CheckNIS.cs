using SMK.BAWANG.Dta.custom;
using SMK.BAWANG.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMK.BAWANG.Logic
{
    public class CheckNIS
    {
        public static bool IsAlreadyUsernameNIS(string username, string NIS, string aeMode)
        {
            bool status;

            tbl_data_siswa objS = new tbl_data_siswa();
            if (aeMode == "EDIT")
            {
                objS = tbl_data_siswa_cstmItem.GetByNo(username, NIS);
            }
            else
            {
                objS = tbl_data_siswa_cstmItem.GetByNo(NIS);
            }


            if (objS != null)
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
