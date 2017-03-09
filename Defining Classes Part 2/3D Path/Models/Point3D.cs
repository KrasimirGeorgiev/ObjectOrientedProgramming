namespace DefiningClassesHomework.EuclideanSpace.Models
{
    using System;
    using Models.Contracts;

    /// <summary>
    /// Problem 1. Structure
    /// Create a structure Point3D to hold a 3D-coordinate {X, Y, Z} 
    ///     in the Euclidean 3D space.
    /// </summary>
    [Serializable]
    public struct Point3D : IPoint3D
    {
        /// <summary>
        /// Problem 2. Static read-only field
        /// Add a private static read-only field to hold the start of
        ///     the coordinate system – the point O{0, 0, 0}.
        /// </summary>
        private static readonly Point3D CenterOfCoordinateSystem;

        static Point3D()
        {
            CenterOfCoordinateSystem = new Point3D(0, 0, 0);
        }

        public Point3D(double x, double y, double z)
            : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        /// <summary>
        /// Problem 2. Static read-only field
        /// Add a static property to return the point O.
        /// </summary>
        public static Point3D O => CenterOfCoordinateSystem;

        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        /// <summary>
        /// Problem 1. Structure
        /// Implement the ToString() to enable printing a 3D point.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string result = $"X({this.X}), Y({this.Y}), Z({this.Z})";
            return result;
        }

        private static bool CoordinatesArgumentsValidation(double current)
        {
            throw new NotImplementedException("Not Implemented Yet");
        }
    }
}
