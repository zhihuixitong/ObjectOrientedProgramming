using Factory.Entity;
using System;
using System.Collections.Generic;

namespace FactoryV2
{
    class Program
    {
        /// <summary>
        /// 理解：工厂模式的拓展性
        /// 不断抽象不断拓展
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<IDevice> devices = new List<IDevice>();

            IFactory factory= new RiceCookerFactory();
            devices.Add(factory.Creater());
            IFactory factory2 = new SweepingMachineFactory();
            devices.Add(factory2.Creater());

            while (true)
            {
                var inputStr = Console.ReadLine();

                if (inputStr == "开")
                {
                    devices.ForEach(x =>
                    {
                        x.On();
                    });
                }
                if (inputStr == "关")
                {
                    devices.ForEach(x =>
                    {
                        x.OFF();
                    });
                }
            }
        }
    }
}
