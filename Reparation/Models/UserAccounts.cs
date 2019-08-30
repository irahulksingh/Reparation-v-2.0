using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Reparation.Models
{
    public class UserAccounts
    {

        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Anställningsnummer krävs")]
        public string Anummer { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Lösenord krävs")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required (ErrorMessage = "Lösenord missanpassning")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string confirmPassword { get; set; }


        [Required (ErrorMessage = "ButikId krävs")]
        public string ButikId { get; set; }

       
        [Range(1,3)]
        [Required(ErrorMessage = "Roles krävs")]
        public Roles Role{ get; set; }


        public enum Roles
        {
            Admin = 1,
            User = 2,
            Demo=3

        }

        public string Createdby { get; set; }

        public DateTime? CreatedOn { get; set; }



    }
}
