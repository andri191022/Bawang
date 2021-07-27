using SMK.BAWANG.Dto;
//using System;
//using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

namespace SMK.BAWANG.UI.Models
{
    public class m_tbl_wali_kelas: tbl_wali_kelas
    {
        public m_tbl_wali_kelas() { }

        public m_tbl_wali_kelas(tbl_wali_kelas item)
        {
            this.username = item.username;
            this.nama = item.nama;
            this.password = item.password;
            this.wali_kelas = item.wali_kelas;
            this.created = item.created;
            this.creator = item.creator;
            this.edited = item.edited;
            this.editor = item.editor;
        }

        [Required(ErrorMessage = "Harap masukan data Username")]
        [Display(Name = "Username")]
        [System.Web.Mvc.Remote("IsAlreadyUsername", "WaliKelas", ErrorMessage = "Username sudah ada di database.", AdditionalFields = "aeMode")]
        public new string username { get; set; }

        [Required(ErrorMessage = "Harap masukan data Nama")]
        [Display(Name = "Nama")]
        public new string nama { get; set; }

        [Required(ErrorMessage = "Harap masukan data Password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 7)]
        public new string password { get; set; }


        [Required(ErrorMessage = "Harap masukan data Confirm Password")]
        [Display(Name = "Confirm Password")]
        [Compare("password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage = "Harap masukan data Wali Kelas")]
        [Display(Name = "Wali Kelas")]
        public new string wali_kelas { get; set; }

    }
}