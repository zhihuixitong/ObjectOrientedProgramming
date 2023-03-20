using SmartHomeAppliances;
using SmartHomeAppliancesV1.Entity.Base;
using SmartHomeAppliancesV1.Entity.Entity.DeviceEntity;
using SmartHomeAppliancesV1.Entity.Enum;
using SmartHomeAppliancesV4.Entity.Base;
using SmartHomeAppliancesV4.Entity.Enum;
using SmartHomeAppliancesV4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeAppliancesV1.Entity.Entity
{
    /// <summary>
    /// 设备
    /// </summary>
    public class Device : EntityBase
    {
        /// <summary>
        /// 创建设备
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="deviceInstructs">指令集</param>
        /// <param name="isEnable">是否激活</param>
        /// <param name="devicePowerStatusType">开关状态</param>
        public Device(string name,
            List<DeviceInstruct> deviceInstructs,
            bool isEnable = true,
            DevicePowerStatusType devicePowerStatusType = DevicePowerStatusType.关
            )
        {
            Name = name;
            DeviceInstructs = deviceInstructs;
            if (deviceInstructs != null)
            {
                DeviceStatus = (DeviceInstructs?.Where(x => x.IsDefault)?.FirstOrDefault()?.DeviceStatus) ?? DeviceStatusType.开始煮饭;
            }
            IsEnable = isEnable;
            DevicePowerStatus = devicePowerStatusType;
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnable { get; private set; }

        /// <summary>
        /// 设备状态
        /// </summary>
        public DeviceStatusType DeviceStatus { get; private set; }
        /// <summary>
        /// 设备开关状态
        /// </summary>
        public DevicePowerStatusType DevicePowerStatus { get; private set; }

        /// <summary>
        /// 设备指令
        /// </summary>
        public List<DeviceInstruct> DeviceInstructs { get; private set; }

        /// <summary>
        /// 操作设备
        /// </summary>
        /// <param name="deviceInstruct"></param>
        /// <returns></returns>
        public virtual bool OperateDevice(string instructName)
        {
            if (string.IsNullOrWhiteSpace(instructName))
            {
                Console.WriteLine("操作无效!");
                return false;
            }

            var thisDeviceInstruct = DeviceInstructs?.Where(x => x.InstructName == instructName).FirstOrDefault();
            if (thisDeviceInstruct == null)
            {
                Console.WriteLine($"{Name}不支持{instructName}操作!");
                return false;
            }
            //状态相同
            if (DevicePowerStatus == thisDeviceInstruct.DevicePowerStatus) return true;

            this.DeviceStatus = thisDeviceInstruct.DeviceStatus;
            DevicePowerStatus = thisDeviceInstruct.DevicePowerStatus;

            //根据指令执行相关任务 （开|关）
            OperateTask();

            Console.WriteLine($"{Name.PadRight(16 - Name.Length)} {DeviceStatus.ToString().PadRight(16 - DeviceStatus.ToString().Length)}{DateTime.Now} \n");
            return true;
        }

        /// <summary>
        /// 根据指令操作任务
        /// </summary>
        private void OperateTask()
        {
            if (DevicePowerStatus == DevicePowerStatusType.关)
            {
                //取消任务等待
                AwaitTaskSource.Cancel();
                AwaitTaskSource.Dispose();
            }
            if (DevicePowerStatus == DevicePowerStatusType.开)
            {
                AwaitTaskSource = new CancellationTokenSource();
                BuildTaskService();
            }
        }



        /// <summary>
        /// 自身运行任务
        /// </summary>
        private Task? TaskService;
        /// <summary>
        /// 等待任务的标识
        /// </summary>
        private CancellationTokenSource AwaitTaskSource = new CancellationTokenSource();

        /// <summary>
        /// 创建任务
        /// </summary>
        public void BuildTaskService()
        {
            //创建新任务
            if (TaskService == null || TaskService.IsCompleted)
            {
                TaskService = Task.Run(async () =>
                {
                    while (DevicePowerStatus == DevicePowerStatusType.开)
                    {
                        if (DevicePowerStatus == DevicePowerStatusType.关) return;

                        try
                        {
                            //模拟随机损坏
                            Random random = new Random();
                            var randomTime = random.Next(5000, 20000);
                            if (randomTime % 2 == 0)
                            {
                                await Task.Delay(randomTime, AwaitTaskSource.Token);
                                throw new InteriorException("机器损坏");
                            }

                        }
                        catch (InteriorException e)
                        {
                            DevicePowerStatus = DevicePowerStatusType.关;
                            DeviceStatus = DeviceStatusType.运行异常;
                            //通知主程序
                            await Program.MessageList.Writer.WriteAsync(new MessageModel(Id, Name, DeviceStatus, e.Message));
                            return;
                        }
                        catch (Exception e)
                        {
                            return;
                        }
                        await Task.Delay(100);
                    }

                });


            }



        }





    }
}
