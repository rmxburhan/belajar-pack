using Modbus.Device;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace modbus_slave
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnDisconnect.Enabled = false;
            txtRegister.Enabled = false;
            txtValue.Enabled = false;
            btnRead.Enabled = false;
            txtSlave.Enabled = false;
            txtWriteRegister.Enabled = false;
            btnWrite.Enabled = false;
            btnStop.Enabled = false;
        }
        TcpClient client;
        ModbusIpMaster master;
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (txtTcp.Text != "" && txtPort.Text != "")
            {
                client = new TcpClient();
                client.BeginConnect(txtTcp.Text, int.Parse(txtPort.Text), null, null);
                master = ModbusIpMaster.CreateIp(client);
                txtTcp.Enabled = false;
                txtPort.Enabled = false;
                btnConnect.Enabled = false;
                btnDisconnect.Enabled = true;
                txtRegister.Enabled = true;
                txtValue.Enabled = true;
                btnRead.Enabled = true;
                txtSlave.Enabled = true;
                txtWriteRegister.Enabled = true;
                btnWrite.Enabled = true;
                btnStop.Enabled = true;
                progressBar1.Value = 100;
                s.Text = "ON";
            }
            else
            {
                MessageBox.Show("Lengkapi semua data");
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            client.Close();
            txtTcp.Enabled = true;
            txtPort.Enabled = true;
            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
            txtRegister.Enabled = false;
            txtValue.Enabled = false;
            btnRead.Enabled = false;
            txtSlave.Enabled = false;
            txtWriteRegister.Enabled = false;
            btnWrite.Enabled = false;
            btnStop.Enabled = false;
            progressBar1.Value = 0;
            s.Text = "OFF";
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (btnDisconnect.Enabled == true)
            {
                timer1.Stop();
            }
            try
            {
                if (txtRegister.Text != "")
                {
                    ushort startRef = Convert.ToUInt16(txtRegister.Text);
                    ushort noOfRef = 1;

                    ushort[] outputRegisterValue = master.ReadHoldingRegisters(1, startRef, noOfRef);
                    List<EntitySleve> list = new List<EntitySleve>();
                    for (int i = 0; i < outputRegisterValue.Length; i++)
                    {
                        list.Add(new EntitySleve
                        {
                            Registers = startRef.ToString(),
                            Value = outputRegisterValue[i].ToString()
                        });
                    }
                    BindingSource bs = new BindingSource();
                    bs.DataSource = list;
                    dataGridView1.DataSource = bs;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (btnDisconnect.Enabled == true)
            {
                timer1.Start();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            try
            {
                byte slaveAddress = Convert.ToByte(txtSlave.Text);
                ushort startRef = Convert.ToUInt16(txtWriteRegister.Text);
                ushort value = Convert.ToUInt16(txtValue.Text);
                master.WriteSingleRegister(slaveAddress, startRef, value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
