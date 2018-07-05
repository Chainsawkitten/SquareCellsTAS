#pragma once

/// 2D vector.
class Vec2 {
    public:
        /**
         * Create new 2D vector.
         * @param x X-component.
         * @param y Y-component.
         */
        Vec2(int x, int y);

        /// X-component.
        int x;

        /// Y-component.
        int y;
};
