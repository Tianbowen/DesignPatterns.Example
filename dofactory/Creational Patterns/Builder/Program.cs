using System;
using System.Collections.Generic;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             成员:
                1. 建造者
                    * 指定用于创建产品对象的部分抽象接口
                2. 具体建造者
                    * 通过实现建造者接口构造和组装产品的各个部分
                    * 定义并跟踪它创建的表示
                    * 提供用于检索产品的接口
                3. Director - 负责人
                    * 使用建造者接口构造一个对象
                4. 产品
                    * 表示正在构建的复杂对象，具体建造者构建产品的内部表示并定义其组装过程
                    * 包括定义组成部分的类，包括用于将部分组装成最终结果的接口                    
             */

            // Structural Code 
            Director director = new Director();

            Builder b1 = new ConcreteBuilder1();
            Builder b2 = new ConcreteBuilder2();

            director.Construct(b1);
            Product p1 = b1.GetResult();
            p1.Show();


            director.Construct(b2);
            Product p2 = b2.GetResult();
            p2.Show();

            // Real-world code

            VehicleBuilder builder;

            Shop shop = new Shop();

            builder = new ScooterBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();

            builder = new CarBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();

            builder = new MotorCycleBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();

            Console.ReadKey();
        }
    }

    #region Structural code 结构代码

    /*
     代码演示了构建器模式，其中已逐步方式创建复杂对象。构建过程可以创建不同的对象表示，并提供对对象组装的高级控制。

     Director - 负责人
     Construct - 建造
     Concrete - 具体
     */

    /// <summary>
    /// 负责人
    /// </summary>
    class Director
    {
        public void Construct(Builder builder)
        {
            builder.BuildPartA();
            builder.BuildPartB();
        }
    }

    /// <summary>
    /// 建造者
    /// </summary>
    abstract class Builder
    {
        public abstract void BuildPartA();

        public abstract void BuildPartB();

        public abstract Product GetResult();
    }

    /// <summary>
    /// 具体建造者
    /// </summary>
    class ConcreteBuilder1 : Builder
    {
        private Product _product = new Product();

        public override void BuildPartA()
        {
            _product.Add("PartA");
        }

        public override void BuildPartB()
        {
            _product.Add("PartB");
        }

        public override Product GetResult()
        {
            return _product;
        }
    }

    class ConcreteBuilder2 : Builder
    {
        private Product _product = new Product();

        public override void BuildPartA()
        {
            _product.Add("PartX");
        }

        public override void BuildPartB()
        {
            _product.Add("PartY");
        }

        public override Product GetResult()
        {
            return _product;
        }
    }

    /// <summary>
    /// 产品
    /// </summary>
    class Product
    {
        private List<string> _parts = new List<string>();

        public void Add(string part)
        {
            _parts.Add(part);
        }

        public void Show()
        {
            Console.WriteLine("\nProduct Parts ------");
            foreach (string part in _parts)
            {
                Console.WriteLine(part);
            }
        }
    }
    #endregion


    #region Real-world code 真实代码

    /*
     Shop - 商店
     vehicle - 车辆
     Frame - 支架
     Engine - 发动机
     Wheel - 轮子
     Door - 门
     MotorCycle - 摩托车
     Car - 汽车
     Scooter - 踏板车
     */

    /// <summary>
    /// 负责人
    /// </summary>
    class Shop
    {
        public void Construct(VehicleBuilder vehicleBuilder)
        {
            vehicleBuilder.BuildFrame();
            vehicleBuilder.BuildEngine();
            vehicleBuilder.BuildWheels();
            vehicleBuilder.BuildDoors();
        }
    }


    abstract class VehicleBuilder
    {
        protected Vehicle vehicle;

        public Vehicle Vehicle
        {
            get { return vehicle; }
        }

        // 抽象建造方法

        public abstract void BuildFrame();

        public abstract void BuildEngine();

        public abstract void BuildWheels();

        public abstract void BuildDoors();
    }


    class MotorCycleBuilder : VehicleBuilder
    {
        public MotorCycleBuilder()
        {
            vehicle = new Vehicle("MotorCycle");
        }

        public override void BuildFrame()
        {
            vehicle["frame"] = "MotorCycle Frame";
        }

        public override void BuildEngine()
        {
            vehicle["engine"] = "500 cc";
        }

        public override void BuildWheels()
        {
            vehicle["wheels"] = "2";
        }

        public override void BuildDoors()
        {
            vehicle["doors"] = "0";
        }
    }


    class CarBuilder : VehicleBuilder
    {
        public CarBuilder()
        {
            vehicle = new Vehicle("Car");
        }
        public override void BuildFrame()
        {
            vehicle["frame"] = "Car Frame";
        }
        public override void BuildEngine()
        {
            vehicle["engine"] = "2500 cc";
        }
        public override void BuildWheels()
        {
            vehicle["wheels"] = "4";
        }
        public override void BuildDoors()
        {
            vehicle["doors"] = "4";
        }
    }
    class ScooterBuilder : VehicleBuilder
    {
        public ScooterBuilder()
        {
            vehicle = new Vehicle("Scooter");
        }
        public override void BuildFrame()
        {
            vehicle["frame"] = "Scooter Frame";
        }
        public override void BuildEngine()
        {
            vehicle["engine"] = "50 cc";
        }
        public override void BuildWheels()
        {
            vehicle["wheels"] = "2";
        }
        public override void BuildDoors()
        {
            vehicle["doors"] = "0";
        }
    }

    class Vehicle
    {
        private string _vehicleType;
        private Dictionary<string, string> _parts = new Dictionary<string, string>();


        public Vehicle(string vehicleType)
        {
            this._vehicleType = vehicleType;
        }

        public string this[string key]
        {
            get { return _parts[key]; }
            set { _parts[key] = value; }
        }

        public void Show()
        {
            Console.WriteLine($"\n------");
            Console.WriteLine($"Vehicle Type:{_vehicleType}");
            Console.WriteLine($" Frame: {_parts["frame"]}");
            Console.WriteLine($" Engine: {_parts["engine"]}");
            Console.WriteLine($" #Wheels: {_parts["wheels"]}");
            Console.WriteLine($" #Doors: {_parts["doors"]}");
        }
    }

    #endregion
}
