using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{

    interface IProduction
    {
        void Release ();
    }

    class Car : IProduction
    {
        public void Release() => Console.WriteLine("Выпущен легковой автомобиль! ");
    }

    class Truck : IProduction
    {
        public void Release() => Console.WriteLine("Выпущен грузовой автомобиль! ");
    }


    interface IWorkShop
    {
        IProduction Create();
    }

    class CarWorkShop : IWorkShop
    {
        public IProduction Create() => new Car();
    }

    class TruckWorkShop : IWorkShop
    {
        public IProduction Create() => new Truck();
    }





    class Program
    {
        static void Main(string[] args)
        {
            IWorkShop creator = new CarWorkShop();
            IProduction car = creator.Create();

            creator = new TruckWorkShop();
            IProduction truck = creator.Create(); 

            car.Release();
            truck.Release();

            Console.ReadKey();
             
        }
    }
}
