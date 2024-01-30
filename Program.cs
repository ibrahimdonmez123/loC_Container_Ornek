using System;
using Ninject;

namespace IoC_Container_Ornek
{
    public interface IGorev
    {
        void GoreviYaz();
    }

    public class BirinciGorev : IGorev
    {
        public void GoreviYaz()
        {
            Console.WriteLine("Birinci görev.");
        }
    }

    public class IkinciGörev : IGorev
    {
        public void GoreviYaz()
        {
            Console.WriteLine("İkinci Mevzuat");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IGorev>().To<IkinciGörev>().InSingletonScope();

            CustomerManager customerManager = kernel.Get<CustomerManager>();
            customerManager.Add();

            Console.ReadLine();
        }
    }

    public class CustomerManager
    {
        private readonly IGorev _gorev;

        public CustomerManager(IGorev gorev)
        {
            _gorev = gorev;
        }

        public void Add()
        {
            _gorev.GoreviYaz();
            Console.WriteLine("Görev yazıldı...");
        }
    }
}
