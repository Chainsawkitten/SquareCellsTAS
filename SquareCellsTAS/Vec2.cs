using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareCellsTAS
{
    /// <summary>
    /// 2D vector.
    /// </summary>
    class Vec2
    {
        /// <summary>
        /// X-component.
        /// </summary>
        public int x = 0;

        /// <summary>
        /// Y-component.
        /// </summary>
        public int y = 0;

        /// <summary>
        /// Create new Vec2 with both components 0.
        /// </summary>
        public Vec2()
        {

        }

        /// <summary>
        /// Create new Vec2.
        /// </summary>
        /// <param name="x">X-component.</param>
        /// <param name="y">Y-component.</param>
        public Vec2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Vector addition.
        /// </summary>
        /// <param name="a">First vector.</param>
        /// <param name="b">Second vector.</param>
        /// <returns>Sum</returns>
        public static Vec2 operator +(Vec2 a, Vec2 b)
            => new Vec2(a.x + b.x, a.y + b.y);

        /// <summary>
        /// Vector subtraction.
        /// </summary>
        /// <param name="a">First vector.</param>
        /// <param name="b">Second vector.</param>
        /// <returns>Difference</returns>
        public static Vec2 operator -(Vec2 a, Vec2 b)
            => new Vec2(a.x - b.x, a.y - b.y);

        /// <summary>
        /// Per-component multiplication.
        /// </summary>
        /// <param name="a">First vector.</param>
        /// <param name="b">Second vector.</param>
        /// <returns>Product</returns>
        public static Vec2 operator *(Vec2 a, Vec2 b)
            => new Vec2(a.x * b.x, a.y * b.y);

        /// <summary>
        /// Scalar multiplication.
        /// </summary>
        /// <param name="a">The vector.</param>
        /// <param name="b">Scalar to multiply with.</param>
        /// <returns>Product</returns>
        public static Vec2 operator *(Vec2 a, int b)
            => new Vec2(a.x * b, a.y * b);

        /// <summary>
        /// Scalar division.
        /// </summary>
        /// <param name="a">The vector.</param>
        /// <param name="b">Scalar to divide with.</param>
        /// <returns>Quotient</returns>
        public static Vec2 operator /(Vec2 a, int b)
            => new Vec2(a.x / b, a.y / b);
    }
}
