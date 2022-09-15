using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace modbus_slave
{
    public partial class ChartLevelingUsingSpline : Form
    {
        public ChartLevelingUsingSpline()
        {
            InitializeComponent();
        }

        private void ChartLevelingUsingSpline_Load(object sender, EventArgs e)
        {
            StripLine sline = new StripLine();
            sline.IntervalOffset = 0.6;
            sline.StripWidth = 100;
            sline.Text = "Gold Status";
            sline.Interval = 0.0; // this ensures it will not repeat like normal strip lines
            sline.BackColor = Color.Yellow;
            StripLine asd = new StripLine();
            asd.IntervalOffset = 0.6;
            asd.StripWidth = 12;
            asd.Text = "asd asd";
            asd.Interval = 0.0; // this ensures it will not repeat like normal strip lines
            asd.BackColor = Color.Red;
            this.chart1.Titles.Add("Sales");
            chart1.ChartAreas[0].AxisY.StripLines.Add(sline);
            chart1.ChartAreas[0].AxisY.StripLines.Add(asd);
            chart1.Series[0].Points.AddXY("John", 98);
            chart1.Series[0].Points.AddXY("John", 23);
            chart1.Series[0].Points.AddXY("John", 56);
            chart1.Series[0].Points.AddXY("John", 34);
            chart1.Series[0].Points.AddXY("John", 36);
        }
        Point? prevPosition = null;
        ToolTip tooltip = new ToolTip();

        public object Thred { get; private set; }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
          
        }

        private void chart1_MouseDown(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            if (prevPosition.HasValue && pos == prevPosition.Value)
                return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = chart1.HitTest(pos.X, pos.Y, false, ChartElementType.DataPoint); // set ChartElementType.PlottingArea for full area, not only DataPoints
            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.DataPoint) // set ChartElementType.PlottingArea for full area, not only DataPoints
                {
                    var yVal = result.ChartArea.AxisY.PixelPositionToValue(pos.Y);
                    tooltip.Show(((int)yVal).ToString(), chart1, pos.X, pos.Y - 15);
                }
            }
        }

        class key
        {
            public string test { get; set; }
        }

        private void ChartLevelingUsingSpline_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                key key = new key()
                {
                    test = "Halo berhasil loh"
                };
                string url = $"http://192.168.1.40:8000/api/test";
                var json = JsonConvert.SerializeObject(key);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var task = Task.Run(async () =>
                {
                    using (HttpResponseMessage message = await client.PostAsync(url, data))
                    {
                        if (message.IsSuccessStatusCode)
                        {   
                            Console.WriteLine("Berhasil boy");
                        }
                        else
                        {
                            Console.WriteLine("HAh");
                        }
                    }
                });
                task.Wait();
            }
        }
    }
}
