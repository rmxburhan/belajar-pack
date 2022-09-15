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
    public partial class Algoritma : Form
    {
        public Algoritma()
        {
            InitializeComponent();
            numericUpDown1.Controls[0].Visible = false;
            numericUpDown2.Controls[0].Visible = false;
        }

        private void Algoritma_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            if (ports.Length > 0)
            {
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(ports);
                comboBox1.SelectedIndex = 0;
            }
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 537:
                    string[] ports = SerialPort.GetPortNames();
                    if (ports.Length > 0)
                    {
                        comboBox1.Items.Clear();
                        comboBox1.Items.AddRange(ports);
                        comboBox1.SelectedIndex = 0;
                    }
                    else
                    {
                        comboBox1.Text = "";
                        comboBox1.Items.Clear();
                    }
                    break;
            }
            base.WndProc(ref m);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialPort1.PortName = comboBox1.SelectedItem.ToString();
            serialPort1.BaudRate = 9600;
            serialPort1.Open();
            progressBar1.Value = 100;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            progressBar1.Value = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            serialPort1.Write("REQ,*");
        }

        private delegate void SetPwm(string data);
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string hola = serialPort1.ReadLine();
            this.BeginInvoke(new SetPwm(si_datareceived), new object[] { hola });
        }

        private void si_datareceived(string data)
        {
            string[] datas = data.Split(',');
            double tekanan = Convert.ToDouble(datas[0]);
            double pwm = Convert.ToDouble(datas[1]);
            if (tekanan < 900)
            {
                serialPort1.Write($"setPWM,{pwm + 1},*");
                serialPort1.Write("REQ,*");
                return;
            }
            else if (tekanan > 1100)
            {
                serialPort1.Write($"setPWM,{pwm - 1},*");
                serialPort1.Write($"REQ,*");
                return;
            }
        }

        private void Algoritma_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("asdasdasdasd");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
