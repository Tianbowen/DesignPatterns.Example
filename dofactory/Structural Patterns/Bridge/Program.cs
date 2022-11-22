using System;
using System.Collections.Generic;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             成员:
                1. 抽象(Abstraction)
                    * 定义抽象的接口
                    * 维护对实现类型对象的引用
                2. 扩展抽象(RefinedAbstraction)
                    * 扩展由抽象定义的接口
                3. 实现(Implementor)
                    * 定义实现类的接口。该接口不必与抽象的接口完全对应;事实上，这两个界面可能完全不同。通常，实现接口只提供原语操作，而抽象则根据这些原语定义更高级别的操作。
                4. 具体实现(ConcreteImplementor)
                    * 实现实现类的接口并定义其具体实现。
             */

            // Structural code
            Abstraction ab = new RefinedAbstraction();

            ab.Implementor = new ConcreteImplementorA();
            ab.Operation();

            ab.Implementor = new ConcreteImplementorB();
            ab.Operation();

            // Real-world code
            var customers = new Customers();

            customers.Data = new CustomersData("Chicago");

            customers.Show();
            customers.Next();
            customers.Show();
            customers.Next();
            customers.Show();
            customers.Add("Henry Velasquez");
            customers.ShowAll();

            Console.ReadKey();

        }
    }

    #region Structural code

    /*
     代码演示了将接口与其实现分离(解耦)的桥接模式。实现可以在不改变使用对象抽象的客户端的情况下发展。
     */


    /// <summary>
    /// 抽象
    /// </summary>
    class Abstraction
    {
        protected Implementor implementor;

        public Implementor Implementor
        {
            set { implementor = value; }
        }

        public virtual void Operation()
        {
            implementor.Operation();
        }
    }
    /// <summary>
    /// 实现
    /// </summary>
    abstract class Implementor
    {
        public abstract void Operation();
    }
    /// <summary>
    /// 扩展抽象
    /// </summary>
    class RefinedAbstraction : Abstraction
    {
        public override void Operation()
        {
            implementor.Operation();
        }
    }
    /// <summary>
    /// 具体实现
    /// </summary>
    class ConcreteImplementorA : Implementor
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteImplementorA Operation");
        }
    }
    /// <summary>
    /// 具体实现
    /// </summary>
    class ConcreteImplementorB : Implementor
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteImplementorB Operation");
        }
    }

    #endregion

    #region Real-world code

    /*
     CustomersBase 客户基类 - 抽象
     Customers - 客户 - 扩展抽象
     DataObject - 数据对象 - 实现
     CustomersData - 客户数据 - 具体实现
     */

    /// <summary>
    /// 抽象
    /// </summary>
    class CustomersBase
    {
        private DataObject dataObject;

        public DataObject Data { set { dataObject = value; } get { return dataObject; } }

        public virtual void Next()
        {
            dataObject.NextRecord();
        }

        public virtual void Prior()
        {
            dataObject.PriorRecord();
        }

        public virtual void Add(string customer)
        {
            dataObject.AddRecord(customer);
        }

        public virtual void Delete(string customer)
        {
            dataObject.DeleteRecord(customer);
        }

        public virtual void Show()
        {
            dataObject.ShowRecord();
        }

        public virtual void ShowAll()
        {
            dataObject.ShowAllRecords();
        }
    }

    /// <summary>
    /// 扩展抽象
    /// </summary>
    class Customers : CustomersBase
    {
        public override void ShowAll()
        {
            Console.WriteLine();
            Console.WriteLine("------------------------");
            base.ShowAll();
            Console.WriteLine("------------------------");
        }
    }

    /// <summary>
    /// 实现抽象
    /// </summary>
    abstract class DataObject
    {
        public abstract void NextRecord();

        public abstract void PriorRecord();

        public abstract void AddRecord(string name);

        public abstract void DeleteRecord(string name);

        public abstract string GetCurrentRecord();

        public abstract void ShowRecord();

        public abstract void ShowAllRecords();
    }
    /// <summary>
    /// 具体实现
    /// </summary>
    class CustomersData : DataObject
    {
        private readonly List<string> customers = new List<string>();

        private int current = 0;

        private string city;

        public CustomersData(string city)
        {
            this.city = city;

            customers.Add("Jim Jones");
            customers.Add("Samual Jackson");
            customers.Add("Allen Good");
            customers.Add("Ann Stills");
            customers.Add("Lisa Giolani");
        }

        public override void NextRecord()
        {
            if (current <= customers.Count - 1)
            {
                current++;
            }
        }

        public override void PriorRecord()
        {
            if (current > 0)
            {
                current--;
            }
        }

        public override void AddRecord(string name)
        {
            customers.Add(name);
        }

        public override void DeleteRecord(string customer)
        {
            customers.Remove(customer);
        }
        public override string GetCurrentRecord()
        {
            return customers[current];
        }
        public override void ShowRecord()
        {
            Console.WriteLine(customers[current]);
        }
        public override void ShowAllRecords()
        {
            Console.WriteLine("Customer City: " + city);
            foreach (string customer in customers)
            {
                Console.WriteLine(" " + customer);
            }
        }
    }
    #endregion
}
