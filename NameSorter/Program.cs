using Autofac;
using NameSorter.FileOperation;
using System;

namespace NameSorter
{
    class Program
    {
        private static IContainer _container;
        static Program()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<FileHandler>().SingleInstance();
            _container = builder.Build();
        }

        static void Main(string[] args)
        {
            var fileHandler = _container.Resolve<FileHandler>();
            var result = fileHandler.ReadFromFile("namelist.txt");
            foreach (var item in result)
            {
                Console.WriteLine($"{item}");
            }

            fileHandler.WriteToFile(result, "sortednamelist.txt");
            Console.ReadLine();
        }
    }
}
