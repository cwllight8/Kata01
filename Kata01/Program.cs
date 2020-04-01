using System;

namespace Kata01
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "/+1-541-754-3010 156 Alphand_St. <J Steeve>\n 133, Green, Rd. <E Kustur> NY-56423 ;+1-541-914-3010!\n";
            Algorithim a = new Algorithim();
            
            string st = a.phone(s, "1-541-754-3010");
            Console.WriteLine(st);
        }
    }
}
