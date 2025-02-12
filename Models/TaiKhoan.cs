namespace WebQLNS_VTH.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [Key]
        [StringLength(50)]
        public string maTK { get; set; }

        [StringLength(50)]
        [DisplayName("Tên ðãng nh?p")]

        public string tenDangNhap { get; set; }

        [StringLength(50)]
        [DisplayName("M?t kh?u")]

        public string matKhau { get; set; }

        [StringLength(50)]
        [DisplayName("Lo?i tài kho?n")]

        public string loaiTK { get; set; }

        [StringLength(50)]
        [DisplayName("M? nhân viên")]

        public string maNV { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
