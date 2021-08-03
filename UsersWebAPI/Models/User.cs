using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UsersWebAPI.Models
{
    public class User
    {
        [Key]
        public string Nick { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Tlf { get; set; }
    }
}
