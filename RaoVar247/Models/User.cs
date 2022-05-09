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


        [StringLength(10)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "KHông ???c b? tr?ng !")]
        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

     
    }
}
