#pragma once

#include "Vec2.hpp"

class Level {
    public:
        /**
         * Load level.
         * @param number Which level to load.
         */
        explicit Level(int number);

        /**
         * Destructor.
         */
        ~Level();

        /**
         * Simulate mouse input to play the level.
         */
        void Play();

    private:
        bool loaded = false;

        Vec2 size;
        bool* cells;
};
