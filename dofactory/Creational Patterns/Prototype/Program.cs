using System;
using System.Collections.Generic;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             成员:
                1. 原型
                    * 声明一个用于克隆自身的接口
                2. 具体原型
                    * 实现克隆自身的操作
                3. 客户
                    * 通过要求原型克隆自身来创建一个新对象
             */

            // Structural code 

            ConcretePrototype1 p1 = new ConcretePrototype1("I");
            ConcretePrototype1 c1 = (ConcretePrototype1)p1.Clone();
            Console.WriteLine("Cloned: {0}", c1.Id);

            ConcretePrototype2 p2 = new ConcretePrototype2("II");
            ConcretePrototype2 c2 = (ConcretePrototype2)p2.Clone();
            Console.WriteLine("Cloned: {0}", c2.Id);

            //Real-world code

            ColorManager colorManager = new ColorManager();

            colorManager["red"] = new Color(255, 0, 0);
            colorManager["green"] = new Color(0, 255, 0);
            colorManager["blue"] = new Color(0, 0, 255);

            colorManager["angry"] = new Color(255, 54, 0);
            colorManager["peace"] = new Color(128, 211, 128);
            colorManager["flame"] = new Color(211, 34, 20);

            Color color1 = colorManager["red"].Clone() as Color;
            Color color2 = colorManager["peace"].Clone() as Color;
            Color color3 = colorManager["flame"].Clone() as Color;

            Console.WriteLine($"Prototype color:{colorManager["red"].GetHashCode()} Clone: {color1.GetHashCode()}");
            Console.ReadKey();
        }
    }

    #region Structural code

    /*
     代码演示了原型模式，其中通过复制同一类的预先存在的对象(原型)来创建新对象。
     
     MemberwiseClone 创建当前Object的浅表副本
     */

    abstract class Prototype
    {
        string id;

        public Prototype(string id)
        {
            this.id = id;
        }

        public string Id
        {
            get { return id; }
        }

        public abstract Prototype Clone();
    }

    class ConcretePrototype1 : Prototype
    {
        public ConcretePrototype1(string id) : base(id)
        {
        }

        public override Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone();
        }
    }

    class ConcretePrototype2 : Prototype
    {
        public ConcretePrototype2(string id) : base(id)
        {
        }

        public override Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone();
        }
    }

    #endregion

    #region Real-world code

    /*
     代码演示了原型模式，在该模式中，通过复制预先存在的,用户定义的相同类型的颜色来创建新的颜色对象。
     */

    abstract class ColorPrototype
    {
        public abstract ColorPrototype Clone();
    }


    class Color : ColorPrototype
    {
        int red;
        int green;
        int blue;

        public Color(int red, int green, int blue)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
        }

        public override ColorPrototype Clone()
        {
            Console.WriteLine("Cloning color RGB:{0,3},{1,3},{2,3}", this.red, this.green, this.blue);

            return this.MemberwiseClone() as ColorPrototype;
        }
    }

    class ColorManager
    {
        private Dictionary<string, ColorPrototype> colors = new Dictionary<string, ColorPrototype>();

        public ColorPrototype this[string key]
        {
            get { return colors[key]; }
            set { colors.Add(key, value); }
        }
    }

    #endregion
}
