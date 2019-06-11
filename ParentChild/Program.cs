using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParentChild
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new PcContext();

            var parents = context.Parents
                .Select(p => p)
                .Include(p => p.Children)
                .Where(p => p.Children.Any(c => c.Age < 4))
                .ToList();

            foreach (var parent in parents)
            {
                Console.WriteLine(parent.Name, parent.Children.ToString());
            }

        }
    }
}
