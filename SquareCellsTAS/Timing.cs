using System.Threading;

namespace SquareCellsTAS
{
    class Timing
    {
        /// <summary>
        /// Wait for a certain number of frames.
        /// </summary>
        /// <param name="frames">The number of frames to wait.</param>
        public static void Wait(int frames)
        {
            uint startFrame = Loader.GetFrame();

            while (Loader.GetFrame() - startFrame < frames)
            {
                // Busy wait.
            }
        }

        /// <summary>
        /// Wait for level switch.
        /// </summary>
        public static void WaitForLevelSwitch()
        {
            Thread.Sleep(150);
            Wait(1);
        }

        /// <summary>
        /// Wait for level select screen.
        /// </summary>
        public static void WaitForLevelSelect()
        {
            Thread.Sleep(900);
        }

        /// <summary>
        /// Wait for level to fade in from level select.
        /// </summary>
        public static void WaitForLevelFadeIn()
        {
            Thread.Sleep(1500);
            Wait(1);
        }
    }
}
