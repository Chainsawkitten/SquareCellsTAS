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

    cout << "w: " << width << endl;
    cout << "h: " << height << endl;

    // TODO: Load cells.
    cells = new bool[width * height];

    file.close();

    loaded = true;
}

Level::~Level() {
    if (loaded)
        delete[] cells;
}
