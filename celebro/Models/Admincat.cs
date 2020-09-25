using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace celebro.Models
{
    public class Admincat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Admin> Admins { get; set; }
    }
}