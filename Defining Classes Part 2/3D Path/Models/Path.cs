namespace DefiningClassesHomework.EuclideanSpace.Models
{
    using System;
    using System.Collections.Generic;
    using Contracts;

    /// <summary>
    /// Problem 4. Path
    /// Create a class Path to hold a sequence of points in the 3D space.
    /// </summary>
    [Serializable]
    public class Path : IPath
    {
        private readonly List<IPoint3D> pointsInPath;

        public Path()
        {
            this.pointsInPath = new List<IPoint3D>();
        }

        public Path(params IPoint3D[] list)
            : this()
        {
            foreach (var point in list)
            {
                this.AddPoint(point);
            }
        }

        public int Length => this.pointsInPath.Count;

        public IEnumerable<IPoint3D> PointsInPath => this.pointsInPath;

        public void AddPoint(IPoint3D point)
        {
            if (point == null)
            {
                throw new ArgumentException("Invalid point object");
            }

            this.pointsInPath.Add(point);
        }

        public IPoint3D RemoveLastPoint()
        {
            IPoint3D point = null;

            if (this.Length > 0)
            {
                point = this.pointsInPath[this.Length - 1];
                this.pointsInPath.RemoveAt(this.Length - 1);
            }

            return point;
        }
    }
}
