using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace modbus_slave
{
    public partial class MQTTClient : Form
    {
        private MqttClient mqttClient;
        public MQTTClient()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (txtHost.Text != "" && txtTopic.Text != "")
            {
                Task.Run(() =>
                {
                    mqttClient = new MqttClient("127.0.0.1");
                    mqttClient.MqttMsgPublishReceived += MqttClient_MqttMsgPublishReceived;
                    mqttClient.Subscribe(new string[] { txtTopic.Text}, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
                    mqttClient.Connect(Guid.NewGuid().ToString());
                });
                txtHost.ReadOnly = true;
                txtTopic.ReadOnly = true;
                btnStop.Enabled = true;
                btnStart.Enabled = false;
                btnSend.Enabled = true;
                MessageBox.Show("Koneksi tersambung", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lengkapi host dan topic", "Error connect", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MqttClient_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            var message = Encoding.UTF8.GetString(e.Message);
            textBoxSub.Invoke((MethodInvoker)(() => textBoxSub.Text += message + " "));
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (txtHost.Text != "" && txtTopic.Text != "")
            {
                Task.Run(() =>
                {
                    mqttClient.Unsubscribe(new string[] { txtTopic.Text });
                    MessageBox.Show("Koneksi distop", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                });
                txtHost.ReadOnly = false;
                txtTopic.ReadOnly = false;
                btnStop.Enabled = false;
                btnStart.Enabled = true;
                btnSend.Enabled = false;
            }
            else
            {
                MessageBox.Show("Lengkapi host dan topic", "Error connect", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtHost.Text != "" && txtTopic.Text != "")
            {
                Task.Run(() =>
                {
                    if (mqttClient.IsConnected)
                    {
                        mqttClient.Publish("test", Encoding.UTF8.GetBytes(txtMessage.Text));
                        mqttClient.MqttMsgPublished += MqttClient_MqttMsgPublished;
                    }
                });
            }
            else
            {
                MessageBox.Show("Lengkapi host dan topic", "Error connect", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MqttClient_MqttMsgPublished(object sender, MqttMsgPublishedEventArgs e)
        {
            MessageBox.Show("Message berhasil dikirim");
        }
        private void MQTTClient_Load(object sender, EventArgs e)
        {
            btnStop.Enabled = false;
            btnSend.Enabled = true;
            btnSend.Enabled = false;
        }
    }
}
