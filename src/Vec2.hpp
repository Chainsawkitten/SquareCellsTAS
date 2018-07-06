#pragma once

/// 2D vector.
class Vec2 {
    public:
        /**
         * Create new 2D vector.
         * @param x X-component.
         * @param y Y-component.
         */
        Vec2(int x = 0, int y = 0);

        /**
         * Vector addition.
         * @param other Vector to add.
         * @return Sum.
         */
        Vec2 operator+(const Vec2& other) const;

        /**
         * Vector subtraction.
         * @param other Vector to subtract.
         * @return Difference.
         */
        Vec2 operator-(const Vec2& other) const;

        /**
         * Per-component multiplication.
         * @param other Vector to multiply with.
         * @return Product.
         */
        Vec2 operator*(const Vec2& other) const;

        /**
         * Scalar multiplication.
         * @param other Scalar to multiply with.
         * @return Product.
         */
        Vec2 operator*(int scalar) const;

        /**
         * Scalar division.
         * @param scalar Scalar to divide with.
         * @return Quotient.
         */
        Vec2 operator/(int scalar) const;

        /// X-component.
        int x;

        /// Y-component.
        int y;
};
