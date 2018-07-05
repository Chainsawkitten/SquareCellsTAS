#include "Level.hpp"

#include "FileSystem.hpp"

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
    file >> width;
    file >> height;

    // Load cells.
    cells = new bool[width * height];
    char c;
    for (int i = 0; i < width * height; ++i) {
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

    // TODO: Play level.
}
