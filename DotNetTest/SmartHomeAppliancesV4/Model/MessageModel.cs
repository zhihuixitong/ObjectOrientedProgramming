using SmartHomeAppliancesV1.Entity.Base;
using SmartHomeAppliancesV1.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeAppliancesV4.Model
{
    /// <summary>
    /// 消息接收模型
    /// </summary>
    public class MessageModel
    {
        /// <summary>
        /// 消息接收模型
        /// </summary>
        /// <param name="id"></param>
        /// <param name="deviceName"></param>
        /// <param name="deviceStatus"></param>
        /// <param name="message"></param>
        public MessageModel(Guid id,string deviceName, DeviceStatusType deviceStatus,string message="") {
            Id = id;
            DeviceName = deviceName;
            DeviceStatus = deviceStatus;
            CreationTime = DateTime.Now;
            Message = message;
        }

        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// 设备名称
        /// </summary>
        public string DeviceName { get; private set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// 设备状态
        /// </summary>
        public DeviceStatusType DeviceStatus { get; private set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get; private set; }
    }
}
