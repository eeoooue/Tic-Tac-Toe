using System.Runtime.InteropServices;

namespace CPP_Wrapper
{
    public class CPPWrapper
    {
        // Import the DLL
        [DllImport("CPPOpponent.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int fnCPPOpponent();

        public void Test()
        {
            int output = fnCPPOpponent();

            Console.WriteLine($"the imported function returned '{output}'");
        }
    }
}