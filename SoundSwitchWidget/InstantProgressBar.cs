using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoundSwitchWidget
{
    public class InstantProgressBar : Control
    {
        private int _value = 50;
        private int _maximum = 100;
        private int _minimum = 0;

        [Browsable(true)]
        [Category("Behavior")]
        [DefaultValue(50)]
        public int Value
        {
            get => _value;
            set
            {
                if (value < 0) value = 0;
                if (value > Maximum) value = Maximum;
                _value = value;
                Invalidate(); // redraw immediately
            }
        }

        [Browsable(true)]
        [Category("Behavior")]
        [DefaultValue(100)]
        public int Minimum
        {
            get => _minimum;
            set
            {
                if (value <= 0) value = 0;
                _minimum = value;
                if (_value < _minimum) _value = _minimum;
                Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Behavior")]
        [DefaultValue(100)]
        public int Maximum
        {
            get => _maximum;
            set
            {
                if (value <= 0) value = 100;
                _maximum = value;
                if (_value > _maximum) _value = _maximum;
                Invalidate();
            }
        }

        public InstantProgressBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;

            // Draw background
            g.FillRectangle(Brushes.LightGray, ClientRectangle);

            // Calculate fill width
            float percent = (float)_value / _maximum;
            int fillWidth = (int)(ClientRectangle.Width * percent);

            // Draw fill
            g.FillRectangle(Brushes.DodgerBlue, 0, 0, fillWidth, ClientRectangle.Height);

            // Optional: draw border
            g.DrawRectangle(Pens.Black, 0, 0, ClientRectangle.Width - 1, ClientRectangle.Height - 1);
        }
    }

}
