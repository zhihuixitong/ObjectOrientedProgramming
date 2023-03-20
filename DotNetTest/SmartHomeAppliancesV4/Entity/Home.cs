using SmartHomeAppliancesV1.Entity.Base;
using SmartHomeAppliancesV1.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeAppliancesV1.Entity
{
    /// <summary>
    /// 家
    /// </summary>
    public class Home : EntityBase
    {
        /// <summary>
        /// 创建家
        /// </summary>
        /// <param name="name">名称</param>
        public Home(string name) {
            Name = name;
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 家电设备
        /// </summary>
        public List<Device> Devices { get; private set; }

        /// <summary>
        /// 添加设备
        /// </summary>
        /// <param name="device"></param>
        public void AddDevice(Device device)
        {
            Devices ??= new List<Device>();

            Devices.Add(device);
        }

        /// <summary>
        /// 添加设备
        /// </summary>
        /// <param name="device"></param>
        public void AddDevice(List<Device> devices)
        {
            Devices ??= new List<Device>();

            Devices.InsertRange(Devices.Count(),devices);
        }

        /// <summary>
        /// 操作所有设备
        /// </summary>
        /// <param name="instructName"></param>
        public void OperateDevices(string instructName)
        {
            this.Devices?.ForEach(device =>
            {
                device.OperateDevice(instructName);
            });
        }


    }
}
