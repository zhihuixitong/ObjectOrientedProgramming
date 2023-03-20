using StoreManagementSystemV1.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagementSystemV1.Entity
{
    /// <summary>
    /// 规格配置
    /// </summary>
    public class Specification : EntityBase
    {
        /// <summary>
        /// 创建规格
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="number">数量</param>
        /// <param name="isRequired">是否必填</param>
        public Specification(string name, int number)
        {

            Name = name;
            Number = number;

        }
        /// <summary>
        /// 规格名
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 单位数
        /// </summary>
        public int Number { get; private set; }




    }
}
