using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NRMap.Utilities;

namespace NRMap
{
    public partial class SpatialQueriesForm : Form
    {
        public SpatialQueriesForm()
        {
            InitializeComponent();
            _btnExecute.DialogResult = DialogResult.OK;
            _btnCancel.DialogResult = DialogResult.Cancel;
        }

        private void BtnSetColor_Click(object sender, EventArgs e)
        {
            if (_colorPicker.ShowDialog() == DialogResult.OK)
            {
                _btnSetColor.BackColor = _colorPicker.Color;
            }
        }

        public Color ResultColor { get { return _colorPicker.Color; } }

        public string SourceLayer
        {
            get
            {
                if (_rbSLRoads.Checked)
                    return Constants.roadsTable;
                if (_rbSLNR.Checked)
                    return Constants.nrTable;
                return Constants.watersTable;
            }
        }

        public string TargetLayer
        {
            get
            {
                if (_rbTLRoads.Checked)
                    return Constants.roadsTable;
                if (_rbTLNR.Checked)
                    return Constants.nrTable;
                return Constants.watersTable;
            }
        }

        public int OpCode
        {
            get
            {
                if (_rbWithin.Checked)
                    return Constants.within;
                if (_rbDwithin.Checked)
                    return Constants.dWithin;
                if (_rbInter.Checked)
                    return Constants.intersects;
                if (_rbTouches.Checked)
                    return Constants.touches;
                if (_rbOverlaps.Checked)
                    return Constants.overlaps;
                return Constants.crosses;
            }
        }

        public string DWithingDistance { get { return _tbDist.Text; } }
    }
}
