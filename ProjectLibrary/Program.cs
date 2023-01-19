using BuisnessLogicLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BuisnessController bc = new BuisnessController();
            string text = File.ReadAllText(@"Test.txt");

            bc.ReadBooks(text);
            bc.FindBooks("*20*&*Jensen*");
        }
    }
}
