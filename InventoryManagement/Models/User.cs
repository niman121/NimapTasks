using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace InventoryManagement.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public ICollection<Role> Roles { get; set; }
     

    }
}