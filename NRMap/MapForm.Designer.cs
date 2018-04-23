namespace NRMap
{
    partial class MapForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapForm));
            this.mapBox = new SharpMap.Forms.MapBox();
            this.textCoord = new System.Windows.Forms.Label();
            this.cbShowUTM = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mapBox
            // 
            this.mapBox.ActiveTool = SharpMap.Forms.MapBox.Tools.None;
            this.mapBox.BackColor = System.Drawing.Color.White;
            this.mapBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.mapBox.FineZoomFactor = 10D;
            this.mapBox.Location = new System.Drawing.Point(6, 32);
            this.mapBox.MapQueryMode = SharpMap.Forms.MapBox.MapQueryType.LayerByIndex;
            this.mapBox.Name = "mapBox";
            this.mapBox.QueryGrowFactor = 5F;
            this.mapBox.QueryLayerIndex = 0;
            this.mapBox.SelectionBackColor = System.Drawing.Color.White;
            this.mapBox.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.mapBox.ShowProgressUpdate = false;
            this.mapBox.Size = new System.Drawing.Size(595, 446);
            this.mapBox.TabIndex = 0;
            this.mapBox.Text = "mapBox";
            this.mapBox.WheelZoomMagnitude = -2D;
            this.mapBox.MouseMove += new SharpMap.Forms.MapBox.MouseEventHandler(this.mapBox_MouseMove);
            // 
            // textCoord
            // 
            this.textCoord.AutoSize = true;
            this.textCoord.Location = new System.Drawing.Point(242, 16);
            this.textCoord.Name = "textCoord";
            this.textCoord.Size = new System.Drawing.Size(34, 13);
            this.textCoord.TabIndex = 1;
            this.textCoord.Text = "Cords";
            // 
            // cbShowUTM
            // 
            this.cbShowUTM.AutoSize = true;
            this.cbShowUTM.Location = new System.Drawing.Point(186, 15);
            this.cbShowUTM.Name = "cbShowUTM";
            this.cbShowUTM.Size = new System.Drawing.Size(50, 17);
            this.cbShowUTM.TabIndex = 2;
            this.cbShowUTM.Text = "UTM";
            this.cbShowUTM.UseVisualStyleBackColor = true;
            this.cbShowUTM.CheckedChanged += new System.EventHandler(this.cbShowUTM_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mapBox);
            this.groupBox1.Controls.Add(this.cbShowUTM);
            this.groupBox1.Controls.Add(this.textCoord);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(620, 487);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Map";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(651, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(273, 487);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Controls";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(33, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 511);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MapForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Map";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SharpMap.Forms.MapBox mapBox;
        private System.Windows.Forms.Label textCoord;
        private System.Windows.Forms.CheckBox cbShowUTM;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
    }
}

