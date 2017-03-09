namespace DefiningClassesHomework.EuclideanSpace.Functionality
{
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using Models.Contracts;

    public static class PathStorage
    {
        private const string DataFilename = "PathStorage.dat";

        private static readonly BinaryFormatter Formatter = new BinaryFormatter();

        public static void SavePath(IPath current)
        {
            using (var writeFileStream = new FileStream(
                DataFilename, FileMode.Create, FileAccess.Write))
            {
                Formatter.Serialize(writeFileStream, current);
            }
        }

        public static IPath LoadPath()
        {
            if (File.Exists(DataFilename))
            {
                IPath readedPath;
                using (var readerFileStream = new FileStream(
                    DataFilename, FileMode.Open, FileAccess.Read))
                {
                    readedPath = (IPath)Formatter.Deserialize(readerFileStream);
                }

                return readedPath;
            }
            else
            {
                throw new FileNotFoundException(
                    "It's not supposed to happen but the file is missing");
            }
        }
    }
}
