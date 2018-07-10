using System;

namespace Assets.Scripts.Utils
{
    /// <summary>
    ///     二维坐标点
    /// </summary>
    public class Point
    {
        public static Point Zero = new Point(0, 0);

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Point Of(int x, int y)
        {
            return new Point(x, y);
        }

        public int X { get; set; }
        public int Y { get; set; }

        public double Distance(Point that)
        {
            return Distance(that.X, that.Y);
        }

        public double Distance(int x2, int y2)
        {
            return Distance(X, Y, x2, y2);
        }

        /**
         * This equals method is important for A* Algorithm. {@link AStarAlgorithm#find(Node, Node, int[][], boolean)}
         * <p>
         * {@link Point} are equal if the values of their x and y.
         *
         * @param obj object
         * @return Return true if the obj is equal this. otherwise false.
         */
        public override bool Equals(object obj)
        {
            var point = obj as Point;
            if (point != null)
                return point.X == X && point.Y == Y;
            return false;
        }

        public override int GetHashCode()
        {
            //        return ((x & 0xFFFF ) << 16) | (y & 0xFFFF); // mine implement
            var bits = BitConverter.DoubleToInt64Bits(X);
            bits ^= BitConverter.DoubleToInt64Bits(Y) * 31;
            return (int)bits ^ (int)(bits >> 32);
        }

        public override string ToString()
        {
            return GetType().Name + " - [" + X + ", " + Y + "]";
        }

        // Static Method

        public static double Distance(double x1, double y1, double x2, double y2)
        {
            x2 -= x1;
            y2 -= y1;
            return Math.Sqrt(x2 * x2 + y2 * y2);
        }

        public static Point operator +(Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }

        public static Point operator -(Point p1, Point p2)
        {
            return new Point(p1.X - p2.X, p1.Y - p2.Y);
        }
    }
}