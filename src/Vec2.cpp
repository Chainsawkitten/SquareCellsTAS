#include "Vec2.hpp"

Vec2::Vec2(int x, int y) {
    this->x = x;
    this->y = y;
}

Vec2 Vec2::operator+(const Vec2& other) const {
    return Vec2(x + other.x, y + other.y);
}

Vec2 Vec2::operator-(const Vec2& other) const {
    return Vec2(x - other.x, y - other.y);
}

Vec2 Vec2::operator*(const Vec2& other) const {
    return Vec2(x * other.x, y * other.y);
}

Vec2 Vec2::operator*(int scalar) const {
    return Vec2(x * scalar, y * scalar);
}

Vec2 Vec2::operator/(int scalar) const {
    return Vec2(x / scalar, y / scalar);
}
