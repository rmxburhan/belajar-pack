using System;
using System.Windows.Forms;

namespace modbus_slave
{
    public partial class MapWinGis : UserControl
    {
        public MapWinGis()
        {
            InitializeComponent();
        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox5_Click(object sender, EventArgs e)
        {
            axMap2.CursorMode = MapWinGIS.tkCursorMode.cmMeasure;
            axMap2.Measuring.MeasuringType = MapWinGIS.tkMeasuringType.MeasureArea;
        }
    }
}
