using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Data.Migrations;
using Project.Models;
using System.Security.Claims;

namespace Project.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class GioHangController : Controller
    {
        private readonly ApplicationDbContext _db;
        public GioHangController(ApplicationDbContext db)
        {

            _db = db;

        }
        public IActionResult Index()
        {
            // Lay thong tin dang nhap
            var identity = (ClaimsIdentity)User.Identity;
            var claim = identity.FindFirst(ClaimTypes.NameIdentifier);

            // Lấy danh sách sản phẩm trong giỏ hàng của user
            GioHangViewModel giohang = new GioHangViewModel
            {

                DsGioHang = _db.GioHang.Include("SanPham").
                                            Where(gh => gh.ApplicationUserId == claim.Value).
                                            ToList(),
            };

            foreach (var item in giohang.DsGioHang)
            {
                // Tinh tien theo so luong so luong san phan
                item.ProductPrice = item.Quantity * item.SanPham.Price;
                // Tinh tong so tien trong gio hang
                giohang.TotalPrice += item.ProductPrice;
            }
            return View(giohang);
        }


        public IActionResult Xoa(int giohangId)
        {
            var gioHang = _db.GioHang.FirstOrDefault(gh => gh.Id == giohangId);

            _db.GioHang.Remove(gioHang);

            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Tang(int giohangId)
        {
            var giohang = _db.GioHang.FirstOrDefault(gh => gh.Id == giohangId);

            giohang.Quantity++;

            _db.SaveChanges();


            return RedirectToAction("Index");
        }

        public IActionResult Giam(int giohangId)
        {
            var giohang = _db.GioHang.FirstOrDefault(gh => gh.Id == giohangId);

            giohang.Quantity--;

            if (giohang.Quantity == 0)
            {
                { _db.GioHang.Remove(giohang); }
            }
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
