
namespace modbus_slave
{
    partial class MapsForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.panelControl = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.minimizeBox = new Guna.UI2.WinForms.Guna2ControlBox();
            this.closeBox = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2TabControl1 = new Guna.UI2.WinForms.Guna2TabControl();
            this.mapGoogle = new System.Windows.Forms.TabPage();
            this.googleMapControl1 = new modbus_slave.GoogleMapControl();
            this.mapBing = new System.Windows.Forms.TabPage();
            this.mapOpenStreetMap = new System.Windows.Forms.TabPage();
            this.openStreetMapControl1 = new modbus_slave.OpenStreetMapControl();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.bingControl1 = new modbus_slave.BingControl();
            this.panelControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.guna2TabControl1.SuspendLayout();
            this.mapGoogle.SuspendLayout();
            this.mapBing.SuspendLayout();
            this.mapOpenStreetMap.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.panelControl;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // panelControl
            // 
            this.panelControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(32)))), ((int)(((byte)(41)))));
            this.panelControl.Controls.Add(this.guna2PictureBox1);
            this.panelControl.Controls.Add(this.minimizeBox);
            this.panelControl.Controls.Add(this.closeBox);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl.Location = new System.Drawing.Point(0, 0);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(701, 50);
            this.panelControl.TabIndex = 1;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::modbus_slave.Properties.Resources.pp;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(12, 12);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(33, 29);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 2;
            this.guna2PictureBox1.TabStop = false;
            // 
            // minimizeBox
            // 
            this.minimizeBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimizeBox.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.minimizeBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.minimizeBox.HoverState.FillColor = System.Drawing.Color.DimGray;
            this.minimizeBox.IconColor = System.Drawing.Color.White;
            this.minimizeBox.Location = new System.Drawing.Point(593, 12);
            this.minimizeBox.Name = "minimizeBox";
            this.minimizeBox.Size = new System.Drawing.Size(45, 29);
            this.minimizeBox.TabIndex = 1;
            // 
            // closeBox
            // 
            this.closeBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.closeBox.HoverState.FillColor = System.Drawing.Color.Red;
            this.closeBox.IconColor = System.Drawing.Color.White;
            this.closeBox.Location = new System.Drawing.Point(644, 12);
            this.closeBox.Name = "closeBox";
            this.closeBox.Size = new System.Drawing.Size(45, 29);
            this.closeBox.TabIndex = 0;
            // 
            // guna2TabControl1
            // 
            this.guna2TabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.guna2TabControl1.Controls.Add(this.mapGoogle);
            this.guna2TabControl1.Controls.Add(this.mapBing);
            this.guna2TabControl1.Controls.Add(this.mapOpenStreetMap);
            this.guna2TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2TabControl1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TabControl1.ItemSize = new System.Drawing.Size(180, 40);
            this.guna2TabControl1.Location = new System.Drawing.Point(0, 0);
            this.guna2TabControl1.Name = "guna2TabControl1";
            this.guna2TabControl1.SelectedIndex = 0;
            this.guna2TabControl1.Size = new System.Drawing.Size(701, 400);
            this.guna2TabControl1.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.guna2TabControl1.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.guna2TabControl1.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.guna2TabControl1.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.guna2TabControl1.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.guna2TabControl1.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.guna2TabControl1.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
            this.guna2TabControl1.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.guna2TabControl1.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.guna2TabControl1.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.guna2TabControl1.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.guna2TabControl1.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.guna2TabControl1.TabButtonSize = new System.Drawing.Size(180, 40);
            this.guna2TabControl1.TabIndex = 0;
            this.guna2TabControl1.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            // 
            // mapGoogle
            // 
            this.mapGoogle.Controls.Add(this.googleMapControl1);
            this.mapGoogle.Location = new System.Drawing.Point(184, 4);
            this.mapGoogle.Name = "mapGoogle";
            this.mapGoogle.Padding = new System.Windows.Forms.Padding(3);
            this.mapGoogle.Size = new System.Drawing.Size(513, 392);
            this.mapGoogle.TabIndex = 0;
            this.mapGoogle.Text = "Google";
            this.mapGoogle.UseVisualStyleBackColor = true;
            // 
            // googleMapControl1
            // 
            this.googleMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.googleMapControl1.Location = new System.Drawing.Point(3, 3);
            this.googleMapControl1.Name = "googleMapControl1";
            this.googleMapControl1.Size = new System.Drawing.Size(507, 386);
            this.googleMapControl1.TabIndex = 0;
            // 
            // mapBing
            // 
            this.mapBing.Controls.Add(this.bingControl1);
            this.mapBing.Location = new System.Drawing.Point(184, 4);
            this.mapBing.Name = "mapBing";
            this.mapBing.Padding = new System.Windows.Forms.Padding(3);
            this.mapBing.Size = new System.Drawing.Size(513, 392);
            this.mapBing.TabIndex = 1;
            this.mapBing.Text = "Bing";
            this.mapBing.UseVisualStyleBackColor = true;
            // 
            // mapOpenStreetMap
            // 
            this.mapOpenStreetMap.Controls.Add(this.openStreetMapControl1);
            this.mapOpenStreetMap.Location = new System.Drawing.Point(184, 4);
            this.mapOpenStreetMap.Name = "mapOpenStreetMap";
            this.mapOpenStreetMap.Size = new System.Drawing.Size(513, 392);
            this.mapOpenStreetMap.TabIndex = 3;
            this.mapOpenStreetMap.Text = "Open Street Map";
            this.mapOpenStreetMap.UseVisualStyleBackColor = true;
            this.mapOpenStreetMap.Click += new System.EventHandler(this.mapOpenStreetMap_Click);
            // 
            // openStreetMapControl1
            // 
            this.openStreetMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openStreetMapControl1.Location = new System.Drawing.Point(0, 0);
            this.openStreetMapControl1.Name = "openStreetMapControl1";
            this.openStreetMapControl1.Size = new System.Drawing.Size(513, 392);
            this.openStreetMapControl1.TabIndex = 2;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Controls.Add(this.guna2TabControl1);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 50);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(701, 400);
            this.guna2Panel2.TabIndex = 2;
            // 
            // bingControl1
            // 
            this.bingControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bingControl1.Location = new System.Drawing.Point(3, 3);
            this.bingControl1.Name = "bingControl1";
            this.bingControl1.Size = new System.Drawing.Size(507, 386);
            this.bingControl1.TabIndex = 0;
            // 
            // MapsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 450);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.panelControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MapsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MapsForm";
            this.panelControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.guna2TabControl1.ResumeLayout(false);
            this.mapGoogle.ResumeLayout(false);
            this.mapBing.ResumeLayout(false);
            this.mapOpenStreetMap.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2TabControl guna2TabControl1;
        private System.Windows.Forms.TabPage mapGoogle;
        private System.Windows.Forms.TabPage mapBing;
        private Guna.UI2.WinForms.Guna2Panel panelControl;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.TabPage mapOpenStreetMap;
        private Guna.UI2.WinForms.Guna2ControlBox minimizeBox;
        private Guna.UI2.WinForms.Guna2ControlBox closeBox;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private GoogleMapControl googleMapControl1;
        private OpenStreetMapControl openStreetMapControl1;
        private BingControl bingControl1;
    }
}