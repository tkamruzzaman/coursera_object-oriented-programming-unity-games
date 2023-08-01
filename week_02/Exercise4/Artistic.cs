using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4
{
    internal class Artistic: Kid
    {
        public Artistic(): base () { }

        public override void PrintMessage()
        {
            Console.WriteLine("this is a message from Artistic kid!");
        }
    }
}
