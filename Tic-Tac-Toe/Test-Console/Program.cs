using CPP_Wrapper;
using System.Runtime.InteropServices;

namespace Test_Console
{
    internal class Program
    {

        // Import the DLL
        [DllImport("CPPOpponent.dll", CallingConvention = CallingConvention.StdCall)]
        
        public static extern int fnCPPOpponent();


        static void Main(string[] args)
        {
            Console.WriteLine("This project will test my CPP-Wrapper");

            int output = fnCPPOpponent();

            Console.WriteLine($"the output said {output}");


            //CPPWrapper wrapper = new CPPWrapper();
            //wrapper.Test();
        }
    }
}