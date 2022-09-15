using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
namespace modbus_slave
{
    public partial class mapParser : Form
    {
        bool bacaMap = false;
        public mapParser()
        {
            InitializeComponent();
        }

        private void mapParser_Load(object sender, EventArgs e)
        {
            timer1.Start();
            string[] dataPort = SerialPort.GetPortNames();
            if (dataPort.Length > 0)
            {
                cbxDaftartPott.Items.AddRange(dataPort);
                cbxDaftartPott.SelectedIndex = 0;
            }
            else
            {
                cbxDaftartPott.Items.Clear();
            }
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 537:
                    string[] dataPort = SerialPort.GetPortNames();
                    if (dataPort.Length > 0)
                    {
                        cbxDaftartPott.Items.AddRange(dataPort);
                        cbxDaftartPott.SelectedIndex = 0;
                    }
                    else
                    {
                        cbxDaftartPott.Items.Clear();
                    }
                    break;
            }
            base.WndProc(ref m);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = cbxDaftartPott.SelectedItem.ToString();
                serialPort1.BaudRate = 9600;
                Task.Run(() =>
                {
                    serialPort1.Open();
                    serialPort1.DiscardInBuffer();
                    serialPort1.DataReceived += serialPort1_DataReceived;
                });
                    //timer1.Start();
           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            //await Task.Run(() =>
            //{
            //     this.serialPort1.DataReceived -= this.serialPort1_DataReceived;
            //    if (serialPort1.BytesToRead > 0)
            //    {
            //        while (serialPort1.BytesToRead > 0)
            //        {
            //            Console.WriteLine("Asd");
            //            if (serialPort1.BytesToRead < 1)
            //            {
            //                serialPort1.Close();
            //            }
            //            Thread.Sleep(5);
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("tutup aja");
            //        serialPort1.Close();
            //    }
            //});
            serialPort1.DataReceived -= serialPort1_DataReceived;
            Thread.Sleep(1000);
            serialPort1.DiscardInBuffer();
            Thread.Sleep(1000);
            serialPort1.Close();
            //timer1.Stop();
        }
        string data;
        private delegate void SetTextDeleg(string text);
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //try
            //{
            //    Thread.Sleep(500);
            //    string data = serialPort1.ReadLine();
            //    // Invokes the delegate on the UI thread, and sends the data that was received to the invoked method.  
            //    // ---- The "si_DataReceived" method will be executed on the UI thread which allows populating of the textbox.  
            //    this.BeginInvoke(new SetTextDeleg(si_DataReceived), new object[] { data });
            //}
            //catch (Exception c)
            //{
            //}
            //Thread.Sleep(500);
            if (bacaMap == true)
            {
                try
                {
                    data = serialPort1.ReadLine();
                    string[] halo = data.Split(',');
                    if (halo[0] == "$GPGGA")
                    {
                        this.Invoke(new EventHandler(ShowGPS));
                    }
                    bacaMap = false;
                }
                catch (Exception)
                {
                }
            }
           
        }
        string latitudeResult, longituderesult;
        private void ShowGPS(object sender, EventArgs e)
        {
            string[] asd = data.Split(',');
            Console.WriteLine(data);
            try
            {
                if (asd[0] == "$GPGGA")
                {
                    double latitude = Convert.ToDouble(asd[2]);
                    double longitude = Convert.ToDouble(asd[4]);
                    Console.WriteLine();
                    int derajatLatitudeReal = (int)(latitude / 100);
                    double detikLatitudeReal = latitude - derajatLatitudeReal * 100;

                    double latitudeReal = derajatLatitudeReal + (detikLatitudeReal / 60);

                    int derajatLongitudeReal = (int)(longitude / 100);
                    double detikLongitudeReal = longitude - derajatLongitudeReal * 100;
                    double longitudeReal = derajatLongitudeReal + (detikLongitudeReal / 60);

                    if (asd[3] == "S")
                    {
                        latitudeResult = "-" + latitudeReal.ToString();
                    }
                    else
                    {
                        latitudeResult = latitudeReal.ToString();
                    }

                    if (asd[5] == "W")
                    {
                        longituderesult = "-" + longitudeReal.ToString();
                    }
                    else
                    {
                        longituderesult = longitudeReal.ToString();
                    }
                    textBox1.Text = latitudeResult;
                    textBox2.Text = longituderesult;
                }
                else
                {
                }
            }
            catch (Exception ex)
            {

            }
         
        }

        string lat,lng;

        private void button2_Click(object sender, EventArgs e)
        {
                ManagementBaseObject mboShutdown = null;
                ManagementClass mcWin32 = new ManagementClass("Win32_OperatingSystem");
                mcWin32.Get();

                // You can't shutdown without security privileges
                mcWin32.Scope.Options.EnablePrivileges = true;
                ManagementBaseObject mboShutdownParams =
                         mcWin32.GetMethodParameters("Win32Shutdown");

                // Flag 1 means we want to shut down the system. Use "2" to reboot.
                mboShutdownParams["Flags"] = "1";
                mboShutdownParams["Reserved"] = "0";
                foreach (ManagementObject manObj in mcWin32.GetInstances())
                {
                    mboShutdown = manObj.InvokeMethod("Win32Shutdown",
                                                   mboShutdownParams, null);
                }
        }

        private void si_DataReceived(string data)
        {
            string[] strArr = data.Split('$');
            for (int i = 0; i < strArr.Length; i++)
            {
                string strTemp = strArr[i];
                string[] lineArr = strTemp.Split(',');
                Console.WriteLine(lineArr[0]);
                if (lineArr[0] == "GPGGA")
                {
                    Console.WriteLine(strTemp);
                    try
                    {

                        //Latitude
                        Double dLat = Convert.ToDouble(lineArr[2]);
                        dLat = dLat / 100;
                        string[] lata = dLat.ToString().Split('.');
                        Console.WriteLine("lat : " + lata[1]);
                        Console.WriteLine(lineArr[3].ToString());
                        String Latitude = (lineArr[3].ToString() == "S" ? "-" : "") +
                        lata[0].ToString() + "." +
                        ((Convert.ToDouble(lata[1]) /
                        60)).ToString("#######");

                        Console.WriteLine(Latitude);
                        //Longitude
                        Double dLon = Convert.ToDouble(lineArr[4]);
                        dLon = dLon / 100;
                        string[] lon = dLon.ToString().Split('.');
                        String Longitude = (lineArr[5].ToString() == "E" ? "" : "-") +
                        lon[0].ToString() + "." +
                        ((Convert.ToDouble(lon[1]) /
                        60)).ToString("#####");

                        lat = Latitude;
                        lng = Longitude;
                        Console.WriteLine("inilat " + Latitude + " " + Longitude);

                        //query = "select lat,lng,alt from nodes1";
                        //DataSet ds = fn.getData(query);
                        //lat = ds.Tables[0].Rows[0][0].ToString();
                        //lng = ds.Tables[0].Rows[0][1].ToString();
                        //alt = ds.Tables[0].Rows[0][2].ToString();

                            textBox1.Text = Latitude;
                            textBox2.Text = Longitude;
                       
                    }
                    catch
                    {
                        //Cannot Read GPS values\
                        Console.WriteLine("GPS Unavailable");
                        //return;
                    }
                }
                else
                {
                    //return;
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            //Console.WriteLine(serialPort1.IsOpen);
            bacaMap = true;
        }
    }
}
