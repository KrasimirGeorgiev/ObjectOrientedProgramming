/* Problem 1. Structure (Done)*/
/* Create a structure Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian 3D space.
 * Implement the ToString() to enable printing a 3D point. */

/* Problem 2. Static read-only field (Done)*/
/* Add a private static read-only field to hold the start of the coordinate system – the point O{0, 0, 0}.
 * Add a static property to return the point O. */

/* Problem 3. Static class (Done) */
/* Write a static class with a static method to calculate the distance between two points in the 3D space. */

/* Problem 4. Path (Done) */
/* Create a class Path to hold a sequence of points in the 3D space.
 * Create a static class PathStorage with static methods to save and load paths from a text file.
 * Use a file format of your choice. */

namespace DefiningClassesHomework.EuclideanSpace
{
    using System;
    using ConsoleMio.ConsoleEnhancements;
    using Functionality;
    using Models;

    public class StartUp
    {
        private const ConsoleColor Info = ConsoleColor.DarkRed;
        private const ConsoleColor Result = ConsoleColor.DarkBlue;

        private static readonly ConsoleMio ConsoleMio = new ConsoleMio();

        private static void Main()
        {
            ConsoleMio.PrintHeading("Homework: Defining Classes Part 2 - Euclidean Space");

            var startPoint = new Point3D(12, 2, 1);
            ConsoleMio
                .Write("Creating a start point: ", color: Info)
                .WriteLine(startPoint, color: Result)
                .WriteLine();

            var destinationPoint = new Point3D(3003232, 512312374, 1);
            ConsoleMio
                .Write("Creating a destination point: ", color: Info)
                .WriteLine(destinationPoint, color: Result)
                .WriteLine();

            var distance = EuclideanSpaceMethods.DistanceBetweenPoints(startPoint, destinationPoint);
            ConsoleMio
                .Write("Distance between points: ", color: Info)
                .WriteLine(distance, color: Result)
                .WriteLine();


            var sampleRout = new Path(startPoint, destinationPoint);
            PathStorage.SavePath(sampleRout);
            var loadedRout = PathStorage.LoadPath();
            ConsoleMio
                .WriteLine("Creating a sample route", color: Info)
                .WriteLine("Saving route to disk...", color: Info)
                .WriteLine("Loading the route from disk...", color: Info)
                .WriteLine("Printing the points in the stored route: ", Info)
                .WriteLine();

            foreach (var point in loadedRout.PointsInPath)
            {
                ConsoleMio.FormatLine("\t{0}", color: Result, args: point);
            }

            ConsoleMio.WriteLine();
        }
    }
}
