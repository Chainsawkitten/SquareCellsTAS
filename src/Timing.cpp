#include "Timing.hpp"

#include <chrono>
#include <thread>

using namespace std;

namespace Timing {
    void Wait(int frames) {
        this_thread::sleep_for(chrono::microseconds(16667 * frames));
    }

    void WaitForLevelSwitch() {
        this_thread::sleep_for(chrono::milliseconds(2000));
    }
}
