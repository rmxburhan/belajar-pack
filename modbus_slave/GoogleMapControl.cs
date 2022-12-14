using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsPresentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMapMarker = GMap.NET.WindowsForms.GMapMarker;

namespace modbus_slave
{
    public partial class GoogleMapControl : UserControl
    {
        public GMapProvider gMapProvider { get; private set; }
        public GoogleMapControl()
        {
            InitializeComponent();
        }

        private void GoogleMapControl_Load(object sender, EventArgs e)
        {
            try
            {
                map.MapProvider = GMapProviders.GoogleMap;
                map.MinZoom = 5;
                map.MaxZoom = 20;
                map.Zoom = 10;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void map_Load(object sender, EventArgs e)
        {
            try
            {
                double lat = -6.967416454078821;
                double lng = 107.65888617752144;
                map.Position = new PointLatLng(lat, lng);
                PointLatLng pointLatLng = new PointLatLng(lat, lng);
                GMapMarker marker = new GMarkerGoogle(pointLatLng, GMarkerGoogleType.red_dot);

                GMapOverlay markers = new GMapOverlay("PT. Makerindo");
                markers.Markers.Add(marker);
                map.Overlays.Clear();
                map.Overlays.Add(markers);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
