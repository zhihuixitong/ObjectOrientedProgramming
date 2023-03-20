using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeAppliancesV4.Entity.Base
{
    /// <summary>
    /// 内部异常
    /// </summary>
    public class InteriorException : Exception
    {
        public InteriorException(string message) {
            Message = message;
        }
        public string Message { get;private set; }
    }
}
