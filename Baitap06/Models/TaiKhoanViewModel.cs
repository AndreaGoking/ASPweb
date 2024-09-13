using Microsoft.AspNetCore.Mvc;

namespace Baitap06.Models
{
    public class TaiKhoanViewModel : Controller
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
