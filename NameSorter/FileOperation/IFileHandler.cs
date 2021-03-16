using NameSorter.DataModel;
using System.Collections.Generic;

namespace NameSorter.FileOperation
{
    public interface IFileHandler
    {
        IList<IPerson> ReadFromFile(string filePath);
        void WriteToFile(IList<string> content, string filePath);
    }
}