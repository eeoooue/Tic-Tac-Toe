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
            CPPWrapper wrapper = new CPPWrapper();
            wrapper.Test();
        }
    }
}