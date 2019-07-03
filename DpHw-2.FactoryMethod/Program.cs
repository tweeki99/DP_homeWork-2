using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DpHw_2.FactoryMethod
{
    abstract class Creator
    {
        public abstract IProduct FactoryMethod();

        public string SomeOperation()
        {
            IProduct product = FactoryMethod();

            string result = "Creator: The same creator's code has just worked with " + product.Print();

            return result;
        }
    }

    class CanonCreator : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new Canon();
        }
    }

    class OffsetCreator : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new Offset();
        }
    }

    public interface IProduct
    {
        string Print();
    }

    class Canon : IProduct
    {
        public string Print()
        {
            return "{Perl}";
        }
    }

    class Offset : IProduct
    {
        public string Print()
        {
            return "{Offset}";
        }
    }

    class Client
    {
        public void Main()
        {
            Console.WriteLine("App: Launched with the CanonCreator.");
            ClientCode(new CanonCreator());

            Console.WriteLine("");

            Console.WriteLine("App: Launched with the OffsetCreator.");
            ClientCode(new OffsetCreator());
        }

        public void ClientCode(Creator creator)
        {
            Console.WriteLine("Client: I'm not aware of the creator's class," +
                "but it still works.\n" + creator.SomeOperation());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Client().Main();
        }
    }
}
