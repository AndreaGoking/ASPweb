using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace Project.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SanPhamController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SanPhamController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            // Lấy thông tin trong bảng sản phẩm và bao gồm thêm thông tin bảng TheLoai
            IEnumerable<SanPham> sanpham = _db.SanPham.Include("TheLoai").ToList();
            return View(sanpham);
        }
        [HttpGet]
        public IActionResult Upsert(int id)
        {
            SanPham sanpham = new SanPham();
            IEnumerable<SelectListItem> dstheloai = _db.TheLoai.Select(
            item => new SelectListItem
            {
                Value = item.Id.ToString(),
                Text = item.Name
            });

            ViewBag.DSTheLoai = dstheloai;
            if (id == 0)
            // Create / Insert
            {
                return View(sanpham);
            }
            else // Edit / Update
            {
                sanpham = _db.SanPham.Include("TheLoai").FirstOrDefault(sp => sp.Id == id);
                return View(sanpham);
            }

        }
        [HttpPost]
        public IActionResult Upsert(SanPham sanpham)
        {
            if (ModelState.IsValid)
            {
                if (sanpham.Id == 0)
                {
                    _db.SanPham.Add(sanpham);
                }
                else
                {
                    _db.SanPham.Update(sanpham);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var sanpham = _db.SanPham.FirstOrDefault(sp => sp.Id == id);
            if (sanpham == null)
            {
                return NotFound();
            }
            _db.SanPham.Remove(sanpham);
            _db.SaveChanges();
            return Json(new { success = true });
        }
    }
}

