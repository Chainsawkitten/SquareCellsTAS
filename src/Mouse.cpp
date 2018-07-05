#include "Mouse.hpp"

#include <windows.h>

namespace Mouse {
    void SetPosition(const Vec2& position) {
        SetCursorPos(position.x, position.y);
    }
}
