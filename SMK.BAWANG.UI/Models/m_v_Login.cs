using SMK.BAWANG.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMK.BAWANG.UI.Models
{
    public class m_v_Login: v_Login
    {
        public m_v_Login() { }
        public m_v_Login(v_Login item)
        {
            this.Username = item.Username;
            this.Nama = item.Nama;
            this.Kelas = item.Kelas;
            this.NIS = item.NIS;
            this.typeUser = item.typeUser;
            this.Password = item.Password;
        }

        [Required(ErrorMessage = "Harap masukan Username")]
        [Display(Name = "Username")]
        public new string Username { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Harap masukan Password")]
        [Display(Name = "Password")]
        public new string Password { get; set; }
    }
}


//public string Username { get; set; }
//public string Nama { get; set; }
//public string Kelas { get; set; }
//public string NIS { get; set; }
//public string typeUser { get; set; }