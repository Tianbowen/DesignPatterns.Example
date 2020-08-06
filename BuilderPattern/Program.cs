using System;

namespace BuilderPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //客户端使用链式调用，一步一步的把对象构建出来。 属于简化的使用方式，与其经典Builder模式不同。
            // Computer computer = new Computer().Builder("因特尔","三星")
            //                         .SetUsbCount(1)
            //                         .SetKeyBoard("罗技")
            //                         .SetDisplay("三星")
            //                         .builder();

            // 传统builder模式
            ComputerDirector director=new ComputerDirector ();
            CTComputerBuilder builder=new MacComputerBuilder("A13处理器","三星16G");
            director.MakeComputer(builder);
            CTComputer macComputer= builder.GetComputer();
            Console.WriteLine(macComputer.ToString());

            CTComputerBuilder lenovoBuilder=new LenovoComputerBuilder("I7 处理器","西部数据");
            director.MakeComputer(lenovoBuilder);
            CTComputer lenovoComputer=lenovoBuilder.GetComputer();
            Console.WriteLine(lenovoComputer.ToString());

            Console.WriteLine("Hello World!");
        }
    }
}
