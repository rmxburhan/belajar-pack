using Modbus.Device;
using Modbus.Utility;
using Modbus.Data;
using Modbus.IO;
using Modbus.Message;
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
    public partial class FrmHome : Form
    {
        public static serial serial = new serial();
        public FrmHome()
        {
            InitializeComponent();
        }

        private void FrmHome_Load(object sender, EventArgs e)
        {
            string[] portName = SerialPort.GetPortNames();
            cbxPort.Items.AddRange(portName);
            cbxPort.SelectedIndex = 0;
            labelPort.Text = "";
            btnDisconnect.Enabled = false;
            btnStop.Enabled = false;
        }
        string port;
        private void cbxPort_SelectedValueChanged(object sender, EventArgs e)
        {
            port = cbxPort.SelectedItem.ToString();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (cbxPort.SelectedItem.ToString() != "")
            {
                if (serialPort1.IsOpen)
                {
                    MessageBox.Show("Port is already open");
                }
                else
                {
                    try
                    {
                        serialPort1.PortName = cbxPort.SelectedItem.ToString();
                        serialPort1.BaudRate = 9600;
                        serialPort1.Open();
                        btnDisconnect.Enabled = true;
                        btnConnect.Enabled = false;
                        labelPort.Text = cbxPort.SelectedItem.ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("pilih port");
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                btnDisconnect.Enabled = false;
                btnConnect.Enabled = true;
                labelPort.Text = "";
            }
            else
            {
                MessageBox.Show("Port is not closed");
            }
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            if (serialPort1.IsOpen)
            {
                try
                {
                    byte slaveAddress = Convert.ToByte(txtSleveId.Text);
                    ushort startAddress = Convert.ToUInt16(txtStartAddress.Text);
                    ushort numberOfPoints = Convert.ToUInt16(txtQuantity.Text);

                    IModbusMaster masterRTU = ModbusSerialMaster.CreateRtu(serialPort1);
                    ushort[] ushortArray = masterRTU.ReadHoldingRegisters(slaveAddress, startAddress, numberOfPoints);
                    List<EntitySleve> list = new List<EntitySleve>();
                    for (int i = 0; i < ushortArray.Length; i++)
                    {
                        list.Add(new EntitySleve
                        {
                            Registers = i.ToString(),
                            Value = ushortArray[i].ToString()
                        });
                    }
                    BindingSource bs = new BindingSource();
                    bs.DataSource = list;
                    dataGridView1.DataSource = bs;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Quantity salah", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    timer1.Stop();
                }
            }
            timer1.Start();
        }
      
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            if (btnConnect.Enabled == false)
            {
                timer1.Stop();
            }
            if (serialPort1.IsOpen)
            {
                try
                {
                    byte slaveAddress = Convert.ToByte(textBox2.Text);
                    ushort startAddress = Convert.ToUInt16(textBox3.Text);
                    ushort data = Convert.ToUInt16(textBox4.Text);
                    IModbusMaster masterRTU = ModbusSerialMaster.CreateRtu(serialPort1);
                    masterRTU.WriteSingleRegister(slaveAddress, startAddress, data);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Quantity salah", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    timer1.Stop();
                }
            }
            if (btnConnect.Enabled == false)
            {
                timer1.Start();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                if (txtSleveId.Text != "" && txtQuantity.Text != "" && txtStartAddress.Text != "")
                {
                    timer1.Start();
                    btnStart.Enabled = false;
                    btnStop.Enabled = true;
                    txtSleveId.ReadOnly = true;
                    txtStartAddress.ReadOnly = true;
                    txtQuantity.ReadOnly = true;
                }
                else
                {
                    MessageBox.Show("Silahkan lengkapi data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Port belum tekoneksi", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                timer1.Stop();
                btnStart.Enabled = true;
                btnStop.Enabled = false;
                txtSleveId.ReadOnly = false;
                txtStartAddress.ReadOnly = false;
                txtQuantity.ReadOnly = false;
            }
            else
            {
                MessageBox.Show("Port belum tekoneksi", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
