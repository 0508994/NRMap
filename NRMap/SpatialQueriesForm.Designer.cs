namespace NRMap
{
    partial class SpatialQueriesForm
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
            this._gbSL = new System.Windows.Forms.GroupBox();
            this._rbSLWaters = new System.Windows.Forms.RadioButton();
            this._rbSLNR = new System.Windows.Forms.RadioButton();
            this._rbSLRoads = new System.Windows.Forms.RadioButton();
            this._gbTL = new System.Windows.Forms.GroupBox();
            this._rbTLWaters = new System.Windows.Forms.RadioButton();
            this._rbTLNR = new System.Windows.Forms.RadioButton();
            this._rbTLRoads = new System.Windows.Forms.RadioButton();
            this._rtbSQuery = new System.Windows.Forms.RichTextBox();
            this._gbOp = new System.Windows.Forms.GroupBox();
            this._rbCrosses = new System.Windows.Forms.RadioButton();
            this._rbTouches = new System.Windows.Forms.RadioButton();
            this._tbDist = new System.Windows.Forms.TextBox();
            this._rbOverlaps = new System.Windows.Forms.RadioButton();
            this._rbInter = new System.Windows.Forms.RadioButton();
            this._rbWithin = new System.Windows.Forms.RadioButton();
            this._rbDwithin = new System.Windows.Forms.RadioButton();
            this._btnExecute = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this._gbSL.SuspendLayout();
            this._gbTL.SuspendLayout();
            this._gbOp.SuspendLayout();
            this.SuspendLayout();
            // 
            // _gbSL
            // 
            this._gbSL.Controls.Add(this._rbSLWaters);
            this._gbSL.Controls.Add(this._rbSLNR);
            this._gbSL.Controls.Add(this._rbSLRoads);
            this._gbSL.Location = new System.Drawing.Point(12, 12);
            this._gbSL.Name = "_gbSL";
            this._gbSL.Size = new System.Drawing.Size(100, 108);
            this._gbSL.TabIndex = 0;
            this._gbSL.TabStop = false;
            this._gbSL.Text = "Source Layer (SL)";
            // 
            // _rbSLWaters
            // 
            this._rbSLWaters.AutoSize = true;
            this._rbSLWaters.Location = new System.Drawing.Point(7, 83);
            this._rbSLWaters.Name = "_rbSLWaters";
            this._rbSLWaters.Size = new System.Drawing.Size(59, 17);
            this._rbSLWaters.TabIndex = 2;
            this._rbSLWaters.Text = "Waters";
            this._rbSLWaters.UseVisualStyleBackColor = true;
            // 
            // _rbSLNR
            // 
            this._rbSLNR.AutoSize = true;
            this._rbSLNR.Checked = true;
            this._rbSLNR.Location = new System.Drawing.Point(7, 60);
            this._rbSLNR.Name = "_rbSLNR";
            this._rbSLNR.Size = new System.Drawing.Size(41, 17);
            this._rbSLNR.TabIndex = 1;
            this._rbSLNR.TabStop = true;
            this._rbSLNR.Text = "NR";
            this._rbSLNR.UseVisualStyleBackColor = true;
            // 
            // _rbSLRoads
            // 
            this._rbSLRoads.AutoSize = true;
            this._rbSLRoads.Location = new System.Drawing.Point(7, 37);
            this._rbSLRoads.Name = "_rbSLRoads";
            this._rbSLRoads.Size = new System.Drawing.Size(56, 17);
            this._rbSLRoads.TabIndex = 0;
            this._rbSLRoads.Text = "Roads";
            this._rbSLRoads.UseVisualStyleBackColor = true;
            // 
            // _gbTL
            // 
            this._gbTL.Controls.Add(this._rbTLWaters);
            this._gbTL.Controls.Add(this._rbTLNR);
            this._gbTL.Controls.Add(this._rbTLRoads);
            this._gbTL.Location = new System.Drawing.Point(140, 12);
            this._gbTL.Name = "_gbTL";
            this._gbTL.Size = new System.Drawing.Size(100, 108);
            this._gbTL.TabIndex = 1;
            this._gbTL.TabStop = false;
            this._gbTL.Text = "Target Layer (TL)";
            // 
            // _rbTLWaters
            // 
            this._rbTLWaters.AutoSize = true;
            this._rbTLWaters.Location = new System.Drawing.Point(9, 83);
            this._rbTLWaters.Name = "_rbTLWaters";
            this._rbTLWaters.Size = new System.Drawing.Size(59, 17);
            this._rbTLWaters.TabIndex = 5;
            this._rbTLWaters.Text = "Waters";
            this._rbTLWaters.UseVisualStyleBackColor = true;
            // 
            // _rbTLNR
            // 
            this._rbTLNR.AutoSize = true;
            this._rbTLNR.Location = new System.Drawing.Point(9, 60);
            this._rbTLNR.Name = "_rbTLNR";
            this._rbTLNR.Size = new System.Drawing.Size(41, 17);
            this._rbTLNR.TabIndex = 4;
            this._rbTLNR.Text = "NR";
            this._rbTLNR.UseVisualStyleBackColor = true;
            // 
            // _rbTLRoads
            // 
            this._rbTLRoads.AutoSize = true;
            this._rbTLRoads.Checked = true;
            this._rbTLRoads.Location = new System.Drawing.Point(9, 37);
            this._rbTLRoads.Name = "_rbTLRoads";
            this._rbTLRoads.Size = new System.Drawing.Size(56, 17);
            this._rbTLRoads.TabIndex = 3;
            this._rbTLRoads.TabStop = true;
            this._rbTLRoads.Text = "Roads";
            this._rbTLRoads.UseVisualStyleBackColor = true;
            // 
            // _rtbSQuery
            // 
            this._rtbSQuery.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._rtbSQuery.Location = new System.Drawing.Point(12, 254);
            this._rtbSQuery.Name = "_rtbSQuery";
            this._rtbSQuery.Size = new System.Drawing.Size(228, 125);
            this._rtbSQuery.TabIndex = 2;
            this._rtbSQuery.Text = "sl.fclass=\'cave_entrance\' and tl.fclass=\'primary\'";
            // 
            // _gbOp
            // 
            this._gbOp.Controls.Add(this._rbCrosses);
            this._gbOp.Controls.Add(this._rbTouches);
            this._gbOp.Controls.Add(this._tbDist);
            this._gbOp.Controls.Add(this._rbOverlaps);
            this._gbOp.Controls.Add(this._rbInter);
            this._gbOp.Controls.Add(this._rbWithin);
            this._gbOp.Controls.Add(this._rbDwithin);
            this._gbOp.Location = new System.Drawing.Point(12, 126);
            this._gbOp.Name = "_gbOp";
            this._gbOp.Size = new System.Drawing.Size(228, 122);
            this._gbOp.TabIndex = 3;
            this._gbOp.TabStop = false;
            this._gbOp.Text = "Spatial Operation";
            // 
            // _rbCrosses
            // 
            this._rbCrosses.AutoSize = true;
            this._rbCrosses.Location = new System.Drawing.Point(111, 99);
            this._rbCrosses.Name = "_rbCrosses";
            this._rbCrosses.Size = new System.Drawing.Size(62, 17);
            this._rbCrosses.TabIndex = 12;
            this._rbCrosses.Text = "Crosses";
            this._rbCrosses.UseVisualStyleBackColor = true;
            // 
            // _rbTouches
            // 
            this._rbTouches.AutoSize = true;
            this._rbTouches.Location = new System.Drawing.Point(111, 65);
            this._rbTouches.Name = "_rbTouches";
            this._rbTouches.Size = new System.Drawing.Size(67, 17);
            this._rbTouches.TabIndex = 11;
            this._rbTouches.Text = "Touches";
            this._rbTouches.UseVisualStyleBackColor = true;
            // 
            // _tbDist
            // 
            this._tbDist.Location = new System.Drawing.Point(180, 32);
            this._tbDist.Name = "_tbDist";
            this._tbDist.Size = new System.Drawing.Size(39, 20);
            this._tbDist.TabIndex = 10;
            this._tbDist.Text = "0";
            // 
            // _rbOverlaps
            // 
            this._rbOverlaps.AutoSize = true;
            this._rbOverlaps.Location = new System.Drawing.Point(7, 99);
            this._rbOverlaps.Name = "_rbOverlaps";
            this._rbOverlaps.Size = new System.Drawing.Size(67, 17);
            this._rbOverlaps.TabIndex = 9;
            this._rbOverlaps.Text = "Overlaps";
            this._rbOverlaps.UseVisualStyleBackColor = true;
            // 
            // _rbInter
            // 
            this._rbInter.AutoSize = true;
            this._rbInter.Location = new System.Drawing.Point(7, 65);
            this._rbInter.Name = "_rbInter";
            this._rbInter.Size = new System.Drawing.Size(71, 17);
            this._rbInter.TabIndex = 8;
            this._rbInter.Text = "Intersects";
            this._rbInter.UseVisualStyleBackColor = true;
            // 
            // _rbWithin
            // 
            this._rbWithin.AutoSize = true;
            this._rbWithin.Location = new System.Drawing.Point(7, 32);
            this._rbWithin.Name = "_rbWithin";
            this._rbWithin.Size = new System.Drawing.Size(55, 17);
            this._rbWithin.TabIndex = 7;
            this._rbWithin.Text = "Within";
            this._rbWithin.UseVisualStyleBackColor = true;
            // 
            // _rbDwithin
            // 
            this._rbDwithin.AutoSize = true;
            this._rbDwithin.Checked = true;
            this._rbDwithin.Location = new System.Drawing.Point(111, 32);
            this._rbDwithin.Name = "_rbDwithin";
            this._rbDwithin.Size = new System.Drawing.Size(63, 17);
            this._rbDwithin.TabIndex = 6;
            this._rbDwithin.TabStop = true;
            this._rbDwithin.Text = "DWithin";
            this._rbDwithin.UseVisualStyleBackColor = true;
            // 
            // _btnExecute
            // 
            this._btnExecute.Location = new System.Drawing.Point(12, 385);
            this._btnExecute.Name = "_btnExecute";
            this._btnExecute.Size = new System.Drawing.Size(107, 23);
            this._btnExecute.TabIndex = 5;
            this._btnExecute.Text = "Execute";
            this._btnExecute.UseVisualStyleBackColor = true;
            // 
            // _btnCancel
            // 
            this._btnCancel.Location = new System.Drawing.Point(133, 384);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(107, 23);
            this._btnCancel.TabIndex = 6;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            // 
            // SpatialQueriesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 419);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnExecute);
            this.Controls.Add(this._gbOp);
            this.Controls.Add(this._rtbSQuery);
            this.Controls.Add(this._gbTL);
            this.Controls.Add(this._gbSL);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SpatialQueriesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spatial Queries";
            this._gbSL.ResumeLayout(false);
            this._gbSL.PerformLayout();
            this._gbTL.ResumeLayout(false);
            this._gbTL.PerformLayout();
            this._gbOp.ResumeLayout(false);
            this._gbOp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _gbSL;
        private System.Windows.Forms.GroupBox _gbTL;
        private System.Windows.Forms.RadioButton _rbSLWaters;
        private System.Windows.Forms.RadioButton _rbSLNR;
        private System.Windows.Forms.RadioButton _rbSLRoads;
        private System.Windows.Forms.RadioButton _rbTLWaters;
        private System.Windows.Forms.RadioButton _rbTLNR;
        private System.Windows.Forms.RadioButton _rbTLRoads;
        private System.Windows.Forms.RichTextBox _rtbSQuery;
        private System.Windows.Forms.GroupBox _gbOp;
        private System.Windows.Forms.RadioButton _rbTouches;
        private System.Windows.Forms.TextBox _tbDist;
        private System.Windows.Forms.RadioButton _rbOverlaps;
        private System.Windows.Forms.RadioButton _rbInter;
        private System.Windows.Forms.RadioButton _rbWithin;
        private System.Windows.Forms.RadioButton _rbDwithin;
        private System.Windows.Forms.Button _btnExecute;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.RadioButton _rbCrosses;
    }
}