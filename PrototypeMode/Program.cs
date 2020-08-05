using System;
using static System.Console;

namespace PrototypeMode
{
    class Program
    {
        static void Main(string[] args)
        {

            //原型模式 从一个对象创建另外一个可定制的对象，而不需要知道创建细节
            Person person=new Person();
            person.Name="Jeck";
            person.Age=12;
            person.Gender=Gender.男;    

            WriteLine("Person {0} {1} {2}",person.Name,person.Age,person.Gender);

            Person clonePerson=(Person)person.Clone();
            clonePerson.Name+="Clone";            
            WriteLine("Person {0} {1} {2}",person.Name,person.Age,person.Gender);
            WriteLine("PersonClone {0} {1} {2}",clonePerson.Name,clonePerson.Age,clonePerson.Gender);

            // 内嵌对象
            Recipient recipient =new Recipient ();
            recipient.Name="张三";
            recipient.Address="深圳市";
            recipient.Phone="13255554444";

            Order order=new Order ();
            order.Id=1;
            order.OrderNo="123456";
            order.Recipient=recipient;

            WriteLine("Order {0} {1} {2} ,Recipient {3} {4} {5}",order.Id,order.OrderNo, order.Recipient==null,order.Recipient.Name,order.Recipient.Address,order.Recipient.Phone);

            Order cloneOrder= (Order)order.Clone();
            cloneOrder.OrderNo+="clone";
            cloneOrder.Recipient.Name+="clone";
            

            WriteLine("Order {0} {1} {2} ,Recipient {3} {4} {5}",cloneOrder.Id,cloneOrder.OrderNo, cloneOrder.Recipient==null,cloneOrder.Recipient.Name,cloneOrder.Recipient.Address,cloneOrder.Recipient.Phone);
              WriteLine("Order {0} {1} {2} ,Recipient {3} {4} {5}",order.Id,order.OrderNo, order.Recipient==null,order.Recipient.Name,order.Recipient.Address,order.Recipient.Phone);
            ReadLine();
        }
    }
}
