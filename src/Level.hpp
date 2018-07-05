#pragma once

class Level {
    public:
        /**
         * Load level.
         * @param number Which level to load.
         */
        explicit Level(int number);

        // Destructor.
        ~Level();

    private:
        bool loaded = false;

        int width;
        int height;

        bool* cells;
};
