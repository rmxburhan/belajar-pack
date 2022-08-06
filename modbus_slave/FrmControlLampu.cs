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
    public partial class FrmControlLampu : Form
    {
        public FrmControlLampu()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void FrmSuhuKelembabanModbus_Load(object sender, EventArgs e)
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
            }
            else
            {
                cbxDaftarPort.Items.Clear();
            }
            btnDisconnect.Enabled = false;
            btnConnect.Enabled = true;
            cbxDaftarPort.SelectedIndex = 0;
            cbxBaudRate.SelectedIndex = 0;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Are you sure want to Quit", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                this.Close();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxDaftarPort.Text != "" && cbxBaudRate.Text != "")
                {

                    serialPort1.PortName = cbxDaftarPort.SelectedItem.ToString();
                    serialPort1.BaudRate = Convert.ToInt32(cbxBaudRate.SelectedItem.ToString());
                    serialPort1.Open();
                    cbxDaftarPort.Enabled = false;
                    cbxBaudRate.Enabled = false;
                    btnConnect.Enabled = false;
                    btnDisconnect.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Lengkapi semua data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                    cbxDaftarPort.Enabled = true;
                    cbxBaudRate.Enabled = true;
                    btnConnect.Enabled = true;
                    btnDisconnect.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Serial port belum terkoneksi","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2ToggleSwitch1_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                if (guna2ToggleSwitch1.Checked)
                {
                    labelStatusLampu.Text = "ON";
                    serialPort1.Write("1");
                }
                else
                {
                    labelStatusLampu.Text = "OFF";
                    serialPort1.Write("0");
                }
            }
            else
            {
                MessageBox.Show("Port belum terkoneksi", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2ToggleSwitch1.Checked = false;
            }
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 537: //WM_DEVICECHANGE
                    string[] ports = SerialPort.GetPortNames();
                    if (ports.Length > 0)
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
