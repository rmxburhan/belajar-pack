
namespace modbus_slave
{
    partial class MapWinGis
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapWinGis));
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2PictureBox4 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox5 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox6 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.axMap2 = new AxMapWinGIS.AxMap();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMap2)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(32)))), ((int)(((byte)(41)))));
            this.guna2Panel2.Controls.Add(this.guna2PictureBox6);
            this.guna2Panel2.Controls.Add(this.guna2PictureBox5);
            this.guna2Panel2.Location = new System.Drawing.Point(179, 326);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(142, 38);
            this.guna2Panel2.TabIndex = 1;
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.TargetControl = this.guna2Panel2;
            // 
            // guna2PictureBox4
            // 
            this.guna2PictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2PictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox4.FillColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox4.Image = global::modbus_slave.Properties.Resources.cursor1;
            this.guna2PictureBox4.ImageRotate = 0F;
            this.guna2PictureBox4.Location = new System.Drawing.Point(192, 331);
            this.guna2PictureBox4.Name = "guna2PictureBox4";
            this.guna2PictureBox4.Size = new System.Drawing.Size(35, 28);
            this.guna2PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox4.TabIndex = 0;
            this.guna2PictureBox4.TabStop = false;
            this.guna2PictureBox4.UseTransparentBackground = true;
            this.guna2PictureBox4.Click += new System.EventHandler(this.guna2PictureBox4_Click);
            // 
            // guna2PictureBox5
            // 
            this.guna2PictureBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2PictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox5.Image = global::modbus_slave.Properties.Resources.rectangle;
            this.guna2PictureBox5.ImageRotate = 0F;
            this.guna2PictureBox5.Location = new System.Drawing.Point(54, 5);
            this.guna2PictureBox5.Name = "guna2PictureBox5";
            this.guna2PictureBox5.Size = new System.Drawing.Size(35, 28);
            this.guna2PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox5.TabIndex = 2;
            this.guna2PictureBox5.TabStop = false;
            this.guna2PictureBox5.UseTransparentBackground = true;
            this.guna2PictureBox5.Click += new System.EventHandler(this.guna2PictureBox5_Click);
            // 
            // guna2PictureBox6
            // 
            this.guna2PictureBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2PictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox6.Image = global::modbus_slave.Properties.Resources.magnifying_glass;
            this.guna2PictureBox6.ImageRotate = 0F;
            this.guna2PictureBox6.Location = new System.Drawing.Point(90, 9);
            this.guna2PictureBox6.Name = "guna2PictureBox6";
            this.guna2PictureBox6.Size = new System.Drawing.Size(44, 22);
            this.guna2PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox6.TabIndex = 3;
            this.guna2PictureBox6.TabStop = false;
            this.guna2PictureBox6.UseTransparentBackground = true;
            // 
            // axMap2
            // 
            this.axMap2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMap2.Enabled = true;
            this.axMap2.Location = new System.Drawing.Point(0, 0);
            this.axMap2.Name = "axMap2";
            this.axMap2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMap2.OcxState")));
            this.axMap2.Size = new System.Drawing.Size(519, 385);
            this.axMap2.TabIndex = 0;
            // 
            // MapWinGis
            // 
            this.Controls.Add(this.guna2PictureBox4);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.axMap2);
            this.Name = "MapWinGis";
            this.Size = new System.Drawing.Size(519, 385);
            this.guna2Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMap2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxMapWinGIS.AxMap axMap1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox3;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private AxMapWinGIS.AxMap axMap2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox6;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox5;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox4;
    }
}
