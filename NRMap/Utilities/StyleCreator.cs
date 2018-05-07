using System.Collections.Generic;
using SharpMap.Styles;
using SharpMap.Rendering.Thematics;
using System.Drawing;
using SharpMap.Data;
using System.Linq;

namespace NRMap.Utilities
{
    /// <summary>
    /// TBD (MAYBE)
    /// </summary>
    public class StyleCreator
    {
        private string _query;
        private Color _resultingFeaturesColor;

        public string Query
        {
            get { return _query; }
            set
            {
                _query = new string((from c in value
                                        where char.IsLetterOrDigit(c) || char.IsSymbol(c)
                                        select c).ToArray());
            }
        }
        public Color ResulitingFeaturesColor
        {
            get { return _resultingFeaturesColor; }
            set { _resultingFeaturesColor = value; }
        }
        public StyleCreator() { }
        public IStyle CreateRoadsQueryStyle(FeatureDataRow row)
        {
            VectorStyle style = new VectorStyle
            {
                Line = new Pen(new SolidBrush(_resultingFeaturesColor))
            };
            return style;
        }
    }
}
