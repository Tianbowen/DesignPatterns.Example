using System;
using System.Collections.Generic;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             成员:
                1. 组件(Component)
                    * 为可以动态添加职责的对象定义接口。
                2. 具体组件(ConcreteComponent)
                    * 定义一个可以附加附加职责的对象。
                3. 装饰者(Decorator)
                    * 维护对组件对象的引用并定义复合组件接口的接口。
                4. 具体装饰者(ConcreteDecorator)
                    * 向组件添加职责
             */

            // Structural code
            ConcreteComponent c = new ConcreteComponent();
            ConcreteDecoratorA d1 = new ConcreteDecoratorA();
            ConcreteDecoratorB d2 = new ConcreteDecoratorB();

            d1.SetComponent(c);
            d2.SetComponent(d1);

            d2.Operation();

            // Real-world code
            Book book = new Book("Worley", "Inside ASP.NET", 10);
            book.Display();

            Video video = new Video("Spielberg", "Jaws", 23, 92);
            video.Display();

            Console.WriteLine("\nMaking video borrowable:");
            Borrowable borrowvideo = new Borrowable(video);
            borrowvideo.BorrowItem("Customer #1");
            borrowvideo.BorrowItem("Customer #2");

            borrowvideo.Display();
            Console.WriteLine("\nReturnItem:");
            borrowvideo.ReturnItem("Customer #1");
            borrowvideo.Display();

            Console.ReadKey();
        }
    }

    #region Structural code

    /*
     代码演示了装饰器模式，它动态地向现有对象添加额外的功能。
     */

    // 组件
    abstract class Component
    {
        public abstract void Operation();
    }

    // 具体组件
    class ConcreteComponent : Component
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteComponent.Opreation()");
        }
    }

    // 装饰者
    abstract class Decorator : Component
    {
        protected Component component;

        public void SetComponent(Component component)
        {
            this.component = component;
        }

        public override void Operation()
        {
            if (component != null)
            {
                component.Operation();
            }
        }
    }
    // 具体装饰A
    class ConcreteDecoratorA : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("ConcreteDecoratorA.Operation()");
        }
    }
    // 具体装饰B
    class ConcreteDecoratorB : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            AddedBehavior();
            Console.WriteLine("ConcreteDecoratorB.Operation()");
        }

        void AddedBehavior()
        {

        }
    }

    #endregion

    #region Real-world code

    /*
     LibraryItem - 库项 - 组件
     Book - 书 - 具体组件
     Video - 视频 - 具体组件
     DecoratorR - 装饰 - 装饰者
     Borrowable - 可借用 - 具体装饰者
     */

    // 组件抽象类
    abstract class LibraryItem
    {
        private int numCopies;

        public int NumCopies
        {
            get { return numCopies; }
            set { numCopies = value; }
        }

        public abstract void Display();
    }

    class Book : LibraryItem
    {
        private string author;
        private string title;

        public Book(string author, string title, int numCopies)
        {
            this.author = author;
            this.title = title;
            this.NumCopies = numCopies;
        }

        public override void Display()
        {
            Console.WriteLine("\nBook ------ ");
            Console.WriteLine(" Author: {0}", author);
            Console.WriteLine(" Title: {0}", title);
            Console.WriteLine(" # Copies: {0}", NumCopies);
        }
    }

    class Video : LibraryItem
    {
        private string director;
        private string title;
        private int playTime;

        public Video(string director, string title, int numCopies, int playTime)
        {
            this.director = director;
            this.title = title;
            this.NumCopies = numCopies;
            this.playTime = playTime;
        }

        public override void Display()
        {
            Console.WriteLine("\nVideo ----- ");
            Console.WriteLine(" Director: {0}", director);
            Console.WriteLine(" Title: {0}", title);
            Console.WriteLine(" # Copies: {0}", NumCopies);
            Console.WriteLine(" Playtime: {0}\n", playTime);
        }
    }
    // 装饰者
    abstract class DecoratorR : LibraryItem
    {
        protected LibraryItem libraryItem;

        public DecoratorR(LibraryItem libraryItem)
        {
            this.libraryItem = libraryItem;
        }

        public override void Display()
        {
            libraryItem.Display();
        }
    }

    class Borrowable : DecoratorR
    {
        protected readonly List<string> borrowers = new List<string>();


        public Borrowable(LibraryItem libraryItem) : base(libraryItem)
        {

        }

        public void BorrowItem(string name)
        {
            borrowers.Add(name);
            libraryItem.NumCopies--;
        }

        public void ReturnItem(string name)
        {
            borrowers.Remove(name);
        }

        public override void Display()
        {
            base.Display();

            foreach (string borrower in borrowers)
            {
                Console.WriteLine(" borrower: " + borrower);
            }
        }
    }



    #endregion
}
