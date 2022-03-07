using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PianoGalon
{
    public partial class KButton : Button
    {

        public static readonly Font Ft = new Font("Verdana", 14, FontStyle.Bold);


        protected GraphicsPath Path;

        static KButton()
        {
            List<Color> cls = new List<Color>();
            Type tp = typeof(Color);
            PropertyInfo[] pis = tp.GetProperties().Where(o => o.PropertyType == typeof(Color)).ToArray();
            foreach (PropertyInfo pi in pis)
                cls.Add((Color)pi.GetValue(null));
            cls.RemoveAll(o => o.R < 32 && o.G < 32 && o.B < 32);
            cls.RemoveAll(o => o.A < 255);
            AllColors = cls.ToArray();
        }

        protected static Color[] AllColors;

        public static int radius = 7;
        public static int diameter = radius * 2;

        protected virtual void UpdateCurrentPath()
        {
            CurrentPath = new GraphicsPath();
            CurrentPath.AddArc(Size.Width - diameter, 0, diameter, diameter, 270, 90);
            CurrentPath.AddArc(Size.Width - diameter, Size.Height - diameter, diameter, diameter, 0, 90);
            CurrentPath.AddArc(0, Size.Height - diameter, diameter, diameter, 90, 90);
            CurrentPath.AddArc(0, 0, diameter, diameter, 180, 90);
        }


        static double BrsCoef = 0.4;
        static double BrsCst = 0;

        protected static Brush GetBrs(Size sz, uint n)
        {
            Random rnd = new Random((int)-n);
            int i = (int)(AllColors.Length * rnd.NextDouble());
            int j = (int)(i + AllColors.Length * 0.5) % AllColors.Length;
            Color c1 = AllColors[i];
            Color c2 = AllColors[j];
            c1 = Color.FromArgb((byte)(BrsCst + BrsCoef * c1.R), (byte)(BrsCst + BrsCoef * c1.G), (byte)(BrsCst + BrsCoef * c1.B));
            c2 = Color.FromArgb((byte)(BrsCst + BrsCoef * c2.R), (byte)(BrsCst + BrsCoef * c2.G), (byte)(BrsCst + BrsCoef * c2.B));
            return new LinearGradientBrush(new Rectangle(0, 0, sz.Width, sz.Height), c1, c2, 45, true);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            if (Parent is KFlowLayoutPanel)
            {
                KFlowLayoutPanel flp = (KFlowLayoutPanel)Parent;
                pevent.Graphics.TranslateTransform(-Location.X, -Location.Y);
                pevent.Graphics.FillRectangle(flp.BckBrush, new Rectangle(Location.X, Location.Y, Width, Height));
                pevent.Graphics.TranslateTransform(Location.X, Location.Y);
            }
            else
                pevent.Graphics.Clear(Color.Black);

            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                       
        }



        public static Pen BorderPen = new Pen(Color.FromArgb(64, 0, 0, 0), 4);
        public static Pen LightPen = new Pen(Color.FromArgb(64, 255, 255, 255), 4);
        static protected Brush CurrentBrs = new SolidBrush(Color.FromArgb(255, 224, 224, 0));



        public static readonly StringFormat StrCC = new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center };

        protected Brush BckBrush;

        public KButton()
        {
            InitializeComponent();
        }

        GraphicsPath CurrentPath;

        private void KButton_Resize(object sender, EventArgs e)
        {
            UpdateCurrentPath();
        }

        protected bool HasMouse = false;

        private void KButton_MouseLeave(object sender, EventArgs e)
        {
            HasMouse = false;
        }

        private void KButton_MouseEnter(object sender, EventArgs e)
        {
            HasMouse = true;
        }
    }
}
