using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modbus_slave
{
    public class serial
    {
        public string message;
        SerialPort serialPort = new SerialPort();

        public serial()
        {
            this.serialPort.DataReceived += serialPort_DataReceived;
        }
        string[] data;
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            data = serialPort.ReadLine().Split(',');
            if (data[0] == "$GPGGA")
            {
            }
        }

        private async Task<double[]> kalkulasiGPS(string rawLat, string rawLng, string rawAlt)
        {
            double[] result = new double[3] { 0,0,0};
            try
            {
                
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return result;
            }
        }

        public bool openPort(string portName)
        {
            if (!serialPort.IsOpen)
            {
                serialPort.PortName = portName;
                serialPort.BaudRate = 9600;
                serialPort.DataBits = 8;
                serialPort.Parity = Parity.None;
                serialPort.Handshake = Handshake.None;
                serialPort.WriteTimeout = 1000;
                serialPort.ReadTimeout = 1000;
                try
                {
                    serialPort.Open();
                }
                catch (Exception ex)
                {
                    message = "Gagal membuka " + portName + $"\n{ex.Message}";
                    return false;
                }
                message = "Sukses";
                return true;
            }
            else
            {
                message = portName + " Already opened";
                return false;
            }
        }

        public bool Close()
        {
            if (serialPort.IsOpen)
            {
                try
                {
                    serialPort.Close();
                }
                catch (Exception ex)
                {
                    message  = "Error closing " + serialPort.PortName + ": " + ex.Message;
                    return false;
                }
                message = serialPort.PortName + " closed successfully";
                return true;
            }
            else
            {
                message = $"Port {serialPort.PortName} already closed";
                return false;
            }
        }


    }
}
