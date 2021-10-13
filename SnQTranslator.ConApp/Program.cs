//@CodeCopy
using System;

namespace SnQTranslator.ConApp
{
	partial class Program
    {
        static void Main(/*string[] args*/)
        {
            Console.WriteLine("SnQTranslator");
            Console.WriteLine(DateTime.Now);

            BeforeRun();

            AfterRun();
            Console.WriteLine(DateTime.Now);
        }

        static partial void BeforeRun();
        static partial void AfterRun();
    }
}
