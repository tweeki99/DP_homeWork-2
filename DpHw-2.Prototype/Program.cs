using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DpHw_2.Prototype
{
    public interface IClonable
    {
        object Clone();
    }

    public class Person : IClonable
    {
        public int Age;
        public DateTime BirthDate;
        public string Name;
        public string SecondName;

        public IdInfo IdInfo;
        public Address Address;

        public Person ShallowCopy()
        {
            return (Person)this.MemberwiseClone();
        }

        public object Clone()
        {
            Person clone = (Person)this.MemberwiseClone();
            clone.Address = new Address(Address.Name, Address.HouseNumber);
            clone.IdInfo = new IdInfo(IdInfo.IdNumber);
            clone.Name = String.Copy(Name);
            clone.SecondName = String.Copy(SecondName);
            return clone;
        }
    }

    public class Address
    {
        public string Name;
        public int HouseNumber;

        public Address(string name, int houseNumber)
        {
            this.Name = name;
            this.HouseNumber = houseNumber;
        }
    }

    public class IdInfo
    {
        public int IdNumber;

        public IdInfo(int idNumber)
        {
            this.IdNumber = idNumber;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            p1.Age = 42;
            p1.BirthDate = Convert.ToDateTime("1977-01-01");
            p1.Name = "Jack";
            p1.SecondName = "Daniels";
            p1.IdInfo = new IdInfo(666);
            p1.Address = new Address("Kings Road", 15);

            Person p2 = p1.ShallowCopy();
            Person p3 = (Person)p1.Clone();

            Console.WriteLine("Original values of p1, p2, p3:");
            Console.WriteLine("   p1 instance values: ");
            DisplayValues(p1);
            Console.WriteLine("   p2 instance values:");
            DisplayValues(p2);
            Console.WriteLine("   p3 instance values:");
            DisplayValues(p3);

            p1.Age = 32;
            p1.BirthDate = Convert.ToDateTime("1900-01-01");
            p1.Name = "Frank";
            p1.SecondName = "Simpson";
            p1.IdInfo.IdNumber = 7878;
            p1.Address = new Address("Wall street", 10);
            Console.WriteLine("\nValues of p1, p2 and p3 after changes to p1:");
            Console.WriteLine("   p1 instance values: ");
            DisplayValues(p1);
            Console.WriteLine("   p2 instance values (reference values have changed):");
            DisplayValues(p2);
            Console.WriteLine("   p3 instance values (everything was kept the same):");
            DisplayValues(p3);
        }

        public static void DisplayValues(Person p)
        {
            Console.WriteLine("      Name: {0:s}, Second Name: {3:s}, Age: {1:d}, BirthDate: {2:MM/dd/yy}",
                p.Name, p.Age, p.BirthDate, p.SecondName);
            Console.WriteLine("      ID#: {0:d}", p.IdInfo.IdNumber);
            Console.WriteLine("      Full Addres: {0:d} {1:s}", p.Address.HouseNumber, p.Address.Name);
        }
    }


}
