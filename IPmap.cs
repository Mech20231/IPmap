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
        public static void Parse(string[] params) // allowing both x.x.x.x/y and x.x.x.x, y input.
        {
            switch (params.length)
            {
                case 0:
                    break; // Need to throw an exception here. I don't know the name of the exception to use
                case 1: // The user inputted x.x.x.x/y notation.

                case 2: // The user inputted x.x.x.x, y notation.
                    try
                    {
                        string[] addressOctetsStrings = params.Split('.');
                        int[] addressOctets = Array.ConvertAll(addressOctetsStrings, int.Parse);
                        foreach (int  octet in addressOctets)
                        {
                            address = (addressOctets << 8) | (uint)octet;
                        }
                        /*
                        uint mask = cidr == 0
                            ? 0
                            : uint.MaxValue << (32 - cidr); */ // This is to create a mask from the CIDR to be used for formatting the potential ip address into the proper ip network. It is done below with just bitwise shifting.
                        
                        

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e)
                    }
            }

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
