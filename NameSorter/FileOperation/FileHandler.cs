using NameSorter.DataModel;
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

        public FileHandler()
        {
            line = "";
        }

        public IList<IPerson> ReadFromFile(string filePath)
        {
            IList<IPerson> result = new List<IPerson>();
            line = "";

            StreamReader file = new StreamReader(filePath);
            while ((line = file.ReadLine()) != null)
            {
                // Get index of last white space to substring GivenNames and LastName
                var lastSpaceIndex = line.LastIndexOf(' ');
                string lastName = line.Substring(lastSpaceIndex + 1);
                string givenNames = line.Substring(0, lastSpaceIndex);

                var person = new Person(givenNames, lastName);
                result.Add(person);
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