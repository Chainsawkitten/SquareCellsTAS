#pragma once

namespace Timing {
    /**
     * Wait for a certain number of frames.
     * @param frames The number of frames to wait.
     */
    void Wait(int frames);

    /**
     * Wait for level switch.
     */
    void WaitForLevelSwitch();

    /**
     * Wait for level to fade in from level select.
     */
    void WaitForLevelFadeIn();
}
