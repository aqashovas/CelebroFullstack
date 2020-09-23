using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace celebro.Models
{
    public class Celebrity
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public int Price { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Socialmedia { get; set; }
        public string Photo { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public List<Order> Orders { get; set; }
    }
}