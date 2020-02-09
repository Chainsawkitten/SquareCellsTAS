using System.IO;

namespace SquareCellsTAS
{
    class Level
    {
        private Vec2 size = new Vec2();
        private bool[] cells;

        /// <summary>
        /// Load level.
        /// </summary>
        /// <param name="number">Which level to load.</param>
        public Level(int number) {
            string filename = "data/" + number + ".lvl";

            // Load info from the file.
            TextReader reader = File.OpenText(filename);

            // Load dimensions.
            size.x = int.Parse(reader.ReadLine());
            size.y = int.Parse(reader.ReadLine());

            // Load cells.
            cells = new bool[size.x * size.y];
            for (int y = 0; y < size.y; ++y)
            {
                for (int x = 0; x < size.x; ++x)
                {
                    int c = reader.Read();
                    cells[y * size.x + x] = (c == '1');
                }
                // Newline.
                reader.ReadLine();
            }

            reader.Close();
        }

        /// <summary>
        /// Simulate mouse input to play the level.
        /// </summary>
        public void Play()
        {
            Vec2 topLeft = (Configuration.ScreenSize / 2) - (Configuration.CellSize * size / 2);

            // Destroy blocks.
            Mouse.SetPosition(topLeft - Configuration.CellSize);
            Mouse.Press(Mouse.MouseButton.LEFT);
            for (int x = 0; x < size.x; ++x)
            {
                for (int y = 0; y < size.y; ++y)
                {
                    Vec2 pos = new Vec2(x, y);
                    bool cell = cells[pos.y * size.x + pos.x];

                    if (!cell)
                    {
                        Mouse.SetPosition(topLeft + pos * Configuration.CellSize + Configuration.CellSize / 2);
                        Timing.Wait(1);
                    }
                }
            }
            Mouse.Release(Mouse.MouseButton.LEFT);

            // Mark blocks to keep.
            Mouse.Press(Mouse.MouseButton.RIGHT);
            Timing.Wait(1);
            for (int x = 0; x < size.x; ++x)
            {
                for (int y = 0; y < size.y; ++y)
                {
                    Vec2 pos = new Vec2(x, y);
                    bool cell = cells[pos.y * size.x + pos.x];

                    if (cell)
                    {
                        Mouse.SetPosition(topLeft + pos * Configuration.CellSize + Configuration.CellSize / 2);
                        Timing.Wait(1);
                    }
                }
            }
            Mouse.Release(Mouse.MouseButton.RIGHT);
        }
    }
}
