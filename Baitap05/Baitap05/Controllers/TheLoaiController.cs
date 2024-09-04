﻿using Baitap05.Models;
using Microsoft.AspNetCore.Mvc;

namespace Baitap05.Controllers
{
    public class TheLoaiController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Ngay = "Ngày 28";
            ViewBag.Thang = "Tháng 02";
            ViewData["Nam"] = "Năm 2030";
            return View();
        }
        public IActionResult Index2()
        {
            var theloai = new TheLoaiViewModal
            {
                Id = 1,
                Name = "Trinh Thám"
            };
            return View(theloai);
        }
    }
}
}
