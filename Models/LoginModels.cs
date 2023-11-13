using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace lifetime_apd.Models
{
    public partial class user
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Username harus diisi.")]
        public string USERNAME { get; set; }

        [Required(ErrorMessage = "Password harus diisi.")]
        [DataType(DataType.Password)]
        public string PASSWORD { get; set; }
    }
}