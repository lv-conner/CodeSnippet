using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippet.DesignPattern
{

    public interface IUSB
    {
        string Read();
        void Write();
    }
    public interface ISATA
    {
        string Read();
        void Write();
    }

    public interface ISATAToUSBAdapter:IUSB
    {
        ISATA SATA { get; }
    }

    public class SATAToUSBAdapter : ISATAToUSBAdapter
    {
        private ISATA _sata;
        public SATAToUSBAdapter(ISATA sata)
        {
            _sata = sata;
        }

        public ISATA SATA => _sata;

        public string Read()
        {
            return SATA.Read();
        }

        public void Write()
        {
            SATA.Write();
        }
    }

    public class SATADisk : ISATA
    {
        public string Read()
        {
            return "Read from sata hard disk";
        }

        public void Write()
        {
            Console.WriteLine("Write to sata disk");
        }
    }


    public class Computer
    {
        public IUSB USB { get; set; }
        public void PortUsb(IUSB usb)
        {
            USB = usb;
        }
        public string ReadUsb()
        {
            return USB.Read();
        }

        public void WriteUsb()
        {
            USB.Write();
        }
    }

    class AdapterSimple
    {
        static void Test()
        {
            var computer = new Computer();
            computer.PortUsb(new SATAToUSBAdapter(new SATADisk()));
            computer.ReadUsb();
            computer.WriteUsb();
        }
    }
}
