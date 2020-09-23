using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace celebro.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string ToWhom { get; set; }
        public string FromWhom { get; set; }
        public string Videotitle { get; set; }
        public string Videotext { get; set; }
        public string Videosrc { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public int CelebrityID { get; set; }
        public Celebrity Celebrity { get; set; }



    }
}