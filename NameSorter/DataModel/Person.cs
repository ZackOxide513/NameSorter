using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter.DataModel
{
    public class Person : IPerson
    {
        public string GivenNames { get; }
        public string LastName { get; }
        public Person(string givenNames, string lastName)
        {
            GivenNames = givenNames;
            LastName = lastName;
        }
    }
}
