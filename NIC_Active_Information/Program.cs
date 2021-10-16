using System;
using System.Net;
using System.Management;
using System.Threading;

namespace NIC_Active_Information
{
    class Program
    {
        public static NetworkCardInfo nicInfo = new NetworkCardInfo(); //Creates a new networkcardinfo class

        static void Main(string[] args) //Mains method starts !!!
        {
            GetIpSubnetAndHostname(); //Calls the method for getting information about the active network cards
            PressToContinue(); //Calls a method to wait for a keypress before terminating the console
        }

        static void GetIpSubnetAndHostname() //Method starts for finding active network cards and getting their information
        {
            NetworkCardInfo.HostName = Dns.GetHostName(); //Gets the computer's name

            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration"); //getting network adapter configurations
            ManagementObjectCollection nics = mc.GetInstances(); //graps the network cards

            foreach (ManagementObject nic in nics) //runs though the network cards
            {
                if (Convert.ToBoolean(nic["IpEnabled"]) is true) //graps the info from the network card, if the card is active
                {
                    NetworkCardInfo.NicCardDescription = (nic["Description"] as string); //Gets the description of the network card
                    NetworkCardInfo.IpAddress = (nic["IPAddress"] as string[])[0]; //Gets the ipaddress of the network card
                    NetworkCardInfo.SubnetMask = (nic["IPSubnet"] as string[])[0]; //Gets the subnet mask of the network card

                    if (nic["DefaultIPGateway"] != null) //Gets the default-gateway of the network card
                    {
                        NetworkCardInfo.DefaultGateway = (nic["DefaultIPGateway"] as string[])[0];
                    }
                    else
                        NetworkCardInfo.DefaultGateway = "No defualt gateway";

                    if (nic["MACAddress"] != null) //Gets the mac-address of the network card
                    {
                        NetworkCardInfo.MacAddress = (nic["MACAddress"] as string);
                    }
                    else
                        NetworkCardInfo.MacAddress = "No MAC-Address for this network card.";

                    IpAndSubnetToBinary(); //Calls method for converting the ip and subnetmask into binary
                    WriteToConsole(); //Writes all the data for the network card
                }
            }
        }

        static void IpAndSubnetToBinary() //Method for converting the ip and subnet mask into binary
        {
            NetworkCardInfo.IpSplit = NetworkCardInfo.IpAddress.Split('.'); //Splits the ip into 4 octets
            NetworkCardInfo.IpSplitBinary = NetworkCardInfo.SubnetMask.Split('.'); //Splits the subnet mask into 4 octets

            for (int octet = 0; octet < NetworkCardInfo.IpSplit.Length; octet++) //Converts the ip address
            {
                NetworkCardInfo.IpSplitInt[octet] = Convert.ToInt32(NetworkCardInfo.IpSplit[octet]);
                NetworkCardInfo.IpSplitBinary[octet] = Convert.ToString(NetworkCardInfo.IpSplitInt[octet], 2).PadLeft(8, '0');
            }

            for (int octet = 0; octet < NetworkCardInfo.SubnetSplit.Length; octet++) //Converts the subnet mask
            {
                NetworkCardInfo.SubnetSplitInt[octet] = Convert.ToInt32(NetworkCardInfo.SubnetSplit[octet]);
                NetworkCardInfo.SubnetSplitBinary[octet] = Convert.ToString(NetworkCardInfo.SubnetSplitInt[octet], 2).PadLeft(8, '0');
            }
        }

        static void WriteToConsole() //Method for writeing the data to the console
        {
            if (NetworkCardInfo.HostWritten is false) //Checks if the titel has been written allready
            {
                WriteTheTitel($"Ip for active nic(s) on pc : {NetworkCardInfo.HostName}"); //Calling a method for "dramatic" writeing to the console
                Console.WriteLine("\n");
                NetworkCardInfo.HostWritten = true;
            }

            //Here i write the data to console
            Console.WriteLine("-------------------------------------------------------------------\n");
            Console.WriteLine($"Info for : {NetworkCardInfo.NicCardDescription}\n");
            Console.WriteLine($"IpAddress : {NetworkCardInfo.IpAddress}\nBinary form : {NetworkCardInfo.IpSplitBinary[0]}.{NetworkCardInfo.IpSplitBinary[1]}.{NetworkCardInfo.IpSplitBinary[2]}.{NetworkCardInfo.IpSplitBinary[3]}\n");
            Console.WriteLine($"Subnet mask : {NetworkCardInfo.SubnetMask}\nBinary form : {NetworkCardInfo.SubnetSplitBinary[0]}.{NetworkCardInfo.SubnetSplitBinary[1]}.{NetworkCardInfo.SubnetSplitBinary[2]}.{NetworkCardInfo.SubnetSplitBinary[3]}\n");
            Console.WriteLine($"Mac address : {NetworkCardInfo.MacAddress}\n");
            Console.WriteLine($"Default gateway : {NetworkCardInfo.DefaultGateway}\n");
        }

        public static void WriteTheTitel(string textTitle) //Method for writeing the title in a dramatic way >D
        {
            foreach (char character in textTitle)
            {
                Console.Write(character);
                if (character == ':')
                {
                    Thread.Sleep(460);
                }
                Thread.Sleep(40);
            }
            Thread.Sleep(600);
        }

        static void PressToContinue() //Method for waiting for a keypress before terminating the console app
        {
            Console.WriteLine("-------------------------------------------------------------------\n");
            Console.Write("Press to continue...");
            Console.ReadKey();
        }
    }
}