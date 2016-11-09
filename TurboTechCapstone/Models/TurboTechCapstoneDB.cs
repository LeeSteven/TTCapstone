namespace TurboTechCapstone.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TurboTechCapstoneDB : DbContext
    {
        public TurboTechCapstoneDB()
            : base("name=TurboTechCapstoneDB")
        {
        }
         public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Master> Master { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Recipe> Recipe { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public System.Data.Entity.DbSet<TurboTechCapstone.Models.OrderAndProducts> OrderAndProducts { get; set; }
    }
}
