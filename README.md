# SquareCellsTAS
TAS bot for SquareCells. Windows only (due to usage of WinAPI to simulate mouse).

## Building
Use CMake to generate project files. If you're using a different screen resolution than 1920x1080, change the values in `src/configuration.hpp`. Then build as usual.

## Usage
Start the bot, open up Level 1 in SquareCells and press R. Make sure you run SquareCells in fullscreen mode or else the positions will be off.

## Possible timesaves
Input is limited by framerate. Tighter timings could be used if I had a computer that could run the game at a solid 120 fps. Right now I wait ~33 ms between inputs. The timings can be changed in `src/Timing.cpp`.

It is possible to click the Next and Menu buttons as they slide in. I don't use this as I couldn't get it consistent. Again, a better computer might be able to make it more consistent.
