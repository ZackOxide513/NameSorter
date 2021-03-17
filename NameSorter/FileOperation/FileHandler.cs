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
        private string _line;

        public FileHandler()
        {
            _line = "";
        }

        public IList<IPerson> ReadFromFile(string filePath)
        {
            IList<IPerson> result = new List<IPerson>();
            _line = "";

            try
            {
                StreamReader file = new StreamReader(filePath);
                while ((_line = file.ReadLine()) != null)
                {
                    // Get index of last white space to substring GivenNames and LastName
                    var lastSpaceIndex = _line.LastIndexOf(' ');
                    string lastName = _line.Substring(lastSpaceIndex + 1);
                    string givenNames = _line.Substring(0, lastSpaceIndex);

                    var person = new Person(givenNames, lastName);
                    result.Add(person);
                }
                file.Close();
            }
            catch(FileNotFoundException fileNotFound)
            {
                Console.WriteLine("Unable to find unsorted-names-list.txt. Please ensure the file is put in the location below");
                Console.WriteLine($"{fileNotFound.Message}");
            }

            return result;
        }

        public void WriteToFile(IList<string> content, string filePath)
        {
            File.WriteAllLines(filePath, content);
        }
    }
}