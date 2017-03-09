namespace DefiningClassesHomework.EuclideanSpace.Functionality
{
    using System;
    using Models;

    /// <summary>
    /// Problem 3. Static class
    /// Write a static class with a static method to calculate the 
    ///     distance between two points in the 3D space.
    /// </summary>
    public static class EuclideanSpaceMethods
    {
        public static double DistanceBetweenPoints(Point3D p, Point3D q)
        {
            // For 3D d(p, q) = SqRt((p1 - q1)pow2 + (p2 - q2)pow2 + (p3 - q3)pow2)
            double result = Math.Pow((p.X - q.X), 2) +
                            Math.Pow((p.Y - q.Y), 2) +
                            Math.Pow((p.Z - q.Z), 2);

            result = Math.Sqrt(result);

            return result;
        }
    }
}
