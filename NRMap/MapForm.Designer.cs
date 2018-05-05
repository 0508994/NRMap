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
            this._lbTextCoord = new System.Windows.Forms.Label();
            this._cbShowUTM = new System.Windows.Forms.CheckBox();
            this._gb1 = new System.Windows.Forms.GroupBox();
            this._gb2 = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this._btnRmRoads = new System.Windows.Forms.Button();
            this._btnAddRoads = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this._dataGridView = new System.Windows.Forms.DataGridView();
            this._gb3 = new System.Windows.Forms.GroupBox();
            this._cbRoads = new System.Windows.Forms.CheckBox();
            this.cbNR = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this._gb4 = new System.Windows.Forms.GroupBox();
            this._lbActiveLayer = new System.Windows.Forms.Label();
            this._tbBBoxMp = new System.Windows.Forms.TextBox();
            this._tbBBoxH = new System.Windows.Forms.TextBox();
            this._tbBBoxW = new System.Windows.Forms.TextBox();
            this._lbBBoxTL = new System.Windows.Forms.Label();
            this._btnGetBBox = new System.Windows.Forms.Button();
            this._gb1.SuspendLayout();
            this._gb2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).BeginInit();
            this._gb3.SuspendLayout();
            this._gb4.SuspendLayout();
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
            this._mapBox.Size = new System.Drawing.Size(437, 481);
            this._mapBox.TabIndex = 0;
            this._mapBox.Text = "mapBox";
            this._mapBox.WheelZoomMagnitude = -2D;
            this._mapBox.MouseMove += new SharpMap.Forms.MapBox.MouseEventHandler(this.MapBox_MouseMove);
            this._mapBox.MapQueried += new SharpMap.Forms.MapBox.MapQueryHandler(this._mapBox_MapQueried);
            this._mapBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MapBox_MouseClick);
            // 
            // _lbTextCoord
            // 
            this._lbTextCoord.AutoSize = true;
            this._lbTextCoord.Location = new System.Drawing.Point(188, 16);
            this._lbTextCoord.Name = "_lbTextCoord";
            this._lbTextCoord.Size = new System.Drawing.Size(34, 13);
            this._lbTextCoord.TabIndex = 1;
            this._lbTextCoord.Text = "Cords";
            // 
            // _cbShowUTM
            // 
            this._cbShowUTM.AutoSize = true;
            this._cbShowUTM.Location = new System.Drawing.Point(123, 15);
            this._cbShowUTM.Name = "_cbShowUTM";
            this._cbShowUTM.Size = new System.Drawing.Size(50, 17);
            this._cbShowUTM.TabIndex = 2;
            this._cbShowUTM.Text = "UTM";
            this._cbShowUTM.UseVisualStyleBackColor = true;
            this._cbShowUTM.CheckedChanged += new System.EventHandler(this.CbShowUTM_CheckedChanged);
            // 
            // _gb1
            // 
            this._gb1.Controls.Add(this._mapBox);
            this._gb1.Controls.Add(this._cbShowUTM);
            this._gb1.Controls.Add(this._lbTextCoord);
            this._gb1.Location = new System.Drawing.Point(12, 12);
            this._gb1.Name = "_gb1";
            this._gb1.Size = new System.Drawing.Size(452, 519);
            this._gb1.TabIndex = 3;
            this._gb1.TabStop = false;
            this._gb1.Text = "Map";
            // 
            // _gb2
            // 
            this._gb2.Controls.Add(this._btnGetBBox);
            this._gb2.Controls.Add(this._lbBBoxTL);
            this._gb2.Controls.Add(this._tbBBoxW);
            this._gb2.Controls.Add(this._tbBBoxH);
            this._gb2.Controls.Add(this._tbBBoxMp);
            this._gb2.Controls.Add(this._lbActiveLayer);
            this._gb2.Controls.Add(this.checkBox3);
            this._gb2.Controls.Add(this.cbNR);
            this._gb2.Controls.Add(this._cbRoads);
            this._gb2.Controls.Add(this._gb3);
            this._gb2.Controls.Add(this.button7);
            this._gb2.Controls.Add(this.button6);
            this._gb2.Controls.Add(this.button5);
            this._gb2.Controls.Add(this.button4);
            this._gb2.Controls.Add(this._btnRmRoads);
            this._gb2.Controls.Add(this._btnAddRoads);
            this._gb2.Location = new System.Drawing.Point(774, 12);
            this._gb2.Name = "_gb2";
            this._gb2.Size = new System.Drawing.Size(226, 519);
            this._gb2.TabIndex = 4;
            this._gb2.TabStop = false;
            this._gb2.Text = "Controls";
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
            this.button1.Location = new System.Drawing.Point(84, 163);
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
            this._dataGridView.Location = new System.Drawing.Point(6, 19);
            this._dataGridView.Name = "_dataGridView";
            this._dataGridView.Size = new System.Drawing.Size(286, 494);
            this._dataGridView.TabIndex = 5;
            // 
            // _gb3
            // 
            this._gb3.Controls.Add(this.button1);
            this._gb3.Location = new System.Drawing.Point(6, 283);
            this._gb3.Name = "_gb3";
            this._gb3.Size = new System.Drawing.Size(214, 220);
            this._gb3.TabIndex = 7;
            this._gb3.TabStop = false;
            this._gb3.Text = "Basic Operations";
            // 
            // _cbRoads
            // 
            this._cbRoads.AutoSize = true;
            this._cbRoads.Location = new System.Drawing.Point(27, 139);
            this._cbRoads.Name = "_cbRoads";
            this._cbRoads.Size = new System.Drawing.Size(57, 17);
            this._cbRoads.TabIndex = 8;
            this._cbRoads.Text = "Roads";
            this._cbRoads.UseVisualStyleBackColor = true;
            // 
            // cbNR
            // 
            this.cbNR.AutoSize = true;
            this.cbNR.Location = new System.Drawing.Point(90, 139);
            this.cbNR.Name = "cbNR";
            this.cbNR.Size = new System.Drawing.Size(42, 17);
            this.cbNR.TabIndex = 9;
            this.cbNR.Text = "NR";
            this.cbNR.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(138, 139);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(48, 17);
            this.checkBox3.TabIndex = 10;
            this.checkBox3.Text = "TBD";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // _gb4
            // 
            this._gb4.Controls.Add(this._dataGridView);
            this._gb4.Location = new System.Drawing.Point(470, 12);
            this._gb4.Name = "_gb4";
            this._gb4.Size = new System.Drawing.Size(298, 519);
            this._gb4.TabIndex = 8;
            this._gb4.TabStop = false;
            this._gb4.Text = "Features";
            // 
            // _lbActiveLayer
            // 
            this._lbActiveLayer.AutoSize = true;
            this._lbActiveLayer.Location = new System.Drawing.Point(75, 123);
            this._lbActiveLayer.Name = "_lbActiveLayer";
            this._lbActiveLayer.Size = new System.Drawing.Size(66, 13);
            this._lbActiveLayer.TabIndex = 11;
            this._lbActiveLayer.Text = "Active Layer";
            this._lbActiveLayer.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // _tbBBoxMp
            // 
            this._tbBBoxMp.Location = new System.Drawing.Point(6, 190);
            this._tbBBoxMp.Name = "_tbBBoxMp";
            this._tbBBoxMp.ReadOnly = true;
            this._tbBBoxMp.Size = new System.Drawing.Size(214, 20);
            this._tbBBoxMp.TabIndex = 12;
            this._tbBBoxMp.Text = "Click on the map...";
            // 
            // _tbBBoxH
            // 
            this._tbBBoxH.Location = new System.Drawing.Point(6, 216);
            this._tbBBoxH.Name = "_tbBBoxH";
            this._tbBBoxH.Size = new System.Drawing.Size(98, 20);
            this._tbBBoxH.TabIndex = 13;
            this._tbBBoxH.Text = "Height ( m )";
            // 
            // _tbBBoxW
            // 
            this._tbBBoxW.Location = new System.Drawing.Point(122, 216);
            this._tbBBoxW.Name = "_tbBBoxW";
            this._tbBBoxW.Size = new System.Drawing.Size(98, 20);
            this._tbBBoxW.TabIndex = 14;
            this._tbBBoxW.Text = "Width ( m )";
            // 
            // _lbBBoxTL
            // 
            this._lbBBoxTL.AutoSize = true;
            this._lbBBoxTL.Location = new System.Drawing.Point(75, 174);
            this._lbBBoxTL.Name = "_lbBBoxTL";
            this._lbBBoxTL.Size = new System.Drawing.Size(75, 13);
            this._lbBBoxTL.TabIndex = 15;
            this._lbBBoxTL.Text = "BBox Top Left\r\n";
            this._lbBBoxTL.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // _btnGetBBox
            // 
            this._btnGetBBox.Location = new System.Drawing.Point(6, 242);
            this._btnGetBBox.Name = "_btnGetBBox";
            this._btnGetBBox.Size = new System.Drawing.Size(214, 23);
            this._btnGetBBox.TabIndex = 1;
            this._btnGetBBox.Text = "Get BBox Features";
            this._btnGetBBox.UseVisualStyleBackColor = true;
            this._btnGetBBox.Click += new System.EventHandler(this.BtnGetBBox_Click);
            // 
            // MapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 543);
            this.Controls.Add(this._gb4);
            this.Controls.Add(this._gb2);
            this.Controls.Add(this._gb1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MapForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Map";
            this._gb1.ResumeLayout(false);
            this._gb1.PerformLayout();
            this._gb2.ResumeLayout(false);
            this._gb2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).EndInit();
            this._gb3.ResumeLayout(false);
            this._gb4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SharpMap.Forms.MapBox _mapBox;
        private System.Windows.Forms.Label _lbTextCoord;
        private System.Windows.Forms.CheckBox _cbShowUTM;
        private System.Windows.Forms.GroupBox _gb1;
        private System.Windows.Forms.GroupBox _gb2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button _btnRmRoads;
        private System.Windows.Forms.Button _btnAddRoads;
        private System.Windows.Forms.DataGridView _dataGridView;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox cbNR;
        private System.Windows.Forms.CheckBox _cbRoads;
        private System.Windows.Forms.GroupBox _gb3;
        private System.Windows.Forms.GroupBox _gb4;
        private System.Windows.Forms.Label _lbActiveLayer;
        private System.Windows.Forms.TextBox _tbBBoxW;
        private System.Windows.Forms.TextBox _tbBBoxH;
        private System.Windows.Forms.TextBox _tbBBoxMp;
        private System.Windows.Forms.Label _lbBBoxTL;
        private System.Windows.Forms.Button _btnGetBBox;
    }
}

