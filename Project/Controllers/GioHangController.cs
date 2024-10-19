using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using System.Security.Claims;

namespace Project.Controllers
{
    [Area("Customer")]
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
            IEnumerable<GioHang> dsGioHang = _db.GioHang
                .Include("SanPham").
                                            
                Where(gh => gh.ApplicationUserId == claim.Value).
                                            ToList();

            return View(dsGioHang);
        }
    }
}
