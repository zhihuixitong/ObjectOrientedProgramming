using SmartHomeAppliancesV1.Entity.Base;
using SmartHomeAppliancesV1.Entity.Entity.DeviceEntity;
using SmartHomeAppliancesV1.Entity.Enum;
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
        public Device(string name, List<DeviceInstruct> deviceInstructs,bool isEnable = true)
        {
            Name = name;
            DeviceInstructs = deviceInstructs;
            if (deviceInstructs != null)
            {
                DeviceStatus = (DeviceInstructs?.Where(x => x.IsDefault)?.FirstOrDefault()?.DeviceStatus)?? DeviceStatusType.开始煮饭;
            }
            IsEnable = isEnable;
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
            if(string.IsNullOrWhiteSpace(instructName))
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
            if (DeviceStatus == thisDeviceInstruct.DeviceStatus) return true;

            this.DeviceStatus = thisDeviceInstruct.DeviceStatus;
            //根据指令执行相关任务 （开|关）

            Console.WriteLine($"{Name.PadRight(16-Name.Length)} {DeviceStatus.ToString().PadRight(16 - DeviceStatus.ToString().Length)}{DateTime.Now} \n");
            return true;
        }
    }
}
