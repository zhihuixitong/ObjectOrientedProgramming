
using StoreManagementSystemV3.DB;
using StoreManagementSystemV3.Entity;
using System;
namespace StoreManagementSystem
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("奶茶店管理系统V3");

            /*
             试题1、公司开了一家奶茶店，
             打底一个杯子，配料有奶、茶、糖、珍珠、布丁
            ，这些东西都有大中小3个档次，客户可以任意搭配。

            问题3：公司业务开展不错，来了很多的客户，客户下单需要排队等待，请在原程序中改进，实现排队功能。
            */

            //新开奶茶店
            Store store = new Store("奶茶店");
            //购买配料
            store.BoughtMatters(DB.Matters);
            //购买配料2
            store.BoughtMatters(DB.Matters2);

            while (true)
            {
                //生成订单
                var order = new Order();
                //获取订单数量
                GetOrderNumber(order);
                //获取订单规格
                GetOrderSpecification(store, order);

                //下单
                if ((await store.Shopping(order)) == null)
                {
                    Console.WriteLine("下单失败！");
                    continue;
                }

                Console.WriteLine("\n");
            }



        }

        /// <summary>
        /// 获取订单规格
        /// </summary>
        /// <param name="store"></param>
        /// <param name="order"></param>
        private static void GetOrderSpecification(Store store, Order order)
        {
            foreach (var matter in store.Matters)
            {
                while (true)
                {
                    Console.WriteLine($"请问你需要{matter.GetSpecificationName()}{matter.Name}? {(matter.IsRequired ? "【必填】" : "【不需要则填写空】")}");
                    var importStr = Console.ReadLine();
                    if (string.IsNullOrEmpty(importStr) && !matter.IsRequired)
                    {
                        break;
                    }
                    //规格校验
                    if (matter.IsExistSpecification(importStr))
                    {
                        //设置规格
                        order.SetOrderItem(matter, matter.GetSpecification(importStr));
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 获取订单数
        /// </summary>
        /// <param name="order"></param>
        private static void GetOrderNumber(Order order)
        {
            while (true)
            {
                Console.WriteLine("请问你需要几杯奶茶？");
                var number = Console.ReadLine();
                if (order.SetNumber(number))
                {
                    break;
                }
            }
        }
    }
}