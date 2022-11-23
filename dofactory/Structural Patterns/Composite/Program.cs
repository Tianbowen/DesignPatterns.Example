using System;
using System.Collections.Generic;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             成员:
                1. Component(组件)
                    * 声明组合中对象的接口
                    * 酌情为所有类通用的接口实现默认行为
                    * 声明一个用于访问和管理其子组件的接口
                    * (可选)定义一个接口，用于访问递归结构中组件的父级，并在适当时实现它。
                2. Leaf(叶子)
                    * 表示组合中的叶对象。叶子没有孩子。
                    * 定义组合中原始对象的行为。
                3. Composite(复合)
                    * 定义有孩子的组件的行为
                    * 存储子组件
                    * 在组件接口中实现孩子的相关的操作。
                4. Client(客户)
                    * 通过组件接口操作组合中的对象。
             */

            // Structural code

            {
                Composite root = new Composite("root");
                root.Add(new Leaf("Leaf A"));
                root.Add(new Leaf("Leaf B"));

                Composite comp = new Composite("Composite X");
                comp.Add(new Leaf("Leaf XA"));
                comp.Add(new Leaf("Leaf XB"));

                root.Add(comp);
                root.Add(new Leaf("Leaf C"));

                Leaf leaf = new Leaf("Leaf D");
                root.Add(leaf);
                root.Remove(leaf);

                root.Display(1);
            }

            Console.WriteLine();

            // Real-world code 
            {
                CompositeElement root = new CompositeElement("Picture");
                root.Add(new PrimitiveElement("Red Line")) ;
                root.Add(new PrimitiveElement("Blue Circle")) ;
                root.Add(new PrimitiveElement("Green Box"));

                CompositeElement comp = new CompositeElement("Two Circles");
                comp.Add(new PrimitiveElement("Black Circle"));
                comp.Add(new PrimitiveElement("White Circle"));
                root.Add(comp);

                PrimitiveElement pe = new PrimitiveElement("Yellow Line");
                root.Add(pe);
                root.Remove(pe);

                root.Display(1);

            }


            Console.ReadKey();
        }
    }

    #region Structural code

    /*
     代码演示了Composite模式，该模式允许创建树结构，其中可以统一访问各个节点，无论它们时叶节点还是分支(复合)节点
     */

    /// <summary>
    /// 组件
    /// </summary>
    abstract class Component
    {
        protected string name;

        public Component(string name)
        {
            this.name = name;
        }

        public abstract void Add(Component c);
        public abstract void Remove(Component c);
        public abstract void Display(int depth);

    }
    // 复合
    class Composite : Component
    {
        List<Component> children = new List<Component>();

        public Composite(string name) : base(name)
        {

        }

        public override void Add(Component component)
        {
            children.Add(component);
        }

        public override void Remove(Component component)
        {
            children.Remove(component);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + name);

            foreach (Component component in children)
            {
                component.Display(depth + 2);
            }
        }
    }
    // 叶子
    class Leaf : Component
    {
        public Leaf(string name) : base(name)
        {

        }

        public override void Add(Component c)
        {
            Console.WriteLine("Cannot add to a leaf");
        }

        public override void Remove(Component c)
        {
            Console.WriteLine("Cannot remove from a leaf");
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
        }
    }


    #endregion


    #region Real-world code

    /*
     DrawingElement - 绘图元素 - 组件
     PrimitiveElement - 原始元素 - 叶子
     CompositeElement - 复合元素 - 复合
     */

    abstract class DrawingElement
    {
        protected string name;

        public DrawingElement(string name)
        {
            this.name = name;
        }

        public abstract void Add(DrawingElement d);
        public abstract void Remove(DrawingElement d);
        public abstract void Display(int indent);
    }

    class PrimitiveElement : DrawingElement
    {
        public PrimitiveElement(string name) : base(name) { }

        public override void Add(DrawingElement d)
        {
            Console.WriteLine("Cannot add to a PrimitiveElement");
        }

        public override void Remove(DrawingElement d)
        {
            Console.WriteLine("Cannot remove from a PrimitiveElement");
        }

        public override void Display(int indent)
        {
            Console.WriteLine(new string('-', indent) + " " + name);
        }
    }


    class CompositeElement : DrawingElement
    {
        List<DrawingElement> elements = new List<DrawingElement>();

        public CompositeElement(string name) : base(name) { }

        public override void Add(DrawingElement d)
        {
            elements.Add(d);
        }

        public override void Remove(DrawingElement d)
        {
            elements.Remove(d);
        }

        public override void Display(int indent)
        {
            Console.WriteLine(new string('-', indent) + "+ " + name);

            foreach (DrawingElement d in elements)
            {
                d.Display(indent + 2);
            }
        }
    }
    #endregion
}
