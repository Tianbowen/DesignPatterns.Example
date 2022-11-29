using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             成员:
                1. Facade(门面)
                    * 知道哪些子系统类负责请求
                    * 将客户请求委托给适当的子系统对象。
                2. Subsystem classes(子系统类)
                    * 实现字系统功能。
                    * 处理Facade对象分配的工作。
                    * 对门面一无所知，也没有提及它。
             */

            // Structural code
            Facade facade = new Facade();
            facade.MethodA();
            facade.MethodB();
            // Real-world code
            Mortgage mortgage = new Mortgage();

            Customer customer = new Customer("Ann McKinsey");
            bool eligible = mortgage.IsEligible(customer, 25000);
            Console.WriteLine("\n" + customer.Name + " has been " + (eligible ? "Approved" : "Reject"));

            Console.ReadKey();
        }
    }

    #region Sturctural code

    /*
     代码演示了，它为大型子系统类提供了一个简化和统一的接口。
     */

    class Facade
    {
        SubSystemOne one;
        SubSystemTwo two;
        SubSystemThree three;
        SubSystemFour four;
        public Facade()
        {
            one = new SubSystemOne();
            two = new SubSystemTwo();
            three = new SubSystemThree();
            four = new SubSystemFour();
        }

        public void MethodA()
        {
            Console.WriteLine("\nMethodA() --- ");
            one.MethodOne();
            two.MethodTwo();
            four.MethodFour();
        }

        public void MethodB()
        {
            Console.WriteLine("\nMethodB() --- ");
            two.MethodTwo();
            three.MethodThree();
        }
    }

    class SubSystemOne
    {
        public void MethodOne()
        {
            Console.WriteLine(" SubSystemOne Method");
        }
    }

    class SubSystemTwo
    {
        public void MethodTwo()
        {
            Console.WriteLine(" SubSystemTwo Method");
        }
    }

    class SubSystemThree
    {
        public void MethodThree()
        {
            Console.WriteLine(" SubSystemThree Method");
        }
    }

    class SubSystemFour
    {
        public void MethodFour()
        {
            Console.WriteLine(" SubSystemFour Method");
        }
    }

    #endregion

    #region Real-world code

    /*
     Bank - 银行 - 子系统类
     Credit - 信用 - 子系统类
     Loan - 贷款 - 子系统类
     Customer - 客户
     Mortgage - 按揭贷款 - 门面

     单词翻译:
     Eligible - 有资格
     */

    class Bank
    {
        public bool HasSufficientSavings(Customer c, int amount)
        {
            Console.WriteLine("Check bank for " + c.Name);
            return true;
        }
    }

    class Credit
    {
        public bool HasGoodCredit(Customer c)
        {
            Console.WriteLine("Check credit for " + c.Name);
            return true;
        }
    }

    class Loan
    {
        public bool HasNoBadLoans(Customer c)
        {
            Console.WriteLine("Check loans for " + c.Name);
            return true;
        }
    }

    class Customer
    {
        private string name;

        public Customer(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }
        #endregion
    }
    // Facade class
    class Mortgage
    {
        Bank bank = new Bank();
        Loan loan = new Loan();
        Credit credit = new Credit();

        public bool IsEligible(Customer c, int amount)
        {
            Console.WriteLine("{0} applies for {1:C} loan\n");

            bool eligible = true;

            if (!bank.HasSufficientSavings(c, amount))
            {
                eligible = false;
            }
            else if (!loan.HasNoBadLoans(c))
            {
                eligible = false;
            }
            else if (!credit.HasGoodCredit(c))
            {
                eligible = false;
            }

            return eligible;
        }
    }
}
