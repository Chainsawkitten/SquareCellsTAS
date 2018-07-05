#include "Level.hpp"

#include "FileSystem.hpp"

#include <iostream>
#include <string>

using namespace std;

Level::Level(int number) {
    string filename = "data/" + to_string(number) + ".lvl";

    if (!FileSystem::FileExists(filename.c_str())) {
        cout << "Couldn't find " << filename << endl;
        return;
    }

    // TODO: Load info from the file.

    loaded = true;
}
