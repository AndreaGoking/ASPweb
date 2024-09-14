using BaiTapKiemTra01.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiTapKiemTra01.Controllers
{
    public class SanPhamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BaiTap2()
        {
            var sanPham = new SanPhamViewModel
            {
                TenSanPham = "Laptop Dell XPS",
                GiaBan = 30000000,
                AnhMoTa = "/images/imageslaptop-dell-xps"
            };
            return View(sanPham);
        }
    }
}
