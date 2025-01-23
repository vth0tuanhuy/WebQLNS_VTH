namespace WebQLNS_VTH.Models
{
    using System;
    using System.Collections.Generic;
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
        public string maNV { get; set; }

        [StringLength(50)]
        public string thangNam { get; set; }

        public double? bacLuong { get; set; }

        public double? heSoLuong { get; set; }

        public decimal? mucLuong { get; set; }

        public decimal? phuCap { get; set; }

        public int? soNgayCong { get; set; }

        public int? nghiKhongPhep { get; set; }

        public decimal? luongUngTruoc { get; set; }

        public decimal? luongNhan { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
