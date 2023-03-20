using SmartHomeAppliancesV1.DB;
using SmartHomeAppliancesV1.Entity;
using SmartHomeAppliancesV1.Entity.Entity.DeviceEntity;
using SmartHomeAppliancesV4.Model;
using System;
using System.Threading.Channels;
using System.Xml.Linq;

namespace SmartHomeAppliances
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("智能家电V4\n");
            /*
             试题2、一个家里面有电饭锅、扫地机器人等电器，
            都有通电和断电2种动作，当是电饭锅通电时，会开始煮饭，
            断电时饭煮好了。扫地机器人通电会开始扫地，断电时地扫干净了。

             问题4：每个电器都有损坏的可能，
            当电器损坏时，主程序要可以第一时间知道，
            并行进报警。请在程序中扩展实现。
             */

            //启动消息接收任务
            MessageManageTask();

            Home home = new Home("我的家");

            //添加设备
            home.AddDevice(DB.Devices);

            //添加新设备
            home.AddDevice(DB.Devices2);

            //添加更多设备
            home.AddDevice(DB.Devices3);

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




        /// <summary>
        /// 消息列表
        /// </summary>
        public static Channel<MessageModel> MessageList = Channel.CreateUnbounded<MessageModel>();

        /// <summary>
        /// 消息管理（接收）
        /// </summary>
        public static async void MessageManageTask()
        {

            await Task.Run(async () =>
            {
                while (true)
                {

                    //防止死循环
                    await Task.Delay(100);

                    try
                    {
                        var message = await MessageList.Reader.ReadAsync();
                        if (message == null) continue;

                        Console.WriteLine($"收到消息：{message.DeviceName.PadRight(16 - message.DeviceName.Length)} {message.DeviceStatus.ToString().PadRight(16 - message.DeviceStatus.ToString().Length)}  {message.Message?.ToString().PadRight(Math.Abs(16 - message.Message.ToString().Length))} {message.CreationTime} \n");
                       
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("消息管理异常！");
                    }

                }


            });
        }

    }
}