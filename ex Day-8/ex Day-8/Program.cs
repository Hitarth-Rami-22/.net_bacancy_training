// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day_8;

namespace Day_8
{
    internal class day_8
    {
        static void Main()
        {
            //create a instence of baseprinter & call in print method
            IPrinter printer = new BasePrinter();
            printer.Print();
            //create instence of advanceprinter & call scan, fax
            AdvancePrinter advancePrinter = new AdvancePrinter();
            advancePrinter.Scan();
            advancePrinter.Fax();
        }


    }
    //here al define interface Iprint, Iscan, Ifax with itself methods
    interface IPrinter
    {
        void Print();
        }
        interface IScanner
    {
        void Scan();
        }
    interface IFax
    {
        void Fax();
    }


    }
//implimenting Iprint interface in bace class 
class BasePrinter : IPrinter
{
    public void Print()
    {
        Console.WriteLine("Printing...");
    }
}

//implimenting iscnner & ifax interface in advanceprinter
class AdvancePrinter : IScanner, IFax
{  
public void Scan()
        {
            Console.WriteLine("Scanning....");
        }
        public void Fax()
        {
            Console.WriteLine("Faxing...");
        }

}
