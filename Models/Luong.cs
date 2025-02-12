namespace WebQLNS_VTH.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Luong")]
    public partial class Luong
    {
        [Key]
        [StringLength(50)]
        public string maLuong { get; set; }

        [StringLength(50)]
        [DisplayName("Nh�n vi�n")]
        public string maNV { get; set; }

        [StringLength(50)]
        [DisplayName("Th�ng n�m")]
        public string thangNam { get; set; }
        [DisplayName("B?c l��ng")]
        public double? bacLuong { get; set; }
        [DisplayName("H? s? l��ng")]

        public double? heSoLuong { get; set; }
        [DisplayName("M?c l��ng")]

        public decimal? mucLuong { get; set; }
        [DisplayName("Ph? c?p")]

        public decimal? phuCap { get; set; }
        [DisplayName("S? ng�y c�ng")]

        public int? soNgayCong { get; set; }
        [DisplayName("S? ng�y ngh?")]

        public int? nghiKhongPhep { get; set; }
        [DisplayName("?ng tr�?c")]

        public decimal? luongUngTruoc { get; set; }
        [DisplayName("L��ng nh?n")]

        public decimal? luongNhan { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
