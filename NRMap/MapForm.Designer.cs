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
            this._mapBox = new SharpMap.Forms.MapBox();
            this.textCoord = new System.Windows.Forms.Label();
            this._cbShowUTM = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this._btnRmRoads = new System.Windows.Forms.Button();
            this._btnAddRoads = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this._dataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // _mapBox
            // 
            this._mapBox.ActiveTool = SharpMap.Forms.MapBox.Tools.None;
            this._mapBox.BackColor = System.Drawing.Color.White;
            this._mapBox.Cursor = System.Windows.Forms.Cursors.Default;
            this._mapBox.FineZoomFactor = 10D;
            this._mapBox.Location = new System.Drawing.Point(6, 32);
            this._mapBox.MapQueryMode = SharpMap.Forms.MapBox.MapQueryType.LayerByIndex;
            this._mapBox.Name = "_mapBox";
            this._mapBox.QueryGrowFactor = 5F;
            this._mapBox.QueryLayerIndex = 0;
            this._mapBox.SelectionBackColor = System.Drawing.Color.White;
            this._mapBox.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this._mapBox.ShowProgressUpdate = false;
            this._mapBox.Size = new System.Drawing.Size(477, 481);
            this._mapBox.TabIndex = 0;
            this._mapBox.Text = "mapBox";
            this._mapBox.WheelZoomMagnitude = -2D;
            this._mapBox.MouseMove += new SharpMap.Forms.MapBox.MouseEventHandler(this.MapBox_MouseMove);
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
            // _cbShowUTM
            // 
            this._cbShowUTM.AutoSize = true;
            this._cbShowUTM.Location = new System.Drawing.Point(186, 15);
            this._cbShowUTM.Name = "_cbShowUTM";
            this._cbShowUTM.Size = new System.Drawing.Size(50, 17);
            this._cbShowUTM.TabIndex = 2;
            this._cbShowUTM.Text = "UTM";
            this._cbShowUTM.UseVisualStyleBackColor = true;
            this._cbShowUTM.CheckedChanged += new System.EventHandler(this.CbShowUTM_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._mapBox);
            this.groupBox1.Controls.Add(this._cbShowUTM);
            this.groupBox1.Controls.Add(this.textCoord);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(489, 519);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Map";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button7);
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this._btnRmRoads);
            this.groupBox2.Controls.Add(this._btnAddRoads);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(774, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(218, 519);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Controls";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(114, 85);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(98, 27);
            this.button7.TabIndex = 6;
            this.button7.Text = "Remove TBD";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(6, 85);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(98, 27);
            this.button6.TabIndex = 5;
            this.button6.Text = "Add TBD";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(114, 52);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(98, 27);
            this.button5.TabIndex = 4;
            this.button5.Text = "Remove NR";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 52);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(98, 27);
            this.button4.TabIndex = 3;
            this.button4.Text = "Add NR";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // _btnRmRoads
            // 
            this._btnRmRoads.Location = new System.Drawing.Point(114, 19);
            this._btnRmRoads.Name = "_btnRmRoads";
            this._btnRmRoads.Size = new System.Drawing.Size(98, 27);
            this._btnRmRoads.TabIndex = 2;
            this._btnRmRoads.Text = "Remove Roads";
            this._btnRmRoads.UseVisualStyleBackColor = true;
            this._btnRmRoads.Click += new System.EventHandler(this.BtnRmRoads_Click);
            // 
            // _btnAddRoads
            // 
            this._btnAddRoads.Location = new System.Drawing.Point(6, 19);
            this._btnAddRoads.Name = "_btnAddRoads";
            this._btnAddRoads.Size = new System.Drawing.Size(98, 27);
            this._btnAddRoads.TabIndex = 1;
            this._btnAddRoads.Text = "Add Roads";
            this._btnAddRoads.UseVisualStyleBackColor = true;
            this._btnAddRoads.Click += new System.EventHandler(this.BtnAddRoads_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(58, 227);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // _dataGridView
            // 
            this._dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridView.Location = new System.Drawing.Point(507, 27);
            this._dataGridView.Name = "_dataGridView";
            this._dataGridView.Size = new System.Drawing.Size(261, 504);
            this._dataGridView.TabIndex = 5;
            // 
            // MapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 543);
            this.Controls.Add(this._dataGridView);
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
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SharpMap.Forms.MapBox _mapBox;
        private System.Windows.Forms.Label textCoord;
        private System.Windows.Forms.CheckBox _cbShowUTM;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button _btnRmRoads;
        private System.Windows.Forms.Button _btnAddRoads;
        private System.Windows.Forms.DataGridView _dataGridView;
    }
}

