using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.Models
{
   // [Table("tblProduct")]
    public class Product
    {
      //  [Key]
      //  [ScaffoldColumn(false)]
        [Required(ErrorMessage ="Id is required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "name is required")]
        [Display(Name="Employee Name")]
        [MaxLength(40)]
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "name is required")]
        public int Price { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "password is required")]
        public string password { get; set; }

        [Required(ErrorMessage = "email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
