using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{

    interface IProcessor
    {
        void Process();
    }

    class Transmitter : IProcessor
    {
        private string data;
        public Transmitter(string data) => this.data = data;
        public void Process() => Console.WriteLine($"Данные {data} переданы по каналу свзяи");
    }

    abstract class Shell : IProcessor
    {
        protected IProcessor processor;
        public Shell (IProcessor pr) => processor = pr;
        public virtual void Process () => processor.Process();
    }

    class HammingCoder : Shell
    {
        public HammingCoder(IProcessor pr) : base(pr) { }
        public override void Process()
        {
            Console.Write("Наложен помехоустойчивый код Хамминга->");
            //processor.Process();
            base.Process();
        }
    }

    class Encryptor : Shell
    {
        public Encryptor(IProcessor pr):base(pr) { }
        public override void Process()
        {
            Console.Write("Шифрование данных->");
            //processor.Process();
            //base.Process();
        }
    }


    


    class Program
    {
        static void Main(string[] args)
        {
            IProcessor transmitter = new Transmitter("12345");
            transmitter.Process();
            Console.WriteLine();

            Shell hamingCoder = new HammingCoder(transmitter);
            hamingCoder.Process();
            Console.WriteLine();

            Shell encoder = new Encryptor(hamingCoder);
            encoder.Process();


            Console.ReadKey();
        }
    }
}
