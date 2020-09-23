using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace celebro.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Celebrity> Celebrities { get; set; }

    }
}