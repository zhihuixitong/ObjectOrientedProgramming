using SmartHomeAppliancesV1.Entity.Base;
using SmartHomeAppliancesV1.Entity.Enum;
using SmartHomeAppliancesV4.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeAppliancesV1.Entity.Entity.DeviceEntity
{
    /// <summary>
    /// 设备指令
    /// </summary>
    public class DeviceInstruct : EntityBase
    {
        /// <summary>
        /// 创建指令
        /// </summary>
        /// <param name="instructName">指令名</param>
        /// <param name="deviceStatus">设备状态</param>
        /// <param name="isDefault">是否默认</param>
        public DeviceInstruct(string instructName, 
            DeviceStatusType deviceStatus,
            bool isDefault=false, 
            DevicePowerStatusType devicePowerStatus= DevicePowerStatusType.关)
        {
            InstructName = instructName;
            DeviceStatus = deviceStatus;
            IsDefault = isDefault;
            DevicePowerStatus = devicePowerStatus;
        }
        /// <summary>
        /// 指令标识名
        /// </summary>
        public string InstructName { get; private set; }

        /// <summary>
        /// 指令状态
        /// </summary>
        public DeviceStatusType DeviceStatus { get; private set;}

        /// <summary>
        /// 设备开关状态
        /// </summary>
        public DevicePowerStatusType DevicePowerStatus { get; private set; }

        /// <summary>
        ///默认指令
        /// </summary>
        public bool IsDefault { get; private set; }
    }
}
