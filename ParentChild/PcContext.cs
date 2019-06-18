namespace ParentChild
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PcContext : DbContext
    {
        public PcContext()
            : base("name=PcContext")
        {
        }

        public virtual DbSet<Parent> Parents { get; set; }
        public virtual DbSet<Child> Children { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<Planning> PlanningOrders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Material>()
                .HasKey(m => m.MaterialNumber)
                .ToTable("Materials");

            modelBuilder.Entity<Planning>()
                .HasKey(p => p.PStep)
                .ToTable("Planning");

            base.OnModelCreating(modelBuilder);
        }
    }
}