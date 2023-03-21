using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Entity
{
    /// <summary>
    /// 设备
    /// </summary>
    public interface IDevice
    {
        /// <summary>
        /// 开
        /// </summary>
        void On();
        /// <summary>
        /// 关
        /// </summary>
        void OFF();




    }

    /// <summary>
    /// 电饭锅
    /// </summary>
    public class RiceCooker : IDevice
    {


        public void OFF()
        {
            Console.WriteLine("饭煮好了");
        }

        public void On()
        {
            Console.WriteLine("开始煮饭");
        }
    }

    /// <summary>
    /// 扫地机
    /// </summary>
    public class SweepingMachine : IDevice
    {
        public void OFF()
        {
            Console.WriteLine("地扫干净");
        }

        public void On()
        {
            Console.WriteLine("开始扫地");
        }
    }


    /// <summary>
    /// 工厂拓展方法
    /// </summary>
    public interface IFactory
    {
        /// <summary>
        /// 创建对象
        /// </summary>
        /// <returns></returns>
        IDevice Creater();
    }

    /// <summary>
    /// 电饭锅拓展方法
    /// </summary>
    public class RiceCookerFactory : IFactory
    {
        public IDevice Creater()
        {
            return new RiceCooker();
        }
    }

    /// <summary>
    /// 扫地机器拓展方法
    /// </summary>
    public class SweepingMachineFactory : IFactory
    {
        public IDevice Creater()
        {
            return new SweepingMachine();
        }
    }


}
