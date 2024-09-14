using BaiTapKiemTra01.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiTapKiemTra01.Controllers
{
    public class TaiKhoanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DangKy(TaiKhoanViewModel taikhoan)
        {
            if (ModelState.IsValid)
            {
                // Lấy dữ liệu từ form và hiển thị bằng Content()
                string message = $"Tài khoản: {taikhoan.Username}, Mật khẩu: {taikhoan.Password}, Họ tên: {taikhoan.FullName}, Tuổi: {taikhoan.Age}";

                return Content(message); // Hiển thị nội dung vừa nhập
            }

            return View(); 
        }
    }
}
