namespace RaoVar247.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Không ???c ?? tr?ng !")]
        //[RegularExpression(@"^[0-9]{1,}\w{1,}",ErrorMessage ="Không b?t ??u b?ng s? ")]
        [StringLength(100)]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Không ???c ?? tr?ng !")]
        [RegularExpression(@"^\w{1,}",ErrorMessage = "Giá bán không bao g?m ch?")]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public DateTime CreateDate { get; set; }

        [StringLength(2)]
        public string Status { get; set; }
        [Required(ErrorMessage = "Không ???c ?? tr?ng !")]
        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(100)]
        public string ImagePath { get; set; }

        [Required(ErrorMessage = "Không ???c ?? tr?ng !")]
        [StringLength(999)]
        public string Description { get; set; }


        [StringLength(50)]
        public string Province { get; set; }

        [StringLength(50)]
        public string District { get; set; }

        public int? UserId { get; set; }

        public virtual User User { get; set; }

        public int? SubCategoryId { get; set; }

        public virtual SubCategory SubCategory { get; set; }

    }
}
