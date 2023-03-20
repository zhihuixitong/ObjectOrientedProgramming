﻿using SmartHomeAppliancesV1.Entity.Entity;
using SmartHomeAppliancesV1.Entity.Entity.DeviceEntity;
using SmartHomeAppliancesV4.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeAppliancesV1.DB
{

    /// <summary>
    /// 存储数据
    /// </summary>
    public class DB
    {

        /// <summary>
        /// 设备存储数据
        /// </summary>
        public static List<Device> Devices3 = new List<Device>()
        {
            new Device("电视",
                 new List<DeviceInstruct>()
                    {
                        new DeviceInstruct("关", Entity.Enum.DeviceStatusType.电视关了,true, devicePowerStatus: DevicePowerStatusType.关),
                        new DeviceInstruct("开", Entity.Enum.DeviceStatusType.打开电视,  devicePowerStatus: DevicePowerStatusType.开),
                    }
                 ),
            new Device("冰箱",
                 new List<DeviceInstruct>()
                    {
                        new DeviceInstruct("关", Entity.Enum.DeviceStatusType.冰箱关了,true, devicePowerStatus: DevicePowerStatusType.关),
                        new DeviceInstruct("开", Entity.Enum.DeviceStatusType.打开冰箱, devicePowerStatus: DevicePowerStatusType.开),
                    }
                 ),
        };


        /// <summary>
        /// 设备存储数据
        /// </summary>
        public static List<Device> Devices2 = new List<Device>()
        {
            new Device("烤箱",
                 new List<DeviceInstruct>()
                    {
                        new DeviceInstruct("关", Entity.Enum.DeviceStatusType.面包烤好了,true, devicePowerStatus: DevicePowerStatusType.关),
                        new DeviceInstruct("开", Entity.Enum.DeviceStatusType.开始烤面包, devicePowerStatus: DevicePowerStatusType.开),
                    }
                 ),
            new Device("电灯",
                 new List<DeviceInstruct>()
                    {
                        new DeviceInstruct("关", Entity.Enum.DeviceStatusType.房间黑暗了,true, devicePowerStatus: DevicePowerStatusType.关),
                        new DeviceInstruct("开", Entity.Enum.DeviceStatusType.照亮房间, devicePowerStatus: DevicePowerStatusType.开),
                    }
                 ),
        };


        /// <summary>
        /// 设备存储数据2
        /// </summary>
        public static List<Device> Devices = new List<Device>()
        {
            new Device("电饭锅",
                 new List<DeviceInstruct>()
                    {
                        new DeviceInstruct("关", Entity.Enum.DeviceStatusType.饭煮好了,true, devicePowerStatus: DevicePowerStatusType.关),
                        new DeviceInstruct("开", Entity.Enum.DeviceStatusType.开始煮饭, devicePowerStatus: DevicePowerStatusType.开),
                    }
                 ),
            new Device("扫地机器人",
                 new List<DeviceInstruct>()
                    {
                        new DeviceInstruct("关", Entity.Enum.DeviceStatusType.地扫干净了,true, devicePowerStatus: DevicePowerStatusType.关),
                        new DeviceInstruct("开", Entity.Enum.DeviceStatusType.开始扫地, devicePowerStatus: DevicePowerStatusType.开),
                    }
                 ),
        };

    }
}
