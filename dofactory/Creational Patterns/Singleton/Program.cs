using System;
using System.Collections.Generic;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             成员:
                1. 单例
                    * 定义一个实例操作，让客户端访问它的唯一实例，实例是一个类操作。
                    * 负责创建和维护自己的唯一实例。
             */

            // Structural code 

            Singleton s1 = Singleton.Instance();
            Singleton s2 = Singleton.Instance();

            if (s1 == s2)
            {
                Console.WriteLine("Object are the same instance.");
            }

            // Real-world code

            LoadBalancer b1 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b2 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b3 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b4 = LoadBalancer.GetLoadBalancer();

            if (b1 == b2 && b2 == b3 && b3 == b4)
            {
                Console.WriteLine("Same instance\n");
            }

            LoadBalancer balancer = LoadBalancer.GetLoadBalancer();
            for (int i = 0; i < 10; i++)
            {
                string server = balancer.Server;
                Console.WriteLine("Dispatch Request to: " + server);
            }

            Console.ReadKey();
        }
    }

    #region Structural code

    /*
     代码演示了单例模式，该模式确保只能创建该类的单个实例(单例);
     */

    class Singleton
    {
        static Singleton instance;

        protected Singleton()
        {
        }

        public static Singleton Instance()
        {
            if (instance == null)
            {
                instance = new Singleton();
            }

            return instance;
        }
    }

    #endregion


    #region Real-world code 

    /*
     LoadBalancer - 负载均衡器 - 单例

     */

    class LoadBalancer
    {
        static LoadBalancer instance;
        List<string> servers = new List<string>();
        Random random = new Random();

        private static object locker = new object();

        protected LoadBalancer()
        {
            servers.Add("ServerI");
            servers.Add("ServerII");
            servers.Add("ServerIII");
            servers.Add("ServerIV");
            servers.Add("ServerV");
        }

        public static LoadBalancer GetLoadBalancer()
        {
            if (instance == null)
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new LoadBalancer();
                    }
                }
            }

            return instance;
        }

        public string Server
        {
            get
            {
                int r = random.Next(servers.Count);
                return servers[r].ToString();
            }
        }
    }



    #endregion

}


