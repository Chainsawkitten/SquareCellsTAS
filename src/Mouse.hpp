#pragma once

#include "Vec2.hpp"

/// Mouse simulation.
namespace Mouse {
    /// Mouse button.
    enum MouseButton {
        LEFT, ///< Left button.
        RIGHT ///< Right button.
    };

    /**
     * Set the position of the mouse cursor.
     * @param position The position to set.
     */
    void SetPosition(const Vec2& position);

    /**
     * Simulate mouse press.
     * @param button Which button to press.
     */
    void Press(MouseButton button);

    /**
     * Simulate mouse release.
     * @param button Which button to release.
     */
    void Release(MouseButton button);
}
