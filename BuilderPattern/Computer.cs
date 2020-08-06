using System;

namespace BuilderPattern
{
    // public class Computer
    // {
    //     private string cpu;

    //     private string ram ;

    //     private int usbCount;

    //     public string keyboard;

    //     public string display;

    //     private Computer(Builder builder)
    //     {
    //         this.cpu=cpu;
    //         this.ram=ram;
    //         this.usbCount=usbCount;
    //         this.keyboard=keyboard;
    //         this.display=display;
    //     }

    //     public static class Builder
    //     {
    //         private string cpu;

    //         private string ram;

    //         private int usbCount;

    //         private string keyboard;

    //         private string display;

    //         public Builder(string cpu,string ram){
    //             this.cpu=cpu;
    //             this.ram=ram;
    //         }

    //         public Builder SetUsbCount(int usbCount)
    //         {
    //             this.usbCount=usbCount;
    //             return this;
    //         }

    //         public Builder SetKeyBoard(string keyboard){
    //             this.keyboard=keyboard;
    //             return this;
    //         }

    //         public Builder SetDisplay(string display)
    //         {
    //             this.display=display;
    //             return this;
    //         }

    //         public Computer builder(){
    //             return new Computer(this);
    //         }
    //     }
    // }  
}