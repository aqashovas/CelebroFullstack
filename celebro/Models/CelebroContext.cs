using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace celebro.Models
{
    public class CelebroContext:DbContext
    {
        public CelebroContext() : base("CelebroContext")
        {
        }
        public DbSet<Celebrity> Celebrities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Suggestion> Suggestions { get; set; }



    }
}