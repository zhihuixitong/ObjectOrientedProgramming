using StoreManagementSystemV1.Entity.Base;
using StoreManagementSystemV1.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagementSystemV1.Entity
{
    /// <summary>
    /// 订单
    /// </summary>
    public class Order : EntityBase
    {
        /// <summary>
        /// 下单
        /// </summary>
        public Order()
        {
            No = DateTime.Now.ToString("yyyyMMddHHmmssfffff");
            CreationTime = UpdateTime = DateTime.Now;

        }

        /// <summary>
        /// 单号
        /// </summary>
        public string No { get; private set; }

        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime CreationTime { get; private set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; private set; }

        /// <summary>
        /// 订单名
        /// </summary>
        public string OrderName { get; private set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public OrderStatusType OrderStatus { get; private set; } = OrderStatusType.下单;

        /// <summary>
        /// 数量
        /// </summary>
        public int Number { get; private set; }

        /// <summary>
        /// 订单明细
        /// </summary>
        public List<OrderItem> OrderItems { get; private set; }

        /// <summary>
        /// 更新订单
        /// </summary>
        /// <param name="orderStatus"></param>
        public void UpOrderStatus(OrderStatusType orderStatus)
        {
            OrderStatus = orderStatus;
            UpdateTime = DateTime.Now;
        }

        /// <summary>
        /// 验证订单
        /// </summary>
        /// <returns></returns>
        public bool Verify()
        {
            if (OrderItems == null || !OrderItems.Any())
            {
                Console.WriteLine("订单为空！");
                return false;
            }

            if (this.Number == 0)
            {
                Console.WriteLine("订单数空！");
                return false;
            }


            return true;
        }

        /// <summary>
        /// 设置数量
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool SetNumber(string number)
        {
            int thisNumber;

            if (number == null || !int.TryParse(number, out thisNumber))
            {
                Console.WriteLine("数量输入错误！");
                return false;
            }
            this.Number = thisNumber;
            return true;
        }

        /// <summary>
        /// 设置订单详情
        /// </summary>
        /// <param name="matter"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool SetOrderItem(Matter matter, Specification specification)
        {

            if (matter == null || specification == null)
            {
                Console.WriteLine("规格输入错误！");
                return false;
            }
            //增加规格
            var orderItem = new OrderItem(matter, specification);
            this.OrderItems ??= new List<OrderItem>();
            this.OrderItems.Add(orderItem);
            return true;
        }

        /// <summary>
        /// 设置订单名
        /// </summary>
        /// <returns></returns>
        public string SetName()
        {
            var orderName = "";
            if (OrderItems == null || !OrderItems.Any()) return orderName;

            foreach (var orderItem in OrderItems)
            {
                orderName += orderItem.Specification.Name;
                orderName += orderItem.Matter.Name;
            }
            OrderName = orderName;
            return orderName;
        }


    }
}
