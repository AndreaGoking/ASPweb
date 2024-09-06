using Microsoft.AspNetCore.Mvc;

namespace BTVN_slide20.Controllers
{
    public class Tuan02Controller : Controller
    {
        public IActionResult Index()
        {
            ViewBag.HoTen = "Đỗ Ngọc Quân";
            ViewBag.MSSV = "1822020710";
            ViewBag.Nam = 2024;
            return View();
        }
        public ActionResult MayTinh(double a = 0, double b = 0, string pheptinh = "")
        {
            double ketqua = 0;
            ViewBag.ThongBao = null;  // Gán giá trị mặc định
            ViewBag.KetQua = null;     // Gán giá trị mặc định

            switch (pheptinh.ToLower())
            {
                case "cong":
                    ketqua = a + b;
                    break;
                case "tru":
                    ketqua = a - b;
                    break;
                case "nhan":
                    ketqua = a * b;
                    break;
                case "chia":
                    if (b != 0)
                    {
                        ketqua = a / b;
                    }
                    else
                    {
                        ViewBag.ThongBao = "Không thể chia cho 0";
                    }
                    break;
                default:
                    ViewBag.ThongBao = "Phép tính không hợp lệ";
                    break;
            }

            if (ViewBag.ThongBao == null)
            {
                ViewBag.KetQua = ketqua;
            }

            return View();
        }
    }
}
