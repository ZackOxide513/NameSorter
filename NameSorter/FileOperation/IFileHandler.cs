using System.Collections.Generic;

namespace NameSorter.FileOperation
{
    public interface IFileHandler
    {
        IList<string> ReadFromFile(string filePath);
        void WriteToFile(IList<string> content, string filePath);
    }
}