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
        static Program()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<FileHandler>().As<IFileHandler>().SingleInstance();
            builder.RegisterType<NameSort>().As<ISort>().SingleInstance();
            _container = builder.Build();
        }

        static void Main(string[] args)
        {
            var nameSorter = _container.Resolve<ISort>();
            nameSorter.Sort();
            Console.ReadLine();
        }
    }
}
