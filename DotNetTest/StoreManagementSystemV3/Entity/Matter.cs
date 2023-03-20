using StoreManagementSystemV3.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagementSystemV3.Entity
{
    /// <summary>
    /// 配料
    /// </summary>
    public class Matter : EntityBase
    {
        /// <summary>
        /// 配料
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="number">数量</param>
        /// <param name="nuitName">单位</param>
        public Matter(string name, int number, string nuitName, List<Specification>? specifications = null, bool isRequired = false)
        {
            Name = name;
            Number = number;
            NuitName = nuitName;
            Specifications = specifications;
            IsRequired = isRequired;
        }

        /// <summary>
        ///名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Number { get; private set; }

        /// <summary>
        /// 计量单位名
        /// </summary>
        public string NuitName { get; private set; }

        /// <summary>
        /// 是否必填
        /// </summary>
        public bool IsRequired { get; private set; } = false;


        /// <summary>
        /// 规格配置
        /// </summary>
        public List<Specification> Specifications { get; private set; }

        /// <summary>
        /// 获取规格名字
        /// </summary>
        /// <returns></returns>
        public string GetSpecificationName()
        {
            string specificationsName = "";
            foreach (var specification in Specifications)
            {
                specificationsName += specification.Name;
                if (Specifications.LastOrDefault().Id != specification.Id)
                {
                    specificationsName += "、";
                }
            }

            return specificationsName;
        }

        /// <summary>
        /// 是否存在规格
        /// </summary>
        /// <param name="specificationName"></param>
        /// <returns></returns>
        public bool IsExistSpecification(string specificationName)
        {
            if (Specifications.Any(x => x.Name == specificationName || (x.Name + Name) == specificationName))
            {
                return true;
            }
            Console.WriteLine("规格错误!");
            return false;
        }

        /// <summary>
        /// 获取规格数
        /// </summary>
        /// <param name="specificationName"></param>
        /// <returns></returns>
        public Specification GetSpecification(string specificationName)
        {
            var specification = Specifications.Where(x => x.Name == specificationName || (x.Name + Name) == specificationName).FirstOrDefault();
            return specification;
        }

        /// <summary>
        /// 获取规格名
        /// </summary>
        /// <param name="specificationNumber"></param>
        /// <returns></returns>
        public string GetSpecificationName(int specificationNumber)
        {
            var specification = Specifications.Where(x => x.Number == specificationNumber).FirstOrDefault();
            if (specification == null)
            {
                return "";
            }
            return specification.Name;
        }
    }
}
