namespace RaoVar247.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "KHông ???c b? tr?ng !")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "KHông ???c b? tr?ng !")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "KHông ???c b? tr?ng !")]
        [StringLength(50)]
        public string UserName { get; set; }


        [ScaffoldColumn(true)]
        [RegularExpression(@"[0-9]+",ErrorMessage = "So dien thoai khong duoc chua chu")]
        [StringLength(10, ErrorMessage = "So dien thoai yeu cau 10 so ")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "KHông ???c b? tr?ng !")]
        [MinLength(8, ErrorMessage =" M?t kh?u t?i thi?u 8 kí t?")]
        public string Password { get; set; }

        [StringLength(50)]
        public string Address { get; set; }


        [StringLength(50)]
        public string Avatar { get; set; }

        public bool Status { get; set; }
    }
}
