using System.ComponentModel.DataAnnotations;

namespace BaiTapKiemTra01.Models
{
    public class TaiKhoanViewModel
    {
        public int Id { get; set; }

        public string Username { get; set; }


        public string Password { get; set; }


        public string FullName { get; set; }

        public int Age { get; set; }
    }
}
