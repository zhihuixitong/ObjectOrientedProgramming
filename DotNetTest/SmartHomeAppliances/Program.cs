using SmartHomeAppliancesV1.DB;
using SmartHomeAppliancesV1.Entity;
using SmartHomeAppliancesV1.Entity.Entity.DeviceEntity;
using System;
using System.Linq;
using System;

namespace SmartHomeAppliances
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("智能家电V1\n");
            /*
             试题2、一个家里面有电饭锅、扫地机器人等电器，
            都有通电和断电2种动作，当是电饭锅通电时，会开始煮饭，
            断电时饭煮好了。扫地机器人通电会开始扫地，断电时地扫干净了。

             问题1：现在有一个开关，可以控制通电和断电，请在程序中实现交互，
            通电时展示电器都在工作，断电时电器都停止工作。
             */

            Home home = new Home("我的家");

            //添加设备
            home.AddDevice(DB.Devices);

            //输出设备支持的指令
            OutputInstruct(home);

            while (true)
            {
                Console.WriteLine("请操作设备！");
                var instructName = Console.ReadLine();
                //操作所有设备
                home.OperateDevices(instructName);
            }
        }


        /// <summary>
        /// 输出支持的指令
        /// </summary>
        private static void OutputInstruct(Home home)
        {
            Console.Write("设备支持指令：");
            var instructNames = new List<string>();
            home.Devices.ForEach(device =>
            {
                device.DeviceInstructs.ForEach(deviceInstruct =>
                {
                    if (!instructNames.Any(x=>x==deviceInstruct.InstructName))
                    {
                        instructNames.Add(deviceInstruct.InstructName);
                        Console.Write(deviceInstruct.InstructName + "、");
                    }
                    
                });
            });
            Console.WriteLine("\n");
        }
    }
}