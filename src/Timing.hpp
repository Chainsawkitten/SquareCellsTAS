#pragma once

namespace Timing {
    /**
     * Wait for a certain number of frames.
     * @param frames The number of frames to wait.
     */
    void Wait(int frames);

    /**
     * Wait for level to fade and menu to come in.
     */
    void WaitForLevelClear();
}
