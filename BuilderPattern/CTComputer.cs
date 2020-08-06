using System;

namespace BuilderPattern
{
    //目标Computer类
    public class CTComputer
    {
        private string cpu;

        private string ram;

        private int usbCount;

        private string keyBoard;

        private string display;

        public CTComputer(string cpu,string ram){
            this.cpu=cpu;
            this.ram=ram;
        }

        public void setUsbCount(int usbCount)
        {
            this.usbCount=usbCount;
        }

        public void setkeyBoard(string keyBoard)
        {
            this.keyBoard=keyBoard;
        }

        public void setDisplay(string display)
        {
            this.display=display;
        }

        public override string ToString(){
            return $"{this.cpu}-{this.ram}-{this.usbCount}-{this.keyBoard}-{this.display}";
        }
    }

    //抽象构建者类
    public abstract class CTComputerBuilder{
        public abstract void SetUsbCount();
        public abstract void SetKeyBoard();
        public abstract void SetDisplay();

        public abstract CTComputer GetComputer();
    }

    public class MacComputerBuilder :CTComputerBuilder{
        private CTComputer computer;

        public MacComputerBuilder (string cpu,string ram){
            computer=new CTComputer(cpu,ram);
        }

        public override void SetUsbCount(){
            computer.setUsbCount(1);
        }

        public override void SetKeyBoard(){
            computer.setkeyBoard("苹果键盘");
        }

        public override void SetDisplay(){
            computer.setDisplay("苹果显示器");
        }

        public override CTComputer GetComputer(){
            return computer;
        }
    }

    public class LenovoComputerBuilder :CTComputerBuilder{
         private CTComputer computer;

        public LenovoComputerBuilder (string cpu,string ram)
        {
            computer=new CTComputer(cpu,ram);
        }

        public override void SetUsbCount(){
            computer.setUsbCount(2);
        }

        public override void SetKeyBoard(){
            computer.setkeyBoard("联想键盘");
        }

        public override void SetDisplay(){
            computer.setDisplay("联想显示器");
        }

        public override CTComputer GetComputer(){
            return computer;
        }
    }

    // 指导者类 Director

    public class ComputerDirector{
        public void MakeComputer(CTComputerBuilder builder)
        {
            builder.SetUsbCount();
            builder.SetKeyBoard();
            builder.SetDisplay();
        }
    }


}