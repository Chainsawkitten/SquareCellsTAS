# SquareCellsTAS
TAS bot for SquareCells. Windows only.

## Building
Open in Visual Studio. Add a reference to the UnityEngine.dll shipped with the game. If you're using a different screen resolution than 1920x1080, change the values in `SquareCellsTAS/Configuration.cs`. Then build as usual.

## Usage
1. Copy the data folder to the SquareCells directory.
1. Start SquareCells.
1. Inject the SquareCellsTAS DLL into SquareCells using [SharpMonoInjector](https://github.com/warbler/SharpMonoInjector) or other injector of your choice. The class name is 'Loader' and the method name is 'Init'.
1. Open up Level 1 and press R. Make sure you run SquareCells in fullscreen mode or else the positions will be off.

## Possible timesaves
Input is limited by framerate. Running the game at 120 fps would allow me to do inputs twice as fast but I don't have a monitor that supports that.

It is possible to click the Next and Menu buttons as they slide in. This is in the works.
