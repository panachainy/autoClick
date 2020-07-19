using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using WindowsInput;
using WindowsInput.Native;

namespace autoClick
{
    class Program
    {
        // [DllImport("User32.Dll", EntryPoint = "PostMessageA")]
        // private static extern bool PostMessage(IntPtr hWnd, uint msg, int wParam, int lParam);

        // const int VK_RETURN = 0x0D;
        // const int WM_KEYDOWN = 0x100;
        public static event EventHandler s_KeyEventHandler;





        static void Main(string[] args)
        {
            Console.WriteLine("=== Start ===");


            do
            {
                while (!Console.KeyAvailable)
                {
                    ConsoleKeyInfo info = Console.ReadKey();
                    if (info.KeyChar == '1')
                    {
                        PressKey(VirtualKeyCode.NUMPAD1);

                    }

                    // info = Console.ReadKey();
                    // if (info.Key == ConsoleKey.X &&
                    // info.Modifiers == ConsoleModifiers.Control)
                    // {
                    //     Console.WriteLine("You pressed control X");
                    // }
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        private static void PressKey(VirtualKeyCode key)
        {
            var delay = GetDeley(1000);



            var inputSimulator = new InputSimulator();
            while (Console.ReadKey(true).Key != ConsoleKey.Escape)
            {
                inputSimulator.Keyboard.KeyPress(key);
                Console.WriteLine("You pressed: " + key.ToString());
                delay.Wait();
            }
            Console.WriteLine("Exit");
        }

        private static Task GetDeley(int delayTime)
        {
            return Task.Run(async delegate
              {
                  await Task.Delay(delayTime);
                  return 42;
              });
        }
    }
}
