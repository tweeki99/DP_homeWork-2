using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DpHw_2.Builder
{
    public interface IBuilder
    {
        void BuildMainboard();

        void BuildProcessor();

        void BuildVideoCard();

        void BuildTuner();
    }

    public class DellBuilder : IBuilder
    {
        private Product _product = new Product();

        public DellBuilder()
        {
            this.Reset();
        }

        public void Reset()
        {
            this._product = new Product();
        }

        public void BuildMainboard()
        {
            this._product.Add("MainboardByDell");
        }

        public void BuildProcessor()
        {
            this._product.Add("ProcessorPlusByDell");
        }

        public void BuildVideoCard()
        {
            this._product.Add("VideoCardByDell");
        }

        public void BuildTuner()
        {
            this._product.Add("TunerByDell");
        }

        public Product GetProduct()
        {
            Product result = this._product;

            this.Reset();

            return result;
        }
    }

    public class SonyBuilder : IBuilder
    {
        private Product _product = new Product();

        public SonyBuilder()
        {
            this.Reset();
        }

        public void Reset()
        {
            this._product = new Product();
        }

        public void BuildMainboard()
        {
            this._product.Add("MainboardBySony");
        }

        public void BuildProcessor()
        {
            this._product.Add("ProcessorPlusBySony");
        }

        public void BuildVideoCard()
        {
            this._product.Add("VideoCardBySony");
        }

        public void BuildTuner()
        {
            this._product.Add("TunerBySony");
        }

        public Product GetProduct()
        {
            Product result = this._product;

            this.Reset();

            return result;
        }
    }

    public class Product
    {
        private List<object> _parts = new List<object>();

        public void Add(string part)
        {
            this._parts.Add(part);
        }

        public string ListParts()
        {
            string str = string.Empty;

            for (int i = 0; i < this._parts.Count; i++)
            {
                str += this._parts[i] + ", ";
            }

            str = str.Remove(str.Length - 2);

            return "Product parts: " + str + "\n";
        }
    }

    public class Director
    {
        private IBuilder _builder;

        public IBuilder Builder
        {
            set { _builder = value; }
        }


        public void buildBasic()
        {
            this._builder.BuildMainboard();
        }

        public void buildStandard()
        {
            this._builder.BuildMainboard();
            this._builder.BuildProcessor();
        }

        public void buildStandardPlus()
        {
            this._builder.BuildMainboard();
            this._builder.BuildProcessor();
            this._builder.BuildVideoCard();
        }

        public void buildLux()
        {
            this._builder.BuildMainboard();
            this._builder.BuildProcessor();
            this._builder.BuildVideoCard();
            this._builder.BuildTuner();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Director director = new Director();
            DellBuilder dellBuilder = new DellBuilder();
            director.Builder = dellBuilder;

            Console.WriteLine("Dell buildBasic():");
            director.buildBasic();
            Console.WriteLine(dellBuilder.GetProduct().ListParts());

            Console.WriteLine("Dell buildStandard():");
            director.buildStandard();
            Console.WriteLine(dellBuilder.GetProduct().ListParts());

            Console.WriteLine("Dell buildStandardPlus():");
            director.buildStandardPlus();
            Console.WriteLine(dellBuilder.GetProduct().ListParts());

            Console.WriteLine("Dell buildLux():");
            director.buildLux();
            Console.WriteLine(dellBuilder.GetProduct().ListParts());

            Console.Write("-------------------------------------------------------------\n\n");

            SonyBuilder SonyBuilder = new SonyBuilder();
            director.Builder = SonyBuilder;

            Console.WriteLine("Sony buildBasic():");
            director.buildBasic();
            Console.WriteLine(SonyBuilder.GetProduct().ListParts());

            Console.WriteLine("Sony buildStandard():");
            director.buildStandard();
            Console.WriteLine(SonyBuilder.GetProduct().ListParts());

            Console.WriteLine("Sony buildStandardPlus():");
            director.buildStandardPlus();
            Console.WriteLine(SonyBuilder.GetProduct().ListParts());

            Console.WriteLine("Sony buildLux():");
            director.buildLux();
            Console.WriteLine(SonyBuilder.GetProduct().ListParts());
        }
    }
}
