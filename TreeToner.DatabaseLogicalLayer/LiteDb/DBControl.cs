using System.IO;

namespace TreeToner.DatabaseLogicalLayer.LiteDb
{
    public class DBControl
    {
        private string path;
        public string DatabaseConnectionString
        {
            get
            {
                return path;
            }
        }
        public DBControl()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            path = $"{currentDirectory}\\Treetoner.db";
          
        }

    }
}
