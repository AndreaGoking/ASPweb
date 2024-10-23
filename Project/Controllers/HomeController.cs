using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace Project.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<SanPham> sanpham = _db.SanPham.Include(sp => sp.TheLoai).ToList();
            return View(sanpham);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult Details(int sanphamid)
        {
            // T?o gi? hàng ? trang Details ð? x? l? ch?c nãng thêm vào gi? sau này
            GioHang giohang = new GioHang()
            {
                SanPhamId = sanphamid,
                SanPham = _db.SanPham.Include("TheLoai").FirstOrDefault(sp => sp.Id == sanphamid),
                Quantity = 1
            };
            return View(giohang);
        }
        [HttpPost]
        [Authorize] // Yêu c?u ðãng nh?p
        public IActionResult Details(GioHang giohang)
        {
            // L?y thông tin tài kho?n
            var identity = (ClaimsIdentity)User.Identity;
            var claim = identity.FindFirst(ClaimTypes.NameIdentifier);
            giohang.ApplicationUserId = claim.Value;

            // Ki?m tra s?n ph?m ð? có trong gi? hàng chýa
            var giohangdb = _db.GioHang.FirstOrDefault(sp => sp.SanPhamId == giohang.SanPhamId
            && sp.ApplicationUserId == giohang.ApplicationUserId);
            if (giohangdb == null) // N?u không có s?n ph?m trong gi? hàng
            {
                _db.GioHang.Add(giohang); // Thêm s?n ph?m vào gi? hàng
            }
            else // N?u không có s?n ph?m trong gi? hàng
            {

                giohangdb.Quantity += giohang.Quantity; // C?p nh?t s? lý?ng s?n ph?m
            }

            // Thêm s?n ph?m vào gi? hàng
            _db.GioHang.Add(giohang);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult FilterByTheLoai(int id)
        {
            IEnumerable<SanPham> sanpham = _db.SanPham.Include("TheLoai").Where(sp => sp.TheLoai.Id == id).ToList();
            return View("Index", sanpham);
        }
    }
}