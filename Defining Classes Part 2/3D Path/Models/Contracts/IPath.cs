namespace DefiningClassesHomework.EuclideanSpace.Models.Contracts
{
    using System.Collections.Generic;

    public interface IPath
    {
        IEnumerable<IPoint3D> PointsInPath { get; }

        void AddPoint(IPoint3D point);

        IPoint3D RemoveLastPoint();
    }
}