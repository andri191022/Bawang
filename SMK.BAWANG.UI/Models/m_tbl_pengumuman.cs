using SMK.BAWANG.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMK.BAWANG.UI.Models
{
    public class m_tbl_pengumuman : tbl_pengumuman
    {
        public m_tbl_pengumuman() { }

        public m_tbl_pengumuman(tbl_pengumuman item)
        {
            this.id_pengumuman = item.id_pengumuman;
            this.no = item.no;
            this.tanggal = item.tanggal;
            this.tanggal_hingga = item.tanggal_hingga;
            this.judul = item.judul;
            this.isi = item.isi;
            this.creator = item.creator;
            this.created = item.created;
            this.edited = item.edited;
            this.editor = item.editor;
        }

        [Required(ErrorMessage = "Harap masukan data No Pengumuman")]
        [Display(Name = "Nomor Pengumuman")]
        //[Remote("IsAlreadyNo", "Pengumuman", ErrorMessage = "No Pengumuman sudah ada di database.")]
        public new string no { get; set; }

        [Required(ErrorMessage = "Harap masukan data Tanggal Pengumuman")]
        [Display(Name = "Tanggal Pengumuman")]
        //[DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public new DateTime? tanggal { get; set; }


        [Required(ErrorMessage = "Harap masukan data Tanggal Pengumuman")]
        [Display(Name = "Tanggal Hingga")]
        //[DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public new DateTime? tanggal_hingga { get; set; }

        [Required(ErrorMessage = "Harap masukan data Judul Pengumuman")]
        [Display(Name = "Judul Pengumuman")]
        public new string judul { get; set; }

        [Display(Name = "Isi Pengumuman")]
        public new string isi { get; set; }

    }
}