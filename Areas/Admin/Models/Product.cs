using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopBanHoa.Areas.Admin.Models
{
    public class Product
    {
        [Required]
        public int MaSP { get; set; }

        [Required]
        public int MaDM { get; set; }
        public string TenDM { get; set; }

        [MaxLength(200)]
        [Required]
        public string TenSP { get; set; }

        [Required]
        public string AnhSP { get; set; }

        [Required]
        public int GiaSP { get; set; }

        [Required]
        public int TrangThai { get; set; }

        public int? BestSeller { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime NgaySua { get; set; }

        [Required]
        public string MotaSP { get; set; }
        [Required]
        public int SoLuong { get; set; }
     
        public Category DanhMucSP { get; set; }
    }
}