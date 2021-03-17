using NameSorter.FileOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter.Sorter
{
    public class NameSort : ISort
    {
        private IFileHandler _fileHandler;
        
        //Inject IFileHandler dependency into this constructor for handling fileIO
        public NameSort(IFileHandler fileHandler)
        {
            _fileHandler = fileHandler;
        }

        public void Sort()
        {
            var unsortedList = _fileHandler.ReadFromFile("unsorted-names-list.txt");

            // Sort by LastName, GivenNames, then print each item, then map all items to a List of strings to print to file
            var sortedList = unsortedList.OrderBy(x => x.LastName).ThenBy(x => x.GivenNames).Select(x =>
            {
                Console.WriteLine(x.GivenNames + ' ' + x.LastName);
                return (x.GivenNames + ' ' + x.LastName);
            });

            _fileHandler.WriteToFile(sortedList.ToList(), "sorted-names-list.txt");
        }
    }
}
