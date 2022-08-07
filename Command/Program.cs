using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{

    interface ICommand
    {
        void Positive();
        void Negative();
    }


    class Conveyor
    {
        public void On() => Console.WriteLine("Конвееер запущен");
        public void Off() => Console.WriteLine("Выключение конвеера");
        public void SpeedIncrease() => Console.WriteLine("Увеличение скорости конвеера");
        public void SpeedDecrease() => Console.WriteLine("Уменьшение скорости конвеера");
    }

    class ConveyorWorkCommand : ICommand
    {
        private Conveyor conveyor;
        public ConveyorWorkCommand(Conveyor conveyor) => this.conveyor = conveyor;
        public void Positive() => conveyor.On();
        public void Negative() => conveyor.Off();
    }

    class ConveyorAdjustCommand : ICommand
    {
        private Conveyor conveyor;
        public ConveyorAdjustCommand(Conveyor conveyor) => this.conveyor = conveyor;
        public void Positive() => conveyor.SpeedIncrease();
        public void Negative() => conveyor.SpeedDecrease();

    }


    class Multipult
    {
        private List<ICommand> commands;
        private Stack<ICommand> history;

        public Multipult()
        {
            commands = new List<ICommand>() { null, null };
            history = new Stack<ICommand>(); 
        }

        public void SetCommand(int button, ICommand command) => commands[button] = command;
        public void PressOn (int button)
        {
            commands[button].Positive();
            history.Push(commands[button]);
        }
        public void PressCancel ()
        {
            if(history.Count!=0)
            {
                history.Pop().Negative();
            }
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            Conveyor conveyor = new Conveyor();
            Multipult multipult = new Multipult();

            multipult.SetCommand(0, new ConveyorWorkCommand(conveyor));
            multipult.SetCommand(1, new ConveyorAdjustCommand(conveyor));

            multipult.PressOn(0);
            multipult.PressOn(1);

            multipult.PressCancel();
            multipult.PressCancel();


            Console.ReadKey();
        }
    }
}
