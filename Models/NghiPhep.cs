namespace WebQLNS_VTH.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NghiPhep")]
    public partial class NghiPhep
    {
        [Key]
        [StringLength(50)]
        public string maNghiPhep { get; set; }

        [StringLength(50)]
        [DisplayName("M? nh�n vi�n")]
        public string maNV { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("T? ng�y")]

        public DateTime? tuNgay { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("�?n ng�y")]

        public DateTime? denNgay { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
