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
    }
}