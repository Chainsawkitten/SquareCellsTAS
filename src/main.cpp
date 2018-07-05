#include "Level.hpp"
#include "Timing.hpp"

#include <chrono>
#include <iostream>
#include <thread>
#include <windows.h>

using namespace std;

int main(int argc, const char* argv[]) {
    cout << "Waiting for an R press..." << endl;

    // Wait until the user presses R to begin.
    while (!GetKeyState('R')) {
        this_thread::yield();
    }

    // Start time.
    auto begin = chrono::high_resolution_clock::now();

    // Play all levels.
    for (int i = 1; i <= 36; ++i) {
        // Play the level.
        Level level(i);
        level.Play();

        // Wait for menu.
        Timing::WaitForLevelClear();

        // TODO: Select next level.

        // Listen to if user wants to quit.
        if (GetKeyState('Q')) {
            cout << "User quit manually." << endl;
            break;
        }
    }

    // End time.
    auto end = chrono::high_resolution_clock::now();

    // Present time of run.
    int64_t duration = chrono::duration_cast<chrono::milliseconds>(end - begin).count();
    cout << "Time: " << duration << " ms" << endl;

    return 0;
}
