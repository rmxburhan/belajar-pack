using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Security.Cryptography;

namespace modbus_slave
{
    public partial class asd : Form
    {
        public asd()
        {
            InitializeComponent();
        }
        public static string ProcessorID;
        private static string MACAddress;
        public string PublicKey { get; set; }

        private void asd_Load(object sender, EventArgs e)
        {
            GetProcessorID();
            getMacAdd();
            this.PublicKey = asd.PublicKeyGen(asd.TempKeyGen("b1n4ry"), "b1n4ry!@#");
            MessageBox.Show(ProcessorID + MACAddress);
            MessageBox.Show(PublicKey);
            Console.WriteLine(PublicKey);
        }


        public static void GetProcessorID()
        {
            // Evaluation version.
            ManagementObject managementObject;
            bool bl;
            ManagementClass managementClass = new ManagementClass("Win32_Processor");
            ManagementObjectCollection managementObjectCollection = managementClass.GetInstances();
            ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = managementObjectCollection.GetEnumerator();
            try
            {
                goto ILO_0062;
                ILO_001d:
                managementObject = managementObjectEnumerator.Current as ManagementObject;
                asd.ProcessorID = managementObject.Properties["ProcessorId"].Value.ToString();
                bl = !(asd.ProcessorID.Length > 0);
                if (bl)
                    goto ILO_0061;
                goto ILO_006e;
                ILO_0061:
                ILO_0062:
                bl = managementObjectEnumerator.MoveNext();
                if (bl)
                    goto ILO_001d;
                ILO_006e:
                goto ILO_0082;
            }
            finally
            {
                bl = managementObjectEnumerator == null;
                if (bl)
                    goto ILO_0081;
                managementObjectEnumerator.Dispose();
                ILO_0081:;
            }
            ILO_0082:
            return;
        }
        public static void getMacAdd()
        {
            // Evaluation version.
            ManagementClass managementClass = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection managementObjectCollection = managementClass.GetInstances();
            foreach (ManagementObject managementObject in managementObjectCollection)
            {
                if (managementObject["MacAddress"] != null)
                {
                    asd.MACAddress = managementObject["MacAddress"].ToString();
                    Console.WriteLine(managementObject["MacAddress"].ToString());
                    break;
                }
            }
        }

        public static string MD5(string password)
        {
            // Evaluation version.
            MD5CryptoServiceProvider mD5CryptoServiceProvider;
            byte[] arrbyt1;
            string str;
            byte byt;
            string str1 = "";
            byte[] arrbyt2;
            int i;
            bool bl;
            object obj;
            byte[] arrbyt = Encoding.Default.GetBytes(password);
            try
            {
                mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
                arrbyt1 = mD5CryptoServiceProvider.ComputeHash(arrbyt);
                str = "";
                arrbyt2 = arrbyt1;
                i = 0;
                goto ILO_0076;
                ILO_002b:
                byt = arrbyt2[i];
                bl = !(byt < 16);
                if (bl)
                    goto ILO_005c;
                str = string.Concat(str, "0", byt.ToString("x"));
                goto ILO_006f;
                ILO_005c:
                str = string.Concat(str, byt.ToString("x"));
                ILO_006f:
                i++;
                ILO_0076:
                bl = i < arrbyt2.Length;
                if (bl)
                    goto ILO_002b;
                str1 = str;
                goto ILO_008d;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            ILO_008d:
            return str1;
        }

        public static string TempKeyGen(string private_key)
        {
            // Evaluation version.
            string str = asd.MD5(asd.ProcessorID + asd.MACAddress + private_key);
            string[] arrstr = new string[] {str.Substring(0, 16).ToString(),
                    str.Substring(16, 16).ToString()};
            return arrstr[0].ToString() + arrstr[1].ToString() + asd.ProcessorID;
        }

        public static string PublicKeyGen(string tempkey, string private_key)
        {
            asd.GetProcessorID();
            string str = tempkey.Substring(16, 16).ToString();
            string[] arrstr = new string[4];
            string[] arrstr1 = new string[4];
            string str1 = asd.MD5(string.Concat(asd.ProcessorID, str, private_key));
            arrstr[0] = tempkey.Substring(0, 4).ToString();
            arrstr[1] = tempkey.Substring(4, 4).ToString();
            arrstr[2] = tempkey.Substring(8, 4).ToString();
            arrstr[3] = tempkey.Substring(12, 4).ToString();
            arrstr1[0] = str1.Substring(0, 8).ToString();
            arrstr1[1] = str1.Substring(8, 8).ToString();
            arrstr1[2] = str1.Substring(16, 8).ToString();
            arrstr1[3] = str1.Substring(24, 8).ToString();
            string[] arrstr2 = new string[8];
            arrstr2[0] = arrstr1[0].ToString();
            arrstr2[1] = arrstr[0].ToString();
            arrstr2[2] = arrstr1[1].ToString();
            arrstr2[3] = arrstr[1].ToString();
            arrstr2[4] = arrstr1[2].ToString();
            arrstr2[5] = arrstr[2].ToString();
            arrstr2[6] = arrstr1[3].ToString();
            arrstr2[7] = arrstr[3].ToString();
            string str2 = string.Concat(arrstr2);
            string str3 = str2;
            return str3;
        }
    }
}
