using System;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             成员:
                1. Target(目标)
                    * 定义客户端使用的特定于域的接口
                2. Adapter(适配器)
                    * 将适配者接口适配为目标接口
                3. Adaptee(适配者)
                    * 定义需要调整的现有接口
                4. Client(客户)
                    * 与符合目标接口的对象协作
             */

            // Structural code
            Target target = new Adapter();
            target.Request();


            // Real-world code
            Compound unknown = new Compound();
            unknown.Display();

            Compound water = new RichCompound("Water");
            water.Display();

            Compound benzene = new RichCompound("Benzene");
            benzene.Display();

            Compound ethanol = new RichCompound("Ethanol");
            ethanol.Display();


            Console.ReadKey();

        }
    }

    #region Structural code

    /*
     代码演示了适配器模式，该模式将一个类的接口映射到另一个类，以便它们可以协同工作。这些不兼容的类可能来自不同的库或框架。
     */

    class Target
    {
        public virtual void Request()
        {
            Console.WriteLine("Called Target Request()");
        }
    }

    class Adapter : Target
    {
        public Adaptee adaptee = new Adaptee();

        public override void Request()
        {
            // 做其他工作后，调用特定请求
            adaptee.SpecificRequest();
        }
    }

    class Adaptee
    {
        //SpecificRequest 特定请求
        public void SpecificRequest()
        {
            Console.WriteLine("Called SpecificRequest()");
        }
    }

    #endregion


    #region Real-world code

    /*
     Compound 混合物 - 目标
     RichCompound 富混合物 - 适配器
     ChemicalDatabank 化学实验室 - 适配者 
     */

    class Compound
    {
        protected float boilingPoint;

        protected float meltingPoint;

        protected double molecularWeight;

        protected string molecularFormula;

        public virtual void Display()
        {
            Console.WriteLine("\nCompound: Unknown ------ ");
        }
    }

    class RichCompound : Compound
    {
        private string chemical;

        private ChemicalDatabank bank;

        public RichCompound(string chemical)
        {
            this.chemical = chemical;
        }

        public override void Display()
        {
            bank = new ChemicalDatabank();

            boilingPoint = bank.GetCriticalPoint(chemical, "B");
            meltingPoint = bank.GetCriticalPoint(chemical, "M");
            molecularWeight = bank.GetMolecularWeight(chemical);
            molecularFormula = bank.GetMolecularStructure(chemical);

            Console.WriteLine("\nCompound: {0} ------ ", chemical);
            Console.WriteLine(" Formula: {0}", molecularFormula);
            Console.WriteLine(" Weight : {0}", molecularWeight);
            Console.WriteLine(" Melting Pt: {0}", meltingPoint);
            Console.WriteLine(" Boiling Pt: {0}", boilingPoint);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    class ChemicalDatabank
    {
        public float GetCriticalPoint(string compound, string point)
        {
            if (point == "M")
            {
                switch (compound.ToLower())
                {
                    case "water": return 0.0f;
                    case "benzene": return 5.5f;
                    case "ethanol": return -114.1f;
                    default: return 0f;
                }
            }// Boiling Point
            else
            {
                switch (compound.ToLower())
                {
                    case "water": return 100.0f;
                    case "benzene": return 80.1f;
                    case "ethanol": return 78.3f;
                    default: return 0f;
                }
            }
        }

        public string GetMolecularStructure(string compound)
        {
            switch (compound.ToLower())
            {
                case "water": return "H20";
                case "benzene": return "C6H6";
                case "ethanol": return "C2H5OH";
                default: return "";
            }
        }
        public double GetMolecularWeight(string compound)
        {
            switch (compound.ToLower())
            {
                case "water": return 18.015;
                case "benzene": return 78.1134;
                case "ethanol": return 46.0688;
                default: return 0d;
            }
        }
    }
    #endregion
}
