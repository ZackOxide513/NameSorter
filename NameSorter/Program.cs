using Autofac;
using NameSorter.FileOperation;
using System;
using System.Linq;

namespace NameSorter
{
    class Program
    {
        private static IContainer _container;
        static Program()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<FileHandler>().As<IFileHandler>().SingleInstance();
            _container = builder.Build();
        }

        static void Main(string[] args)
        {
            var fileHandler = _container.Resolve<IFileHandler>();
            var unsortedList = fileHandler.ReadFromFile("unsorted-names-list.txt");
            var sortedList = unsortedList.OrderBy(x => x.LastName).ThenBy(x => x.GivenNames).Select(x =>
            {
                return (x.GivenNames + ' ' + x.LastName);
            });

            foreach (var item in sortedList)
            {
                Console.WriteLine($"{item}");
            }

            fileHandler.WriteToFile(sortedList.ToList(), "sorted-names-list.txt");
            Console.ReadLine();
        }
    }
}
