using Factory.Entity;
using System;
using System.Collections.Generic;

namespace Factory
{
    class Program
    {
        /// <summary>
        /// 工厂模式理解：通过不同的类实现不同的方法，但是每个方法归属同一个继承基类
        /// 方法的封转
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            /*
             使用工厂模式设计
            试题2、一个家里面有电饭锅、扫地机器人等电器，
            都有通电和断电2种动作，当是电饭锅通电时，会开始煮饭，
            断电时饭煮好了。扫地机器人通电会开始扫地，断电时地扫干净了。
            */

            List<IDevice> devices = new List<IDevice>();
            devices.Add(new RiceCooker());
            devices.Add(new SweepingMachine());
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
