using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DpHw_2.Singleton
{
    class Singleton
    {
        private Singleton() { }
        private static Singleton _instance;
        public static Singleton GetInstance()
        {
            if (_instance == null)
                _instance = new Singleton();
            return _instance;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Singleton s1 = Singleton.GetInstance();
            Singleton s2 = Singleton.GetInstance();

            if(s1 == s2)
                Console.WriteLine("true");
            else
                Console.WriteLine("false");
        }
    }
}
