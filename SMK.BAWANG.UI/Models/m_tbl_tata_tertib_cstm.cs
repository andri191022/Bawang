using SMK.BAWANG.Dto.custom;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMK.BAWANG.UI.Models
{
    public class m_tbl_tata_tertib_cstm : tbl_tata_tertib_cstm
    {
        public m_tbl_tata_tertib_cstm() { }
        public m_tbl_tata_tertib_cstm(tbl_tata_tertib_cstm item)
        {
            this.id_tata_tertib = item.id_tata_tertib;
            this.tata_tertib = item.tata_tertib;
            this.poin = item.poin;
            this.aspek = item.aspek;
            this.created = item.created;
            this.creator = item.creator;
            this.edited = item.edited;
            this.editor = item.editor;
        }



        [Required(ErrorMessage = "Harap masukan data Tata Tertib")]
        [Display(Name = "Tata Tertib")]
        public new string tata_tertib { get; set; }

        [Required(ErrorMessage = "Harap masukan data Poin")]
        [Range(0, 100, ErrorMessage = "Please enter valid integer Number")]
        [Display(Name = "Poin")]
        public new int? poin { get; set; }

        [Required(ErrorMessage = "Harap masukan data Aspek")]
        [Display(Name = "Aspek")]
        public new string aspek { get; set; }
    }
}