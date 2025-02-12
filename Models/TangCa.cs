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
        [DisplayName("M? nh�n vi�n")]

        public string maNV { get; set; }
        [DisplayName("S? gi?")]

        public int? soGio { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Ng�y t�ng ca")]

        public DateTime? ngayTangCa { get; set; }

        [StringLength(50)]
        [DisplayName("Lo?i t�ng ca")]

        public string loaiTangCa { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
