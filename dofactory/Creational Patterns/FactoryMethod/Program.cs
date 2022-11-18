using System;
using System.Collections.Generic;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             成员:
                1. 产品
                    * 定义工厂方法创建的对象的接口
                2. 具体产品
                    * 实现产品接口
                3. 创建者
                    * 声明工厂方法，该方法返回一个产品类型的对象。创建者还可以定义返回默认具体产品对象的工厂的默认方法。
                    * 可以调用工厂方法来创建产品对象。
                4. 具体创建者
                    * 覆盖工厂方法以返回具体产品的实例。
             */

            // Structural code 

            Creator[] creators = new Creator[2];

            creators[0] = new ConcreteCreatorA();
            creators[1] = new ConcreteCreatorB();

            foreach (Creator creator in creators)
            {
                Product product = creator.FactoryMethod();
                Console.WriteLine("Created {0}", product.GetType().Name);
            }

            //Real-world code

            Document[] documents = new Document[2];
            documents[0] = new Resume();
            documents[1] = new Report();

            foreach (Document document in documents)
            {
                Console.WriteLine("\n" + document.GetType().Name + "--");
                foreach (Page page in document.Pages)
                {
                    Console.WriteLine(" " + page.GetType().Name);
                }
            }

            Console.ReadKey();
        }
    }


    #region Structural code
    /*
     代码演示了工厂方法在创建不同对象方面提供了极大的灵活性。抽象类可以提供默认对象，但每个子类都可以实例化该对象的扩展版本。     
     */

    /// <summary>
    /// 产品
    /// </summary>
    abstract class Product
    {

    }

    class ConcreteProductA : Product
    {

    }

    class ConcreteProductB : Product
    {

    }


    abstract class Creator
    {
        public abstract Product FactoryMethod();
    }

    class ConcreteCreatorA : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductA();
        }
    }

    class ConcreteCreatorB : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductB();
        }
    }

    #endregion


    #region Real-world code

    /*
     代码演示了工厂方法在创建不同文档时提供的灵活性。派生的Document类Report和Resume实例化了Document类的扩展版本。在Document基类的构造函数中调用工厂方法。

     Page - 页面 - 产品
     SkillsPage - 技能页面 - 具体产品
     EducationPage - 教育页面 - 具体产品
     ExperiencePage - 体验页面 - 具体产品
     IntroductionPage - 简介页面 - 具体产品
     ResultsPage - 结果页面 - 具体产品
     ConclusionPage - 结论页面 - 具体产品
     SummaryPage - 摘要页面 - 具体产品
     BibliographyPage - 书目页面 - 具体产品
     */

    abstract class Page { }

    class SkillPage : Page { }

    class EducationPage : Page { }

    class ExperiencePage : Page { }

    class IntroductionPage : Page { }

    class ResultsPage : Page { }

    class ConclusionPage : Page { }

    class SummaryPage : Page { }

    class BibliographyPage : Page { }

    abstract class Document
    {
        private List<Page> _pages = new List<Page>();

        public Document()
        {
            this.CreatePages();
        }

        public List<Page> Pages { get { return _pages; } }

        public abstract void CreatePages();

    }

    class Resume : Document
    {
        public override void CreatePages()
        {
            Pages.Add(new SkillPage());
            Pages.Add(new EducationPage());
            Pages.Add(new ExperiencePage());
        }
    }

    class Report : Document
    {
        public override void CreatePages()
        {
            Pages.Add(new IntroductionPage());
            Pages.Add(new ResultsPage());
            Pages.Add(new ConclusionPage());
            Pages.Add(new SummaryPage());
            Pages.Add(new BibliographyPage());
        }
    }



    #endregion
}
