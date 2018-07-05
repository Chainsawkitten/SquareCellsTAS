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

    this_thread::sleep_for(chrono::milliseconds(1003));

    // End time.
    auto end = chrono::high_resolution_clock::now();

    // Present time of run.
    int64_t duration = chrono::duration_cast<chrono::milliseconds>(end - begin).count();
    cout << "Time: " << duration << " ms" << endl;

    return 0;
}
