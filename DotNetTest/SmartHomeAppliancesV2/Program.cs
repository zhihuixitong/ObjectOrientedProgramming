using SmartHomeAppliancesV1.DB;
using SmartHomeAppliancesV1.Entity;
using SmartHomeAppliancesV1.Entity.Entity.DeviceEntity;
using System;
namespace SmartHomeAppliances
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("智能家电V2\n");
            /*
             试题2、一个家里面有电饭锅、扫地机器人等电器，
            都有通电和断电2种动作，当是电饭锅通电时，会开始煮饭，
            断电时饭煮好了。扫地机器人通电会开始扫地，断电时地扫干净了。

             问题2：现在家里增加了烤箱和电灯电器，
            烤箱通电时会开始烤面包，断电时面包烤好了。
            电灯通电时会照亮房间，断时电房间黑暗了。
            请在程序中进行改行，增加这2种电器进行工作。
             */

            Home home = new Home("我的家");

            //添加设备
            home.AddDevice(DB.Devices);

            //添加新设备
            home.AddDevice(DB.Devices2);

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
                    if (!instructNames.Any(x => x == deviceInstruct.InstructName))
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