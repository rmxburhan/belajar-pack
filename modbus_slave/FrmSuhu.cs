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

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmSuhu_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

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
            cbxDaftarPort.Items.AddRange(port);
            btnDisconnect.Enabled = false;
            btnConnect.Enabled = true;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                cbxDaftarPort.Enabled = false;
                cbxBaudRate.Enabled = false;
                btnConnect.Enabled = false;
                btnDisconnect.Enabled = true;
                serialPort1.PortName = cbxDaftarPort.SelectedItem.ToString();
                serialPort1.BaudRate = int.Parse(cbxBaudRate.SelectedItem.ToString());
                serialPort1.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            cbxBaudRate.Enabled = true;
            cbxDaftarPort.Enabled = true;
            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
            serialPort1.Close();
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
                labelSuhu.Text = result[1] + " °C";
                labelKelembaban.Text = result[2];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
