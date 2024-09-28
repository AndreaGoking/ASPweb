using System.ComponentModel.DataAnnotations;

namespace BaiKiemTra02.Models
{
    public class LopHoc
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên lớp học là bắt buộc")]
        [Display(Name = "Tên Lớp Học")]
        [StringLength(100, ErrorMessage = "Tên lớp học không được vượt quá 100 ký tự")]
        public string TenLopHoc { get; set; }

        [Required(ErrorMessage = "Năm nhập học là bắt buộc")]
        [Display(Name = "Năm Nhập Học")]
        [Range(1900, 2100, ErrorMessage = "Năm nhập học không hợp lệ")]
        public int NamNhapHoc { get; set; }

        [Required(ErrorMessage = "Năm ra trường là bắt buộc")]
        [Display(Name = "Năm Ra Trường")]
        [Range(1900, 2100, ErrorMessage = "Năm ra trường không hợp lệ")]
        public int NamRaTruong { get; set; }

        [Required(ErrorMessage = "Số lượng sinh viên là bắt buộc")]
        [Display(Name = "Số Lượng Sinh Viên")]
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng sinh viên phải lớn hơn 0")]
        public int SoLuongSinhVien { get; set; }
    }
}
