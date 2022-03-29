using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gyldendal_Split_URL.Models;
//using DbContext = System.Data.Entity.DbContext;

namespace Gyldendal_Split_URL
{

    public class Gyldendal_Split_URLDBContext : DbContext
    {
        public Gyldendal_Split_URLDBContext()
        {
        }
        public Gyldendal_Split_URLDBContext(DbContextOptions<Gyldendal_Split_URLDBContext> options) : base(options)
        {
        }
        public DbSet<Produktvej> Clickstream_LookUp_Produktvej { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
               //"Server = (localdb)\\MSSQLSERVER01;Database=SchoolDB;Trusted_Connection=True;");
            "Data Source = LAPTOP-3EFU92FT\\MSSQLSERVER01; Initial Catalog = Datahub;Trusted_Connection=True;TrustServerCertificate=True;"); 
        }
    }
}

