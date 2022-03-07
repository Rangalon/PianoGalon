using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PianoGalon
{
    public partial class KLabel : Label
    {
        public KLabel()
        {
            InitializeComponent();
            UpdatePath();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillPath(BckBrush, Path);
            e.Graphics.DrawPath(KButton.BorderPen, Path);

            e.Graphics.TranslateTransform(1, 1);
            e.Graphics.DrawString(Text, Ft, Brushes.Black, e.ClipRectangle, KButton.StrCC);
            e.Graphics.TranslateTransform(-1, -1);
            e.Graphics.DrawString(Text, Ft, Brushes.LightGray, e.ClipRectangle, KButton.StrCC);
        }


        public static readonly Font Ft = new Font("Verdana", 28,FontStyle.Bold );
        GraphicsPath Path;

        void UpdatePath()
        {
            BckBrush?.Dispose();
            BckBrush = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), C1, C2, 45, true);
            Path?.Dispose();
            Path = new GraphicsPath();
            Path.AddArc(Size.Width - KButton.diameter, 0, KButton.diameter, KButton.diameter, 270, 90);
            Path.AddArc(Size.Width - KButton.diameter, Size.Height - KButton.diameter, KButton.diameter, KButton.diameter, 0, 90);
            Path.AddArc(0, Size.Height - KButton.diameter, KButton.diameter, KButton.diameter, 90, 90);
            Path.AddArc(0, 0, KButton.diameter, KButton.diameter, 180, 90);
        }

        public static Color C1 = Color.FromArgb(32, 32, 32);
        public static Color C2 = Color.FromArgb(96, 96, 64);
        public Brush BckBrush;
        private void KLabel_Resize(object sender, EventArgs e)
        {
            UpdatePath();
        }
    }
}
