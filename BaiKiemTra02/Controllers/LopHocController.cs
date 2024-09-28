using BaiKiemTra02.Data;
using BaiKiemTra02.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiKiemTra02.Controllers
{
    public class LopHocController : Controller
    {
        private readonly ApplicationDbContext _db;
        public LopHocController(ApplicationDbContext db)
        {
            _db = db;
        }
        // Hiển thị danh sách lớp học
        public IActionResult Index()
        {
            var lophoc = _db.LopHoc.ToList();
            ViewBag.LopHoc = lophoc;

            return View(lophoc);
        }
        // GET: Tạo mới lớp học
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tạo mới lớp học
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LopHoc lophoc)
        {
            if (ModelState.IsValid)
            {
                _db.LopHoc.Add(lophoc);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lophoc);
        }

        // GET: Chỉnh sửa lớp học
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var lophoc = _db.LopHoc.Find(id);
            if (lophoc == null)
            {
                return NotFound();
            }
            return View(lophoc);
        }

        // POST: Chỉnh sửa lớp học
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(LopHoc lophoc)
        {
            if (ModelState.IsValid)
            {
                _db.LopHoc.Update(lophoc);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lophoc);
        }

        // GET: Xóa lớp học
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var lophoc = _db.LopHoc.Find(id);
            if (lophoc == null)
            {
                return NotFound();
            }
            return View(lophoc);
        }

        // POST: Xác nhận xóa lớp học
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var lophoc = _db.LopHoc.Find(id);
            if (lophoc == null)
            {
                return NotFound();
            }
            _db.LopHoc.Remove(lophoc);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Xem chi tiết lớp học
        [HttpGet]
        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var lophoc = _db.LopHoc.Find(id);
            if (lophoc == null)
            {
                return NotFound();
            }
            return View(lophoc);
        }

    }
}
