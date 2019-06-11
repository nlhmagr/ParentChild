using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ParentChild
{
    public class Child
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Parent Parent { get; set; }
    }
}
