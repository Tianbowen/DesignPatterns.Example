using System;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             成员:
                1. 代理(Proxy)
                    * 维护一个引用，让代理访问真正的主题。如果真实主体和主体接口相同，则代理可以引用主体。
                    * 提供与主体相同的接口，以便可以用代理代替真实的主体。
                    * 控制对真实主体的访问，并可能负责创建和删除它。
                    * 其他职责取决于代理的种类
                        * 远程代理-负责对请求以及参数进行编码，并将编码后的请求发送到不同地址空间中的真实主体。
                        * 虚拟代理-可能会缓存有关真实主体的其他信息，以便他们可以推迟访问它。例如,Motivation中的ImageProxy缓存了真实图像的范围。
                        * 保护代理-检查调用者是否具有执行请求所需的访问权限。
                2. 主体(Subject)
                    * 定义了真实主体和代理的公共接口，这样代理就可以在任何需要真实主体的地方使用。
                3. 真实主体(RealSubject)
                    * 定义代理代表的真实对象。
             */

            // Structural code
            Proxy proxy = new Proxy();
            proxy.Request();


            // Real-world code
            MathProxy proxyMath = new MathProxy();
            Console.WriteLine("4 + 2 = " + proxyMath.Add(4, 2));
            Console.WriteLine("4 - 2 = " + proxyMath.Sub(4, 2));
            Console.WriteLine("4 * 2 = " + proxyMath.Mul(4, 2));
            Console.WriteLine("4 / 2 = " + proxyMath.Div(4, 2));

            Console.ReadLine();

        }
    }

    #region Structural code

    /*
     代码演示了代理模式，它提供了一个代表对象(代理)来控制对另一个类对象的访问。
     */

    abstract class Subject
    {
        public abstract void Request();
    }

    class RealSubject : Subject
    {
        public override void Request()
        {
            Console.WriteLine("Called RealSubject.Request()");
        }
    }
    class Proxy : Subject
    {
        private RealSubject realSubject;

        public override void Request()
        {
            if (realSubject == null)
            {
                realSubject = new RealSubject();
            }
            realSubject.Request();
        }
    }
    #endregion


    #region Real-world code

    /*
     代码演示了MathProxy对象表示的Math对象的代理模式。
     Math - 数学函数 - 真实主体
     IMath - 数学函数接口 - 主体接口
     MathProxy - 数据函数代理 - 代理对象
     */

    interface IMath
    {
        double Add(double x, double y);
        double Sub(double x, double y);
        double Mul(double x, double y);
        double Div(double x, double y);
    }

    class Math : IMath
    {
        public double Add(double x, double y) { return x + y; }
        public double Sub(double x, double y) { return x - y; }
        public double Mul(double x, double y) { return x * y; }
        public double Div(double x, double y) { return x / y; }
    }

    class MathProxy : IMath
    {
        private Math math = new Math();

        public double Add(double x, double y)
        {
            return math.Add(x, y);
        }

        public double Div(double x, double y)
        {
            return math.Div(x, y);
        }

        public double Mul(double x, double y)
        {
            return math.Mul(x, y);
        }

        public double Sub(double x, double y)
        {
            return math.Sub(x, y);
        }
    }

    #endregion
}
