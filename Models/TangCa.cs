namespace WebQLNS_VTH.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TangCa")]
    public partial class TangCa
    {
        [Key]
        [StringLength(50)]
        public string maTangCa { get; set; }

        [StringLength(50)]
        [DisplayName("M? nhân viên")]

        public string maNV { get; set; }
        [DisplayName("S? gi?")]

        public int? soGio { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Ngày tãng ca")]

        public DateTime? ngayTangCa { get; set; }

        [StringLength(50)]
        [DisplayName("Lo?i tãng ca")]

        public string loaiTangCa { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
