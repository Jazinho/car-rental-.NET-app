using CarWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CarWebApp.DAL
{
    public class CarContext : DbContext
    {
        public CarContext()
            : base("CarContext")
        {
            WebApiConfig.Logger.info("enter CarContext constructor");

            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            WebApiConfig.Logger.info("return from CarContext constructor");

        }

        public DbSet<Car> Cars { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            WebApiConfig.Logger.info("enter CarContext->OnModelCreating");

            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
            WebApiConfig.Logger.info("return from CarContext->OnModelCreating");

        }
    }
}