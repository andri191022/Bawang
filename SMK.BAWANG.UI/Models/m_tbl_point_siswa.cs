using SMK.BAWANG.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMK.BAWANG.UI.Models
{
    public class m_tbl_point_siswa : tbl_point_siswa
    {
        public m_tbl_point_siswa() { }

        public m_tbl_point_siswa(tbl_point_siswa item)
        {
            this.id_poin_siswa = item.id_poin_siswa;
            this.NIS = item.NIS;
            this.kelas = item.kelas;
            this.id_tata_tertib = item.id_tata_tertib;
            this.created = item.created;
            this.creator = item.creator;
            this.edited = item.edited;
            this.editor = item.editor;
        }

        //[Required(ErrorMessage = "Harap masukan data ID Poin Siswa")]
        //[Display(Name = "ID Poin Siswa")]
        //public new int id_poin_siswa { get; set; }

        [Required(ErrorMessage = "Harap masukan data NIS")]
        [Display(Name = "NIS")]
        public new string NIS { get; set; }

        [Display(Name = "Kelas")]
        public new string kelas { get; set; }

        [Display(Name = "Tata Tertib")]
        [Required(ErrorMessage = "Harap masukan data Tata Tertib")]
        public new Int32? id_tata_tertib { get; set; }




    }
}