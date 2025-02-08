using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_8
{
    internal class day_8
    {
        static void Main()
        {
            IPrinter printer = new BasePrinter();
            printer.Print();

            //Main top-level classes cannot be nested inside another class 
        }
    }

    interface IPrinter
        {
            void Print();
            void Scan();
            void Fax();

        }
        class BasePrinter : IPrinter
        {
            public void Print()
            {
                Console.WriteLine("Printing...");
            }
            public void Scan()
            {
                throw new NotSupportedException();
            }
            public void Fax()
            {
                throw new NotSupportedException();
            }

        }
}