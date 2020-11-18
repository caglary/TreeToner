using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeToner.Entities;

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
