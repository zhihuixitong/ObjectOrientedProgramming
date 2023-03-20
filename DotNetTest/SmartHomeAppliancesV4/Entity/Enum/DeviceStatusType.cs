﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeAppliancesV1.Entity.Enum
{
    /// <summary>
    /// 设备状态
    /// </summary>
    public enum DeviceStatusType
    {
        开始煮饭 = 1,
        饭煮好了 = 2,
        开始扫地 = 3,
        地扫干净了 = 4,
        开始烤面包 = 5,
        面包烤好了 = 6,
        照亮房间 = 7,
        房间黑暗了 = 8,
        电视关了 = 9,
        打开电视 = 10,
        冰箱关了 = 11,
        打开冰箱 = 12,
        运行异常 = 13,
    }
}
