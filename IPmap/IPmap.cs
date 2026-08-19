using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IPmap
{
    using System;




    public class IPAddress
    {
        public uint Address { get; }
        public int CIDR { get; }
        public static void IPParse(string[] args)
        {

        }

        public IPAddress(string dottedDecimalAddress, int cidr)
        {

            string[] addressOctetsStrings = dottedDecimalAddress.Split('.');
            int[] addressOctets = Array.ConvertAll(addressOctetsStrings, int.Parse);
            uint address = 0b_00000000_00000000_00000000_00000000;
            foreach (int octet in addressOctets)
            {
                address = (address << 8) | (uint)octet;
            }
            Address = address;
            CIDR = cidr;

        }
    }


    public class IPmap
    {
        public static void Main()
        {
            Console.WriteLine("Enter network: ");
            string network = Console.ReadLine();
            Console.WriteLine("Enter cidr suffix: ");
            int cidr = int.Parse(Console.ReadLine());
            IPAddress root = new IPAddress(network, cidr);
            // Console.WriteLine(root.Address);
            Console.WriteLine($"Binary: {Convert.ToString(root.Address, toBase: 2)}");
        }

    }

}
