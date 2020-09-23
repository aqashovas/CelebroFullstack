using celebro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace celebro.Viewmodels
{
    public class Vwdetail
    {
        public List<Celebrity> Celebrities { get; set; }
        public List<Order> Orders { get; set; }
        public Celebrity Celebrity { get; set; }

        public string catname { get; set; }

    }
}