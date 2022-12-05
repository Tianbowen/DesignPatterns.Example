using System;
using System.Collections.Generic;

namespace Flyweight
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             成员:
                1. 享元(Flyweight)
                    * 声明了一个接口，flyweight可以通过该接口接收并作用于外部状态.
                2. 具体享元(ConcreteFlyweight)
                    * 实现Flyweight接口，并为内部状态(如果有的话)添加存储。ConcreteFlyweight对象必须是可共享的。它存储的任何状态都必须是内在的，也就是说，它必须独立于具体享元对象的上下文。
                3. 非共享具体享元(UnsharedConcreteFlyweight)
                    * 并非所有的享元子类都需要共享。Flyweight收
                4. 享元工厂(FlyweightFactory)
                    * 
                    * 
                5. 客户端
                    * 
             */

            // Structural code 

            int extrinsicstate = 22;

            FlyweightFactory factory = new FlyweightFactory();

            Flyweight fx = factory.GetFlyweight("X");
            fx.Operation(--extrinsicstate);

            Flyweight fy = factory.GetFlyweight("Y");
            fy.Operation(--extrinsicstate);

            Flyweight fz = factory.GetFlyweight("Z");
            fz.Operation(--extrinsicstate);

            UnsharedConcreteFlyweight fu = new UnsharedConcreteFlyweight();
            fu.Operation(--extrinsicstate);

            // Real-world
            string document = "AAZZBBZB";
            char[] chars = document.ToCharArray();
            CharacterFactory charfactory = new CharacterFactory();
            int pointSize = 10;

            foreach (char c in chars)
            {
                pointSize++;
                Character character = charfactory.GetCharacter(c);
                character.Display(pointSize);
            }


            // Wait for user

            Console.WriteLine();

        }
    }

    #region Structural code 

    // 
    public class FlyweightFactory
    {
        private Dictionary<string, Flyweight> flyweights { get; set; } = new Dictionary<string, Flyweight>();

        public FlyweightFactory()
        {
            flyweights.Add("X", new ConcreteFlyweight());
            flyweights.Add("Y", new ConcreteFlyweight());
            flyweights.Add("Z", new ConcreteFlyweight());
        }

        public Flyweight GetFlyweight(string key)
        {
            return ((Flyweight)flyweights[key]);
        }
    }

    public abstract class Flyweight
    {
        public abstract void Operation(int extrinsicstate);
    }

    public class ConcreteFlyweight : Flyweight
    {
        public override void Operation(int extrinsicstate)
        {
            Console.WriteLine("ConcreteFlyweight:" + extrinsicstate);
        }
    }

    public class UnsharedConcreteFlyweight : Flyweight
    {
        public override void Operation(int extrinsicstate)
        {
            Console.WriteLine("UnsharedConcreteFlyweight:" + extrinsicstate);
        }
    }
    #endregion

    // Read-world code

    /*
     CharacterFactory - 字符工厂 - 享元工厂类
     Character - 字符 - 享元抽象类
     CharacterA - 字符A - 具体享元类
     */


    class CharacterFactory
    {
        private Dictionary<char, Character> characters = new Dictionary<char, Character>();

        public Character GetCharacter(char key)
        {
            // Uses "lazy initialization"

            Character character = null;

            if (characters.ContainsKey(key))
            {
                character = characters[key];
            }
            else
            {
                switch (key)
                {
                    case 'A': character = new CharacterA(); break;
                    case 'B': character = new CharacterB(); break;
                    case 'Z': character = new CharacterZ(); break;
                }
                characters.Add(key, character);
            }
            return character;
        }
    }

    // 享元抽象类
    abstract class Character
    {
        protected char symbol;
        protected int width;
        protected int height;
        protected int ascent;
        protected int descent;
        protected int pointSize;

        public abstract void Display(int pointSize);
    }
    // 具体享元
    class CharacterA : Character
    {
        public CharacterA()
        {
            symbol = 'A';
            width = 120;
            height = 100;
            ascent = 70;
            descent = 0;
        }

        public override void Display(int pointSize)
        {
            this.pointSize = pointSize;
            Console.WriteLine(symbol + " (pointsize " + this.pointSize + ")");

        }
    }

    class CharacterB : Character
    {
        // Constructor
        public CharacterB()
        {
            symbol = 'B';
            height = 100;
            width = 140;
            ascent = 72;
            descent = 0;
        }
        public override void Display(int pointSize)
        {
            this.pointSize = pointSize;
            Console.WriteLine(this.symbol +
                " (pointsize " + this.pointSize + ")");
        }
    }

    class CharacterZ : Character
    {
        // Constructor
        public CharacterZ()
        {
            symbol = 'Z';
            height = 100;
            width = 100;
            ascent = 68;
            descent = 0;
        }
        public override void Display(int pointSize)
        {
            this.pointSize = pointSize;
            Console.WriteLine(this.symbol +
                " (pointsize " + this.pointSize + ")");
        }
    }
}
