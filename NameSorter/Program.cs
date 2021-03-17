using Autofac;
using NameSorter.FileOperation;
using NameSorter.Sorter;
using System;
using System.Linq;

namespace NameSorter
{
    class Program
    {
        private static IContainer _container;
        
        // User static constructor to inject into Autofac dependency container and build container
        static Program()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<FileHandler>().As<IFileHandler>().SingleInstance();
            builder.RegisterType<NameSort>().As<ISort>().SingleInstance();
            _container = builder.Build();
        }

        static void Main(string[] args)
        {
            // Resolve for the ISort dependency to perform sorting
            var nameSorter = _container.Resolve<ISort>();
            nameSorter.Sort();
            Console.ReadLine();
        }
    }
}
