using System;

namespace Solid
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SOLID Principles");

            var s = new Srp().Principle();
            var o = new Ocp().Principle();
            var l = new Lsp().Principle();
            var i = new Isp().Principle();
            var d = new Dip().Principle();

            Console.WriteLine(s, o, l, i, d);
        }
    }
}
