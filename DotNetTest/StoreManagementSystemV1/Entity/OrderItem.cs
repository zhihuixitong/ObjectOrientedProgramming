using StoreManagementSystemV1.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagementSystemV1.Entity
{
    /// <summary>
    /// 订单明细
    /// </summary>
    public class OrderItem : EntityBase
    {
        /// <summary>
        /// 子订单
        /// </summary>
        /// <param name="matter"></param>
        /// <param name="specification"></param>
        public OrderItem(Matter matter, Specification specification)
        {

            Matter = matter;
            Specification = specification;
            CreationTime = DateTime.Now;
        }

        /// <summary>
        /// 配料
        /// </summary>
        public Matter Matter { get; private set; }

        /// <summary>
        /// 规格
        /// </summary>
        public Specification Specification { get; private set; }



        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime CreationTime { get; private set; }
    }
}
