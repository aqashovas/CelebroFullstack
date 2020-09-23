using celebro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace celebro.Viewmodels
{
    public class Vwcelebrities
    {
        public List<Celebrity> Celebrities { get; set; }
        public List<Category> Categories { get; set; }
        public Celebrity Celebrity { get; set; }


    }
}