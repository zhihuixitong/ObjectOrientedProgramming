
using StoreManagementSystemV2.DB;
using StoreManagementSystemV2.Entity;
using System;

namespace StoreManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("奶茶店管理系统V2");

            /*
             试题1、公司开了一家奶茶店，
             打底一个杯子，配料有奶、茶、糖、珍珠、布丁
            ，这些东西都有大中小3个档次，客户可以任意搭配。

            问题2：公司业务需要，增加配料葡萄、芒果依旧有大中小3个档次，
            现在客户点了一杯大杯高茶中糖多芒果少布丁。请在程序原程序中改进实现，
            并运行输出“大杯高茶中糖多芒果少布丁”字符串。
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

                while (true)
                {
                    Console.WriteLine("请问你需要几杯奶茶？");
                    var number = Console.ReadLine();
                    if (order.SetNumber(number))
                    {
                        break;
                    }
                }


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

                //下单
                if (store.Shopping(order) == null)
                {
                    Console.WriteLine("下单失败！");
                    continue;
                }

                Console.WriteLine(order.OrderName + "\n");
            }



        }
    }
}