using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class PackageSender
    {
        private CourierOrderer _orderer;
        private PackageWrapper _wrapper;
        private TransmissionPayer _payer;

        public PackageSender(CourierOrderer orderer, PackageWrapper wrapper, TransmissionPayer payer)
        {
            _orderer = orderer;
            _wrapper = wrapper;
            _payer = payer;
        }

        public void SendPackage()
        {
            Console.WriteLine(_orderer.OrderCourier());
            Console.WriteLine(_wrapper.WrapPackage());
            Console.WriteLine(_payer.PayForTransmission());
        }
    }

    public class TransmissionPayer
    {
        public string PayForTransmission()
        {
            return "Transmission payer: Transmission paid";
        }
    }

    public class PackageWrapper
    {
        public string WrapPackage()
        {
            return "Package wrapper: Package wrapped";
        }
    }

    public class CourierOrderer
    {
        public string OrderCourier()
        {
            return "Courier orderer: Courier ordered";
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            PackageSender sender = new PackageSender(new CourierOrderer(), new PackageWrapper(), new TransmissionPayer());

            sender.SendPackage();

            Console.ReadLine();
        }
    }
}
