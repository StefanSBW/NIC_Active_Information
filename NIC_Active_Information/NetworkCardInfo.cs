namespace NIC_Active_Information
{
    class NetworkCardInfo
    {
        private static string hostName; //The device name
        private static string nicCardDescription; //Description for the network card <3
        private static string ipAddress; //The IPaddress for the network card
        private static string subnetMask; //Subnet mask for the network card
        private static string macAddress; //The physical address for the network card
        private static string defaultGateway; //The default gateway for the network card
        private static bool hostWritten = false; //Checkmark for writeing the titel to console

        private static string[] ipSplit = new string[4]; //String array for the ip splitted into octets
        private static int[] ipSplitInt = new int[4]; //Int array for the ip splitted and convertet into int
        private static string[] ipSplitBinary = new string[4]; //String array for the ip splitted into binary octets

        private static string[] subnetSplit = new string[4]; //String array for the subnet mask splitted into octets
        private static int[] subnetSplitInt = new int[4]; //Int array for the subnet splitted and convertet into int
        private static string[] subnetSplitBinary = new string[4]; //String array for the subnet mask splitted into binary octets

        public static string HostName //Getter and setter for the hostname of the computer
        {
            get { return hostName; }
            set { hostName = value; }
        }

        public static string NicCardDescription //Getter and setter for the description of the network card
        {
            get { return nicCardDescription; }
            set { nicCardDescription = value; }
        }

        public static string IpAddress //Getter and setter for the IPAddress of the network card
        {
            get { return ipAddress; }
            set { ipAddress = value; }
        }

        public static string SubnetMask //Getter and setter for the Subnet mask of the network card
        {
            get { return subnetMask; }
            set { subnetMask = value; }
        }

        public static string MacAddress //Getter and setter for the MAC-Address of the network card
        {
            get { return macAddress; }
            set { macAddress = value; }
        }

        public static string DefaultGateway //Getter and setter for the default-gateway of the network card
        {
            get { return defaultGateway; }
            set { defaultGateway = value; }
        }

        public static bool HostWritten //Getter and setter to check if the titel has been written to the console allready
        {
            get { return hostWritten; }
            set { hostWritten = value; }
        }

        public static string[] IpSplit //Getter and setter for the ip splitted array (datatype string)
        {
            get { return ipSplit; }
            set { ipSplit = value; }
        }

        public static int[] IpSplitInt //Getter and setter for the ip splitted array (datatype int)
        {
            get { return ipSplitInt; }
            set { ipSplitInt = value; }
        }

        public static string[] IpSplitBinary //Getter and setter for the ip splitted and binary form array (datatype string)
        {
            get { return ipSplitBinary; }
            set { ipSplitBinary = value; }
        }

        public static string[] SubnetSplit //Getter and setter for the subnetmask splitted array (datatype string)
        {
            get { return subnetSplit; }
            set { subnetSplit = value; }
        }

        public static int[] SubnetSplitInt //Getter and setter for the subnetmask splitted array (datatype int)
        {
            get { return subnetSplitInt; }
            set { subnetSplitInt = value; }
        }

        public static string[] SubnetSplitBinary //Getter and setter for the subnetmask splitted and binary form array (datatype string)
        {
            get { return subnetSplitBinary; }
            set { subnetSplitBinary = value; }
        }
    }
}
