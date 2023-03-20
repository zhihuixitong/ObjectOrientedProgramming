using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeAppliancesV1.Entity.Base
{
    /// <summary>
    /// 基类
    /// </summary>
    public class EntityBase
    {
        public EntityBase()
        {
            this.Id = Guid.NewGuid();
        }
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; private set; }

    }
}
