using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ParentChild
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new PcContext();
            context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

            Console.WriteLine("\nFrom Many to One\n");

            #region From Many -> One
            var families1 = context.Children
                .Where(c => c.Age < 8)
                .Select(c => new
                {
                    ParentName = c.Parent,
                    Child = c
                });

            foreach (var family in families1)
            {
                Console.WriteLine(family.ParentName + "--> " + family.Child.Name + " = {0} years", family.Child.Age);
            }
            #endregion From Many -> One

            #region From One -> Many

            Console.WriteLine("\nFrom One to Many (SELECT)\n");


            var families2 = context.Parents
                .Select(p => new
                {
                    Name = p.Name,
                    Children = p.Children.Where(c => c.Age < 8)
                });

            foreach (var parent in families2)
            {
                foreach (var child in parent.Children)
                {
                    Console.WriteLine("{0} --> {1} ({2})", parent.Name, child.Name, child.Age);
                }
            }

            Console.WriteLine("\nFrom One to Many (SELECTMANY)\n");

            var children = context.Parents
                .SelectMany(p => p.Children.Where(c => c.Age < 8));

            foreach (var c in children)
            {
                    Console.WriteLine("{0}: {1} --> {2}", c.Parent.Name, c.Name, c.Age);
            }

            #endregion From One -> Many

            #region Materials

            var materials = context.Materials
                .Where(m => m.MaterialName.Contains("nd50"))
                .Select(m => m);

            foreach (var material in materials)
            {
                Console.WriteLine("{0}: {1}", material.MaterialNumber, material.MaterialName);
            }

            #endregion Materials

            #region MyRegion

            var workCenters = context.PlanningOrders
                .Where(p => p.Workcenter.StartsWith("RA-"))
                .GroupBy(p => p.Workcenter)
                .OrderByDescending(g => g.Key);
            

            foreach (var workCenter in workCenters)
            {
                Console.WriteLine(workCenter.Key);
                foreach (var order in workCenter
                    .Where(p => p.PlannedStart > DateTime.Now.AddDays(-3))
                    .OrderByDescending(p => p.PlannedStart))
                {
                    Console.WriteLine("\t{0}: {1}", order.PlannedStart, order.PStep);
                }
            }
            #endregion

            Console.ReadLine();
        }
    }
}
