using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Input;
using UnityEngine;

namespace SquareCellsTAS
{
    /// <summary>
    /// The loader that gets injected into SquareCells.
    /// </summary>
    public class Loader
    {
        private static GameObject frameCounter;
        private static Thread thread;

        [DllImport("user32.dll")]
        public static extern short GetKeyState(int key);

        /// <summary>
        /// Starting point.
        /// </summary>
        public static void Init()
        {
            // Add frame counter game object to the game.
            Loader.frameCounter = new GameObject();
            Loader.frameCounter.AddComponent<FrameCounter>();
            UnityEngine.Object.DontDestroyOnLoad(Loader.frameCounter);

            // Start main thread.
            thread = new Thread(new ThreadStart(MainThread));
            thread.Start();
        }

        /// <summary>
        /// Get the current frame number since being injected.
        /// </summary>
        /// <returns>The current frame number</returns>
        public static uint GetFrame()
        {
            return Loader.frameCounter.GetComponent<FrameCounter>().frameCount;
        }

        /// <summary>
        /// The main script.
        /// </summary>
        public static void MainThread()
        {
            // Wait until the user presses R to begin.
            while (GetKeyState('R') == 0) ;

            // Start timer.
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // Play all levels.
            for (int i = 1; i <= 36; ++i)
            {
                // Play the level.
                Level level = new Level(i);
                level.Play();

                // Quit after breaking last block in last level.
                if (i == 36)
                    break;

                // Select next level.
                if (i % 6 != 0)
                {
                    Mouse.SetPosition(Configuration.NextPos);
                }
                else
                {
                    Mouse.SetPosition(Configuration.MenuPos);
                }

                Stopwatch levelEnd = new Stopwatch();
                levelEnd.Start();

                // Mash button.
                while (levelEnd.ElapsedMilliseconds < 3500)
                {
                    Mouse.Press(Mouse.MouseButton.LEFT);
                    Timing.Wait(1);
                    Mouse.Release(Mouse.MouseButton.LEFT);
                    Timing.Wait(1);
                }

                // Wait for next level to fade in.
                if (i % 6 != 0)
                {
                    Timing.WaitForLevelSwitch();
                }
                else
                {
                    Timing.WaitForLevelSelect();
                }

                // Select next row.
                if (i % 6 == 0)
                {
                    // Set mouse position.
                    Mouse.SetPosition(Configuration.FirstRowPos + Configuration.RowSize * (i / 6));

                    // Click.
                    Timing.Wait(1);
                    Mouse.Press(Mouse.MouseButton.LEFT);
                    Timing.Wait(1);
                    Mouse.Release(Mouse.MouseButton.LEFT);

                    // Wait.
                    Timing.WaitForLevelFadeIn();
                }

                // Listen to if user wants to quit.
                if (GetKeyState('Q') != 0)
                {
                    break;
                }
            }

            // End time.
            stopwatch.Stop();

            // Present time of run.
            TimeSpan time = stopwatch.Elapsed;
            FileStream fs = File.Create("test.txt");
            byte[] info = new UTF8Encoding(true).GetBytes(String.Format("{0:00}:{1:00}.{2:000}", time.Minutes, time.Seconds, time.Milliseconds));
            fs.Write(info, 0, info.Length);
            fs.Close();
        }
    }
}
