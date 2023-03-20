using StoreManagementSystemV2.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagementSystemV2.DB
{
    /// <summary>
    /// 存储数据
    /// </summary>
    public class DB
    {

        /// <summary>
        /// 配料 存储数据
        /// </summary>
        public static List<Matter>? Matters =
                        new List<Matter>()
                            {
                                new Matter("杯",99999,"个",
                                    new List<Specification>()
                                    {
                                        new Specification("小",1),
                                        new Specification("中",1),
                                        new Specification("大",1),
                                    },true),
                                new Matter("奶",99999,"g",
                                    new List<Specification>()
                                    {
                                        new Specification("低",100),
                                        new Specification("中",200),
                                        new Specification("高",300),
                                    }),
                                new Matter("茶",99999,"g",
                                    new List<Specification>()
                                    {
                                         new Specification("低",100),
                                        new Specification("中",200),
                                        new Specification("高",300),
                                    }),
                                new Matter("糖",99999,"g",
                                    new List<Specification>()
                                    {
                                        new Specification("低",100),
                                        new Specification("中",200),
                                        new Specification("高",300),
                                    }),
                                new Matter("珍珠",99999,"g",
                                    new List<Specification>()
                                    {
                                        new Specification("少",100),
                                        new Specification("中",200),
                                        new Specification("多",300),
                                    }),
                                new Matter("布丁",99999,"g",
                                    new List<Specification>()
                                    {
                                        new Specification("少",100),
                                        new Specification("中",200),
                                        new Specification("多",300),
                                    }),
                            };

        /// <summary>
        /// 配料2 存储数据
        /// </summary>
        public static List<Matter>? Matters2 =
                        new List<Matter>()
                            {
                                new Matter("葡萄",99999,"g",
                                    new List<Specification>()
                                    {
                                        new Specification("少",100),
                                        new Specification("中",200),
                                        new Specification("多",300),
                                    }),
                                new Matter("芒果",99999,"g",
                                    new List<Specification>()
                                    {
                                        new Specification("少",100),
                                        new Specification("中",200),
                                        new Specification("多",300),
                                    })
                            };
    }
}
