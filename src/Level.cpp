#include "Level.hpp"

#include "configuration.hpp"
#include "FileSystem.hpp"
#include "Mouse.hpp"

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
    cout << "x: " << topLeft.x << endl;
    cout << "y: " << topLeft.y << endl;
    Mouse::SetPosition(topLeft);

    // TODO: Play level.
}
