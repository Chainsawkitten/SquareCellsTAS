using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SquareCellsTAS
{
    /// <summary>
    /// Mouse simulation.
    /// </summary>
    class Mouse
    {
        /// <summary>
        /// Mouse button.
        /// </summary>
        public enum MouseButton
        {
            LEFT,
            RIGHT
        }

        /// <summary>
        /// Set the position of the mouse cursor.
        /// </summary>
        /// <param name="position">The position to set.</param>
        public static void SetPosition(Vec2 position)
        {
            SetCursorPos(position.x, position.y);
        }

        /// <summary>
        /// Simulate mouse press.
        /// </summary>
        /// <param name="button">Which button to press.</param>
        public static void Press(MouseButton button)
        {
            switch (button)
            {
                case MouseButton.LEFT:
                    MouseInput(2);
                    break;
                case MouseButton.RIGHT:
                    MouseInput(8);
                    break;
            }
        }

        /// <summary>
        /// Simulate mouse release.
        /// </summary>
        /// <param name="button">Which button to release.</param>
        public static void Release(MouseButton button)
        {
            switch (button)
            {
                case MouseButton.LEFT:
                    MouseInput(4);
                    break;
                case MouseButton.RIGHT:
                    MouseInput(16);
                    break;
            }
        }

        private static void MouseInput(uint flags)
        {
            INPUT input = new INPUT
            {
                Type = 0
            };
            input.Data.Mouse = new MOUSEINPUT();
            input.Data.Mouse.X = 0;
            input.Data.Mouse.Y = 0;
            input.Data.Mouse.MouseData = 0;
            input.Data.Mouse.Flags = flags;
            input.Data.Mouse.Time = 0;
            input.Data.Mouse.ExtraInfo = IntPtr.Zero;
            INPUT[] inputs = new INPUT[] { input };
            SendInput(1, inputs, Marshal.SizeOf(typeof(INPUT)));
        }

        // Win32 API call stuff.

        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        public static extern uint SendInput(uint cInputs, INPUT[] pInputs, int cbSize);

        /// <summary>
        /// http://msdn.microsoft.com/en-us/library/windows/desktop/ms646270(v=vs.85).aspx
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct INPUT
        {
            public uint Type;
            public MOUSEKEYBDHARDWAREINPUT Data;
        }

        /// <summary>
        /// http://social.msdn.microsoft.com/Forums/en/csharplanguage/thread/f0e82d6e-4999-4d22-b3d3-32b25f61fb2a
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        internal struct MOUSEKEYBDHARDWAREINPUT
        {
            // Should also have Hardware and Keyboard (union) but we don't care about those.
            [FieldOffset(0)]
            public MOUSEINPUT Mouse;
        }

        /// <summary>
        /// http://social.msdn.microsoft.com/forums/en-US/netfxbcl/thread/2abc6be8-c593-4686-93d2-89785232dacd
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct MOUSEINPUT
        {
            public int X;
            public int Y;
            public uint MouseData;
            public uint Flags;
            public uint Time;
            public IntPtr ExtraInfo;
        }
    }
}
