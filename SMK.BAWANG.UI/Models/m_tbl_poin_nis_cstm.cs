using SMK.BAWANG.Dto.custom;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMK.BAWANG.UI.Models
{
    public class m_tbl_poin_nis_cstm : tbl_poin_nis_cstm
    {
        public m_tbl_poin_nis_cstm() { }
        public m_tbl_poin_nis_cstm(tbl_poin_nis_cstm item)
        {
            this.id_poin_siswa = item.id_poin_siswa;
            this.NIS = item.NIS;
            this.Nama = item.Nama;
            this.Kelas = item.Kelas;
            this.id_tata_tertib = item.id_tata_tertib;
            this.tata_tertib = item.tata_tertib;
            this.Aspek = item.Aspek;
            this.poin = item.poin;
            this.created = item.created;
            this.creator = item.creator;
            this.edited = item.edited;
            this.editor = item.editor;
        }

        [Required(ErrorMessage = "Harap masukan data Poin")]
        public new string NIS { get; set; }

        [Required(ErrorMessage = "Harap masukan data Poin")]
        //[Range(0, 100, ErrorMessage = "Please enter valid integer Number")]
        [Display(Name = "Poin")]
        public new int? poin { get; set; }

        [Required(ErrorMessage = "Harap masukan data Tata Tertib")]
        [Display(Name = "Tata Tertib")]
        public new Int32? id_tata_tertib { get; set; }

        [Display(Name = "Tata Tertib")]
        public new string tata_tertib { get; set; }



    }
}