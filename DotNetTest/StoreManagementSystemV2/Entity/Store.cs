﻿using StoreManagementSystemV2.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagementSystemV2.Entity
{

    /// <summary>
    /// 店铺
    /// </summary>
    public class Store : EntityBase
    {

        public Store(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 配料
        /// </summary>
        public List<Matter>? Matters { get; private set; }

        /// <summary>
        /// 订单
        /// </summary>
        public List<Order>? Orders { get; private set; }


        /// <summary>
        /// 购买配料
        /// </summary>
        /// <param name="matters">配料</param>
        /// <returns>是否成功</returns>
        public bool BoughtMatters(List<Matter>? matters)
        {
            if (matters == null || matters == null) return false;

            this.Matters ??= new List<Matter>();
            this.Matters.InsertRange(this.Matters.Count, matters);
            return true;
        }


        /// <summary>
        /// 下单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public Order? Shopping(Order order)
        {
            //验证订单
            if (!order.Verify())
            {
                return null;
            }
            //生成名称
            order.SetName();

            //更新订单状态
            order.UpOrderStatus(Enum.OrderStatusType.下单);
            order.UpOrderStatus(Enum.OrderStatusType.制作中);
            order.UpOrderStatus(Enum.OrderStatusType.制作完成);

            //记录订单
            this.Orders ??= new List<Order>();
            this.Orders.Add(order);

            return order;
        }
    }
}
