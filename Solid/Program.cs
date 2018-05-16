using System;
using System.Collections.Generic;
using Solid.DependencyInversion;
using Solid.InterfaceSegregation;
using Solid.Liskov;
using Solid.OpenClosed;
using Solid.SingleResponsibility;

namespace Solid
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SOLID Principles:");

            var principles = new List<IPrinciple>()
            {
                new Srp(),
                new Ocp(),
                new Lsp(),
                new Isp(),
                new Dip()
            };
            principles.ForEach(type =>
            {
                Console.WriteLine($"- {type.Principle()}");
            });
            Console.Read();
        }
    }
}
