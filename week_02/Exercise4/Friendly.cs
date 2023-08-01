using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4
{
    internal class Friendly : Kid
    {
        public Friendly(): base() { }

        public override void PrintMessage()
        {
            Console.WriteLine("this is a message from friendly kid!");
        }
    }
}
