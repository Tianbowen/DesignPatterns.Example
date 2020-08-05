using System;

namespace PrototypeMode
{
   
    public class Order :ICloneable
    {              
        public int Id{get;set;}

        public string OrderNo{get;set;}

        public Recipient Recipient {get;set;}

        public object Clone()
        {
            // 实现深拷贝的第一种方法 就是逐一赋值
            return new Order(){Id=Id,OrderNo=OrderNo,Recipient=new Recipient (){Name=Recipient.Name,Address=Recipient.Address,Phone=Recipient.Phone}};
       

        }
    }

    public class Recipient:ICloneable
    {     
        public string Name {get;set;}

        public string Address {get;set;}

        public string Phone{get;set;}

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}