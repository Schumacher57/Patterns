using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{

    class Phone
    {
        string data;
        public Phone() => data = "";
        public string AboutPhone() => data;
        public void AppendData(string str) => data += str;

    }

    interface IDeveloper
    {
        void CreateDisplay();
        void CreateBox();
        void SystemInsatll();
        Phone GetPhone();
    }

    class AndroidDeveloper : IDeveloper
    {
        private Phone phone;
        public AndroidDeveloper() => phone = new Phone();
        public void CreateBox() => phone.AppendData("Произведён корпус Samsung; ");
        public void CreateDisplay() => phone.AppendData("Произведён дисплей Samsung; ");
        public Phone GetPhone() => phone;
        public void SystemInsatll() => phone.AppendData("Установлена система Android; ");

    }

    class IphoneDeveloper : IDeveloper
    {
        private Phone phone;
        public IphoneDeveloper() => phone = new Phone();
        public void CreateBox() => phone.AppendData("Произведён корпус Iphone; ");
        public void CreateDisplay() => phone.AppendData("Произведён дисплей Iphone; ");
        public Phone GetPhone() => phone;
        public void SystemInsatll() => phone.AppendData("Установлена система IOS; ");

    }

    class Director
    {
        private IDeveloper developer;

        public Director(IDeveloper developer) => this.developer = developer;
        public void SetDeveloper (IDeveloper developer) => this.developer = developer;
        public Phone MountOnlyPhone()
        {
            developer.CreateBox();
            developer.CreateDisplay();
            return developer.GetPhone();
        }

        public Phone MountFullPhone()
        {
            developer.CreateBox();
            developer.CreateDisplay();
            developer.SystemInsatll();
            return developer.GetPhone();
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            IDeveloper androidDeveloper = new AndroidDeveloper();
            Director director = new Director(androidDeveloper);

            Phone samsung  = director.MountFullPhone();
            IDeveloper iphoneDeveloper = new IphoneDeveloper();
            director.SetDeveloper(iphoneDeveloper);
            Phone iphone = director.MountOnlyPhone();

            Console.WriteLine(samsung.AboutPhone());
            Console.WriteLine(iphone.AboutPhone());

            Console.ReadKey();
        }
    }
}
