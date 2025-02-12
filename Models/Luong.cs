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
        [DisplayName("Nhân viên")]
        public string maNV { get; set; }

        [StringLength(50)]
        [DisplayName("Tháng nãm")]
        public string thangNam { get; set; }
        [DisplayName("B?c lýõng")]
        public double? bacLuong { get; set; }
        [DisplayName("H? s? lýõng")]

        public double? heSoLuong { get; set; }
        [DisplayName("M?c lýõng")]

        public decimal? mucLuong { get; set; }
        [DisplayName("Ph? c?p")]

        public decimal? phuCap { get; set; }
        [DisplayName("S? ngày công")]

        public int? soNgayCong { get; set; }
        [DisplayName("S? ngày ngh?")]

        public int? nghiKhongPhep { get; set; }
        [DisplayName("?ng trý?c")]

        public decimal? luongUngTruoc { get; set; }
        [DisplayName("Lýõng nh?n")]

        public decimal? luongNhan { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
