using SMK.BAWANG.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

namespace SMK.BAWANG.UI.Models
{
    public class m_tbl_guru_bk: tbl_guru_bk
    {
        public m_tbl_guru_bk() { }

        public m_tbl_guru_bk(tbl_guru_bk item)
        {
            this.username = item.username;
            this.nama = item.nama;
            this.password = item.password;
        }

        [Required(ErrorMessage = "Harap masukan data Username")]
        [Display(Name = "Username")]
        [System.Web.Mvc.Remote("IsAlreadyUsername", "GuruBK", ErrorMessage = "Username sudah ada di database.", AdditionalFields = "aeMode")]
        public new string username { get; set; }

        [Required(ErrorMessage = "Harap masukan data Nama")]
        [Display(Name = "Nama")]
        public new string nama { get; set; }

        [Required(ErrorMessage = "Harap masukan data Password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public new string password { get; set; }

        [Required(ErrorMessage = "Harap masukan data Confirm Password")]
        [Display(Name = "Confirm Password")]
        [Compare("password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}