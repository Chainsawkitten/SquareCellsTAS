#pragma once

class Level {
    public:
        /**
         * Load level.
         * @param number Which level to load.
         */
        Level(int number);

    private:
        bool loaded = false;
};
