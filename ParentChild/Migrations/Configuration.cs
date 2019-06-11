using System.Collections.Generic;

namespace ParentChild.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ParentChild.PcContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ParentChild.PcContext context)
        {
            context.Parents.AddOrUpdate(p => p.Name,
                new Parent()
                {
                    Name = "John",
                    Children = new List<Child>()
                    {
                        new Child() {Name = "John's 1st child", Age = 12},
                        new Child() {Name = "John's 2nd child", Age = 8},
                        new Child() {Name = "John's 3rd child", Age = 3}
                    }
                });

            context.Parents.AddOrUpdate(p => p.Name,
                new Parent()
                {
                    Name = "Jim",
                    Children = new List<Child>()
                    {
                        new Child() {Name = "Jim's 1st child", Age = 9},
                        new Child() {Name = "Jim's 2nd child", Age = 6}
                    }
                });

            context.Parents.AddOrUpdate(p => p.Name,
                new Parent()
                {
                    Name = "Tim",
                    Children = new List<Child>()
                    {
                        new Child() {Name = "Tim's 1st child", Age = 17},
                        new Child() {Name = "Tim's 2nd child", Age = 13},
                        new Child() {Name = "Tim's 3rd child", Age = 9}
                    }
                });
        }
    }
}
