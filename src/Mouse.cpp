#include "Mouse.hpp"

#include <windows.h>

namespace Mouse {
    void SetPosition(const Vec2& position) {
        SetCursorPos(position.x, position.y);
    }

    void MouseInput(DWORD flags) {
        INPUT input;
        input.type = INPUT_MOUSE;
        input.mi.dx = 0;
        input.mi.dy = 0;
        input.mi.mouseData = 0;
        input.mi.dwFlags = flags;
        input.mi.time = 0;
        input.mi.dwExtraInfo = 0;

        SendInput(1, &input, sizeof(INPUT));
    }

    void Press(MouseButton button) {
        switch (button) {
        case LEFT:
            MouseInput(MOUSEEVENTF_LEFTDOWN);
            break;
        case RIGHT:
            MouseInput(MOUSEEVENTF_RIGHTDOWN);
            break;
        }
    }

    void Release(MouseButton button) {
        switch (button) {
        case LEFT:
            MouseInput(MOUSEEVENTF_LEFTUP);
            break;
        case RIGHT:
            MouseInput(MOUSEEVENTF_RIGHTUP);
            break;
        }
    }
}
