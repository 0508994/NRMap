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
            this._cbActivatePan = new System.Windows.Forms.CheckBox();
            this._gb2 = new System.Windows.Forms.GroupBox();
            this._rbNR = new System.Windows.Forms.RadioButton();
            this._rbWaters = new System.Windows.Forms.RadioButton();
            this._rbRoads = new System.Windows.Forms.RadioButton();
            this._btnGetBBox = new System.Windows.Forms.Button();
            this._lbBBoxTL = new System.Windows.Forms.Label();
            this._tbBBoxW = new System.Windows.Forms.TextBox();
            this._tbBBoxH = new System.Windows.Forms.TextBox();
            this._tbBBoxMp = new System.Windows.Forms.TextBox();
            this._lbActiveLayer = new System.Windows.Forms.Label();
            this._btnRmWaters = new System.Windows.Forms.Button();
            this._btnAddWaters = new System.Windows.Forms.Button();
            this._btnRmNR = new System.Windows.Forms.Button();
            this._btnAddNR = new System.Windows.Forms.Button();
            this._btnRmRoads = new System.Windows.Forms.Button();
            this._btnAddRoads = new System.Windows.Forms.Button();
            this._dataGridView = new System.Windows.Forms.DataGridView();
            this._gb3 = new System.Windows.Forms.GroupBox();
            this._gb1.SuspendLayout();
            this._gb2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).BeginInit();
            this._gb3.SuspendLayout();
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
            this._lbTextCoord.Location = new System.Drawing.Point(179, 10);
            this._lbTextCoord.Name = "_lbTextCoord";
            this._lbTextCoord.Size = new System.Drawing.Size(34, 13);
            this._lbTextCoord.TabIndex = 1;
            this._lbTextCoord.Text = "Cords";
            // 
            // _cbShowUTM
            // 
            this._cbShowUTM.AutoSize = true;
            this._cbShowUTM.Location = new System.Drawing.Point(123, 9);
            this._cbShowUTM.Name = "_cbShowUTM";
            this._cbShowUTM.Size = new System.Drawing.Size(50, 17);
            this._cbShowUTM.TabIndex = 2;
            this._cbShowUTM.Text = "UTM";
            this._cbShowUTM.UseVisualStyleBackColor = true;
            this._cbShowUTM.CheckedChanged += new System.EventHandler(this.CbShowUTM_CheckedChanged);
            // 
            // _gb1
            // 
            this._gb1.Controls.Add(this._cbActivatePan);
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
            // _cbActivatePan
            // 
            this._cbActivatePan.AutoSize = true;
            this._cbActivatePan.Location = new System.Drawing.Point(50, 9);
            this._cbActivatePan.Name = "_cbActivatePan";
            this._cbActivatePan.Size = new System.Drawing.Size(45, 17);
            this._cbActivatePan.TabIndex = 3;
            this._cbActivatePan.Text = "Pan";
            this._cbActivatePan.UseVisualStyleBackColor = true;
            this._cbActivatePan.CheckedChanged += new System.EventHandler(this.CbActivatePan_CheckedChanged);
            // 
            // _gb2
            // 
            this._gb2.Controls.Add(this._rbNR);
            this._gb2.Controls.Add(this._rbWaters);
            this._gb2.Controls.Add(this._rbRoads);
            this._gb2.Controls.Add(this._btnGetBBox);
            this._gb2.Controls.Add(this._lbBBoxTL);
            this._gb2.Controls.Add(this._tbBBoxW);
            this._gb2.Controls.Add(this._tbBBoxH);
            this._gb2.Controls.Add(this._tbBBoxMp);
            this._gb2.Controls.Add(this._lbActiveLayer);
            this._gb2.Controls.Add(this._btnRmWaters);
            this._gb2.Controls.Add(this._btnAddWaters);
            this._gb2.Controls.Add(this._btnRmNR);
            this._gb2.Controls.Add(this._btnAddNR);
            this._gb2.Controls.Add(this._btnRmRoads);
            this._gb2.Controls.Add(this._btnAddRoads);
            this._gb2.Location = new System.Drawing.Point(774, 12);
            this._gb2.Name = "_gb2";
            this._gb2.Size = new System.Drawing.Size(247, 519);
            this._gb2.TabIndex = 4;
            this._gb2.TabStop = false;
            this._gb2.Text = "Controls";
            // 
            // _rbNR
            // 
            this._rbNR.AutoSize = true;
            this._rbNR.Location = new System.Drawing.Point(101, 139);
            this._rbNR.Name = "_rbNR";
            this._rbNR.Size = new System.Drawing.Size(41, 17);
            this._rbNR.TabIndex = 17;
            this._rbNR.Text = "NR";
            this._rbNR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._rbNR.UseVisualStyleBackColor = true;
            this._rbNR.CheckedChanged += new System.EventHandler(this.RbNR_CheckedChanged);
            // 
            // _rbWaters
            // 
            this._rbWaters.AutoSize = true;
            this._rbWaters.Location = new System.Drawing.Point(154, 139);
            this._rbWaters.Name = "_rbWaters";
            this._rbWaters.Size = new System.Drawing.Size(59, 17);
            this._rbWaters.TabIndex = 16;
            this._rbWaters.Text = "Waters";
            this._rbWaters.UseVisualStyleBackColor = true;
            this._rbWaters.CheckedChanged += new System.EventHandler(this.RbWaters_CheckedChanged);
            // 
            // _rbRoads
            // 
            this._rbRoads.AutoSize = true;
            this._rbRoads.Checked = true;
            this._rbRoads.Location = new System.Drawing.Point(28, 139);
            this._rbRoads.Name = "_rbRoads";
            this._rbRoads.Size = new System.Drawing.Size(56, 17);
            this._rbRoads.TabIndex = 1;
            this._rbRoads.TabStop = true;
            this._rbRoads.Text = "Roads";
            this._rbRoads.UseVisualStyleBackColor = true;
            this._rbRoads.CheckedChanged += new System.EventHandler(this.RbRoads_CheckedChanged);
            // 
            // _btnGetBBox
            // 
            this._btnGetBBox.Location = new System.Drawing.Point(6, 242);
            this._btnGetBBox.Name = "_btnGetBBox";
            this._btnGetBBox.Size = new System.Drawing.Size(231, 23);
            this._btnGetBBox.TabIndex = 1;
            this._btnGetBBox.Text = "Get BBox Features";
            this._btnGetBBox.UseVisualStyleBackColor = true;
            this._btnGetBBox.Click += new System.EventHandler(this.BtnGetBBox_Click);
            // 
            // _lbBBoxTL
            // 
            this._lbBBoxTL.AutoSize = true;
            this._lbBBoxTL.Location = new System.Drawing.Point(84, 174);
            this._lbBBoxTL.Name = "_lbBBoxTL";
            this._lbBBoxTL.Size = new System.Drawing.Size(75, 13);
            this._lbBBoxTL.TabIndex = 15;
            this._lbBBoxTL.Text = "BBox Top Left\r\n";
            this._lbBBoxTL.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // _tbBBoxW
            // 
            this._tbBBoxW.Location = new System.Drawing.Point(133, 216);
            this._tbBBoxW.Name = "_tbBBoxW";
            this._tbBBoxW.Size = new System.Drawing.Size(107, 20);
            this._tbBBoxW.TabIndex = 14;
            this._tbBBoxW.Text = "Width ( m )";
            // 
            // _tbBBoxH
            // 
            this._tbBBoxH.Location = new System.Drawing.Point(6, 216);
            this._tbBBoxH.Name = "_tbBBoxH";
            this._tbBBoxH.Size = new System.Drawing.Size(107, 20);
            this._tbBBoxH.TabIndex = 13;
            this._tbBBoxH.Text = "Height ( m )";
            // 
            // _tbBBoxMp
            // 
            this._tbBBoxMp.Location = new System.Drawing.Point(6, 190);
            this._tbBBoxMp.Name = "_tbBBoxMp";
            this._tbBBoxMp.ReadOnly = true;
            this._tbBBoxMp.Size = new System.Drawing.Size(235, 20);
            this._tbBBoxMp.TabIndex = 12;
            this._tbBBoxMp.Text = "Click on the map...";
            // 
            // _lbActiveLayer
            // 
            this._lbActiveLayer.AutoSize = true;
            this._lbActiveLayer.Location = new System.Drawing.Point(84, 123);
            this._lbActiveLayer.Name = "_lbActiveLayer";
            this._lbActiveLayer.Size = new System.Drawing.Size(66, 13);
            this._lbActiveLayer.TabIndex = 11;
            this._lbActiveLayer.Text = "Active Layer";
            this._lbActiveLayer.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // _btnRmWaters
            // 
            this._btnRmWaters.Location = new System.Drawing.Point(126, 85);
            this._btnRmWaters.Name = "_btnRmWaters";
            this._btnRmWaters.Size = new System.Drawing.Size(114, 27);
            this._btnRmWaters.TabIndex = 6;
            this._btnRmWaters.Text = "Remove Waters";
            this._btnRmWaters.UseVisualStyleBackColor = true;
            this._btnRmWaters.Click += new System.EventHandler(this.BtnRmWaters_Click);
            // 
            // _btnAddWaters
            // 
            this._btnAddWaters.Location = new System.Drawing.Point(6, 85);
            this._btnAddWaters.Name = "_btnAddWaters";
            this._btnAddWaters.Size = new System.Drawing.Size(114, 27);
            this._btnAddWaters.TabIndex = 5;
            this._btnAddWaters.Text = "Add Waters";
            this._btnAddWaters.UseVisualStyleBackColor = true;
            this._btnAddWaters.Click += new System.EventHandler(this.BtnAddWaters_Click);
            // 
            // _btnRmNR
            // 
            this._btnRmNR.Location = new System.Drawing.Point(126, 52);
            this._btnRmNR.Name = "_btnRmNR";
            this._btnRmNR.Size = new System.Drawing.Size(114, 27);
            this._btnRmNR.TabIndex = 4;
            this._btnRmNR.Text = "Remove NR";
            this._btnRmNR.UseVisualStyleBackColor = true;
            this._btnRmNR.Click += new System.EventHandler(this.BtnRmNR_Click);
            // 
            // _btnAddNR
            // 
            this._btnAddNR.Location = new System.Drawing.Point(6, 52);
            this._btnAddNR.Name = "_btnAddNR";
            this._btnAddNR.Size = new System.Drawing.Size(114, 27);
            this._btnAddNR.TabIndex = 3;
            this._btnAddNR.Text = "Add NR";
            this._btnAddNR.UseVisualStyleBackColor = true;
            this._btnAddNR.Click += new System.EventHandler(this.BtnAddNR_Click);
            // 
            // _btnRmRoads
            // 
            this._btnRmRoads.Location = new System.Drawing.Point(126, 19);
            this._btnRmRoads.Name = "_btnRmRoads";
            this._btnRmRoads.Size = new System.Drawing.Size(114, 27);
            this._btnRmRoads.TabIndex = 2;
            this._btnRmRoads.Text = "Remove Roads";
            this._btnRmRoads.UseVisualStyleBackColor = true;
            this._btnRmRoads.Click += new System.EventHandler(this.BtnRmRoads_Click);
            // 
            // _btnAddRoads
            // 
            this._btnAddRoads.Location = new System.Drawing.Point(6, 19);
            this._btnAddRoads.Name = "_btnAddRoads";
            this._btnAddRoads.Size = new System.Drawing.Size(114, 27);
            this._btnAddRoads.TabIndex = 1;
            this._btnAddRoads.Text = "Add Roads";
            this._btnAddRoads.UseVisualStyleBackColor = true;
            this._btnAddRoads.Click += new System.EventHandler(this.BtnAddRoads_Click);
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
            this._gb3.Controls.Add(this._dataGridView);
            this._gb3.Location = new System.Drawing.Point(470, 12);
            this._gb3.Name = "_gb3";
            this._gb3.Size = new System.Drawing.Size(298, 519);
            this._gb3.TabIndex = 8;
            this._gb3.TabStop = false;
            this._gb3.Text = "Features";
            // 
            // MapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 541);
            this.Controls.Add(this._gb3);
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
            this.ResumeLayout(false);

        }

        #endregion

        private SharpMap.Forms.MapBox _mapBox;
        private System.Windows.Forms.Label _lbTextCoord;
        private System.Windows.Forms.CheckBox _cbShowUTM;
        private System.Windows.Forms.GroupBox _gb1;
        private System.Windows.Forms.GroupBox _gb2;
        private System.Windows.Forms.Button _btnRmWaters;
        private System.Windows.Forms.Button _btnAddWaters;
        private System.Windows.Forms.Button _btnRmNR;
        private System.Windows.Forms.Button _btnAddNR;
        private System.Windows.Forms.Button _btnRmRoads;
        private System.Windows.Forms.Button _btnAddRoads;
        private System.Windows.Forms.DataGridView _dataGridView;
        private System.Windows.Forms.GroupBox _gb3;
        private System.Windows.Forms.Label _lbActiveLayer;
        private System.Windows.Forms.TextBox _tbBBoxW;
        private System.Windows.Forms.TextBox _tbBBoxH;
        private System.Windows.Forms.TextBox _tbBBoxMp;
        private System.Windows.Forms.Label _lbBBoxTL;
        private System.Windows.Forms.Button _btnGetBBox;
        private System.Windows.Forms.CheckBox _cbActivatePan;
        private System.Windows.Forms.RadioButton _rbNR;
        private System.Windows.Forms.RadioButton _rbWaters;
        private System.Windows.Forms.RadioButton _rbRoads;
    }
}

