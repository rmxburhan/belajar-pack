using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;

namespace modbus_slave
{
    public partial class FrmSuhu : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public FrmSuhu()
        {
            InitializeComponent();
        }

    
        private void FrmSuhu_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

    
        private void FrmSuhu_Load(object sender, EventArgs e)
        {
            int baud = 1200;
            for (int i = 0; i < 6; i++)
            {
                cbxBaudRate.Items.Add(baud.ToString());
                baud = baud * 2;
            }
            string[] port = SerialPort.GetPortNames();
            if (port.Length > 0)
            {
                cbxDaftarPort.Items.Clear();
                cbxDaftarPort.Items.AddRange(port);
                cbxDaftarPort.SelectedIndex = 0;
            }
            else
            {
                cbxDaftarPort.Items.Clear();
            }
            btnDisconnect.Enabled = false;
            btnConnect.Enabled = true;
            cbxBaudRate.SelectedIndex = 0;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (cbxBaudRate.Text.Trim() != "" && cbxDaftarPort.Text.Trim() != "")
            {
                try
                {
                    serialPort1.PortName = cbxDaftarPort.SelectedItem.ToString();
                    serialPort1.BaudRate = int.Parse(cbxBaudRate.SelectedItem.ToString());
                    serialPort1.Open();
                    cbxDaftarPort.Enabled = false;
                    cbxBaudRate.Enabled = false;
                    btnConnect.Enabled = false;
                    btnDisconnect.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Silahkan lengkapi semua data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Are you sure want to Quit", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                this.Close();
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            cbxBaudRate.Enabled = true;
            cbxDaftarPort.Enabled = true;
            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        string dataFromSerialPort;
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            dataFromSerialPort = serialPort1.ReadExisting();
            this.Invoke(new EventHandler(ShowData)); 
        }

        private void ShowData(object sender, EventArgs e)
        {
            try
            {
                string[] result = dataFromSerialPort.Split(',');
                labelSuhu.Text = result[0] + " °C";
                labelKelembaban.Text = result[1];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //protected override void WndProc(ref Message m)
        //{
        //    switch (m.Msg)
        //    {
        //        case 537: //WM_DEVICECHANGE
        //            string[] ports = SerialPort.GetPortNames();
        //            if (ports.Length > 0)
        //            {
        //                cbxDaftarPort.Items.Clear();
        //                cbxDaftarPort.Items.AddRange(ports);
        //            }
        //            else
        //            {
        //                cbxDaftarPort.Items.Clear();
        //            }

        //            break;
        //    }
        //    base.WndProc(ref m);
        //}

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 537:
                    string[] ports = SerialPort.GetPortNames();
                    if (ports.Length >0)
                    {
                        cbxDaftarPort.Items.Clear();
                        cbxDaftarPort.Items.AddRange(ports);
                    }
                    else
                    {
                        cbxDaftarPort.Items.Clear();
                    }
                    break;
            }
            base.WndProc(ref m);
        }

    }
}