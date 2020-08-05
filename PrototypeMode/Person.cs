using System;

namespace PrototypeMode
{
    public class Person:ICloneable
    {
        public string Name{get;set;}

        public int Age{get;set;}

        public Gender Gender { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }

    public enum Gender
    {
        女=0,
        男=1,
        未知=2
    }
}