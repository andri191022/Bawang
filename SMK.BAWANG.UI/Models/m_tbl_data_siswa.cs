using SMK.BAWANG.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

namespace SMK.BAWANG.UI.Models
{
    public class m_tbl_data_siswa : tbl_data_siswa
    {
        public m_tbl_data_siswa() { }

        public m_tbl_data_siswa(tbl_data_siswa item)
        {
            this.NIS = item.NIS;
            this.nama = item.nama;
            this.kelas = item.kelas;
            this.username = item.username;
            this.password = item.password;
            this.created = item.created;
            this.creator = item.creator;
            this.edited = item.edited;
            this.editor = item.editor;
        }

        [Required(ErrorMessage = "Harap masukan data NIS")]
        [Display(Name = "NIS")]
        [System.Web.Mvc.Remote("IsAlreadyNIS", "DataSiswa", ErrorMessage = "NIS sudah ada di database.", AdditionalFields = "username, aeMode")]
        public new string NIS { get; set; }

        [Required(ErrorMessage = "Harap masukan data Nama")]
        [Display(Name = "Nama")]
        public new string nama { get; set; }

        [Required(ErrorMessage = "Harap masukan data Kelas")]
        [Display(Name = "Kelas")]
        public new string kelas { get; set; }

        [Required(ErrorMessage = "Harap masukan data Psername")]
        [Display(Name = "Username")]
        [System.Web.Mvc.Remote("IsAlreadyUsername", "DataSiswa", ErrorMessage = "Username sudah ada di database.", AdditionalFields = "aeMode")]
        public new string username { get; set; }

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