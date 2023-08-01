using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4
{
    internal class Kid
    {
        public Kid() { }


        public virtual void PrintMessage()
        {
            Console.WriteLine("this is a message from kid class!");
        }
    }
}
