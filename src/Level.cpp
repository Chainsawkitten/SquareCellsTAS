#include "Level.hpp"

#include "configuration.hpp"
#include "FileSystem.hpp"
#include "Mouse.hpp"
#include "Timing.hpp"

#include <iostream>
#include <fstream>
#include <string>

using namespace std;

Level::Level(int number) {
    string filename = "data/" + to_string(number) + ".lvl";

    if (!FileSystem::FileExists(filename.c_str())) {
        cout << "Couldn't find " << filename << endl;
        return;
    }

    // Load info from the file.
    ifstream file;
    file.open(filename);

    // Load dimensions.
    file >> size.x;
    file >> size.y;

    // Load cells.
    cells = new bool[size.x * size.y];
    char c;
    for (int i = 0; i < size.x * size.y; ++i) {
        file >> c;
        cells[i] = (c == '1');
    }

    file.close();

    loaded = true;
}

Level::~Level() {
    if (loaded)
        delete[] cells;
}

void Level::Play() {
    if (!loaded)
        return;

    Vec2 topLeft = (SCREEN_SIZE / 2) - (CELL_SIZE * size / 2);

    // Play level.
    for (int x = 0; x < size.x; ++x) {
        for (int y = 0; y < size.y; ++y) {
            Vec2 pos(x, y);
            Mouse::MouseButton button = (cells[y * size.x + x] ? Mouse::RIGHT : Mouse::LEFT);

            Mouse::SetPosition(topLeft + pos * CELL_SIZE + CELL_SIZE / 2);
            Mouse::Press(button);

            Timing::Wait(1);

            Mouse::Release(button);

            Timing::Wait(1);
        }
    }
}
