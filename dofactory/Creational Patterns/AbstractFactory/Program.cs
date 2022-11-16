using System;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             成员:
                1. 抽象工厂
                    * 为创建抽象产品的操作声明一个 "接口"
                2. 具体工厂
                    * 实现 "创建具体商品对象" 的操作
                3. 抽象产品
                    * 声明一种产品对象的接口
                4. 产品
                    * 定义要由相应的具体工厂创建的产品对象
                    * 实现抽象产品接口
                5. 客户
                    * 使用由抽象工厂和抽象产品类声明的接口
             */

            // Abstract factory #1

            AbstractFactory factory1 = new ConcreteFactory1();
            Client client1 = new Client(factory1);
            client1.Run();

            // Abstract factory #2

            AbstractFactory factory2 = new ConcreteFactory2();
            Client client2 = new Client(factory2);
            client2.Run();

            // Real-world code 真实代码

            ContinentFactory africa = new AfricaFactory();
            AnimalWorld world = new AnimalWorld(africa);
            world.RunFoodChain();

            ContinentFactory america = new AmericaFactory();
            world = new AnimalWorld(america);
            world.RunFoodChain();

            Console.ReadKey();

        }


        #region UML类
        abstract class AbstractFactory
        {
            public abstract AbstractProductA CreateProductA();

            public abstract AbstractProductB CreateProductB();
        }


        class ConcreteFactory1 : AbstractFactory
        {
            public override AbstractProductA CreateProductA()
            {
                return new ProductA1();
            }

            public override AbstractProductB CreateProductB()
            {
                return new ProductB1();
            }
        }

        class ConcreteFactory2 : AbstractFactory
        {
            public override AbstractProductA CreateProductA()
            {
                return new ProductA2();
            }

            public override AbstractProductB CreateProductB()
            {
                return new ProductB2();
            }
        }

        abstract class AbstractProductA
        {

        }

        abstract class AbstractProductB
        {
            public abstract void Interact(AbstractProductA a);
        }

        class ProductA1 : AbstractProductA
        {

        }

        class ProductA2 : AbstractProductA
        {

        }

        class ProductB1 : AbstractProductB
        {
            public override void Interact(AbstractProductA a)
            {
                Console.WriteLine($"{this.GetType().Name} interacts with { a.GetType().Name}");
            }
        }

        class ProductB2 : AbstractProductB
        {
            public override void Interact(AbstractProductA a)
            {
                Console.WriteLine($"{this.GetType().Name} interacts with {a.GetType().Name}");
            }
        }

        class Client
        {
            private AbstractProductA _abstractProductA;
            private AbstractProductB _abstractProductB;

            public Client(AbstractFactory factory)
            {
                _abstractProductA = factory.CreateProductA();
                _abstractProductB = factory.CreateProductB();
            }

            public void Run()
            {
                _abstractProductB.Interact(_abstractProductA);
            }
        }

        #endregion

        #region Real-world code 真实代码

        // Continent 陆地
        // Africa 非洲
        // America 美洲
        // Herbivore 食草动物 
        // Carnivore 食肉动物
        // Wildebeest 羚羊
        // Lion 狮子
        // Bison 野牛
        // Wolf 狼
        // FoodChain 食物链

        /// <summary>
        /// 抽象工厂
        /// </summary>
        abstract class ContinentFactory
        {
            public abstract Herbivore CreateHerbivore();

            public abstract Carnivore CreateCarnivore();
        }

        /// <summary>
        /// 具体工厂
        /// </summary>
        class AfricaFactory : ContinentFactory
        {
            public override Herbivore CreateHerbivore()
            {
                return new Wildebeest();
            }

            public override Carnivore CreateCarnivore()
            {
                return new Lion();
            }
        }

        /// <summary>
        /// 具体工厂 实现
        /// </summary>
        class AmericaFactory : ContinentFactory
        {
            public override Herbivore CreateHerbivore()
            {
                return new Bison();
            }

            public override Carnivore CreateCarnivore()
            {
                return new Wolf();
            }
        }

        /// <summary>
        /// 抽象产品 
        /// </summary>
        abstract class Herbivore
        {

        }

        /// <summary>
        /// 抽象产品
        /// </summary>
        abstract class Carnivore
        {
            public abstract void Eat(Herbivore h);
        }

        /// <summary>
        /// 具体产品
        /// </summary>
        class Wildebeest : Herbivore
        {

        }

        /// <summary>
        /// 具体产品
        /// </summary>
        class Lion : Carnivore
        {
            public override void Eat(Herbivore h)
            {
                // Eat Wildebeest 

                Console.WriteLine($"{this.GetType().Name} eats {h.GetType().Name}");
            }
        }
        /// <summary>
        /// 具体产品
        /// </summary>
        class Bison : Herbivore
        {

        }
        /// <summary>
        /// 具体产品
        /// </summary>
        class Wolf : Carnivore
        {
            public override void Eat(Herbivore h)
            {
                // Eat Bison
                Console.WriteLine($"{this.GetType().Name} eats {h.GetType().Name}");
            }
        }

        // 客户
        class AnimalWorld
        {
            private Herbivore _herbivore;
            private Carnivore _carnivore;

            public AnimalWorld(ContinentFactory factory)
            {
                _carnivore = factory.CreateCarnivore();
                _herbivore = factory.CreateHerbivore();
            }

            public void RunFoodChain()
            {
                _carnivore.Eat(_herbivore);
            }
        }

        #endregion
    }
}
