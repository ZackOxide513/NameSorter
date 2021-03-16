using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter.FileOperation
{
    public class FileHandler : IFileHandler
    {
        private string line;
        private int counter;

        public FileHandler()
        {
            line = "";
            counter = 0;
        }

        public IList<string> ReadFromFile(string filePath)
        {
            IList<string> result = new List<string>();
            line = "";
            counter = 0;

            StreamReader file = new StreamReader(filePath);
            while ((line = file.ReadLine()) != null)
            {
                result.Add(line);
                counter++;
            }

            file.Close();
            return result;
        }

        public void WriteToFile(IList<string> content, string filePath)
        {
            File.WriteAllLines(filePath, content);
        }
    }
}
