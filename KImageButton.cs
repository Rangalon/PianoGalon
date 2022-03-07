using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PianoGalon
{
    public partial class KImageButton : KButton
    {
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            if (ImagePath != null)
            {
                pevent.Graphics.FillPath(ImageBrush, ImagePath);
                pevent.Graphics.DrawPath(BorderPen, ImagePath);
            }
        }

        static Color C1 = Color.FromArgb(224, 224, 224);
        static Color C2 = Color.FromArgb(224, 224, 128);

        Brush ImageBrush;

        protected override void UpdateCurrentPath()
        {
            base.UpdateCurrentPath();
            BckBrush?.Dispose();
            BckBrush = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), KFlowLayoutPanel.C1, KFlowLayoutPanel.C2, 45, true);
            Path?.Dispose();
            Path = new GraphicsPath();
            Path.AddArc(Size.Width - diameter, 0, diameter, diameter, 270, 90);
            Path.AddArc(Size.Width - diameter, Size.Height - diameter, diameter, diameter, 0, 90);
            Path.AddArc(0, Size.Height - diameter, diameter, diameter, 90, 90);
            Path.AddArc(0, 0, diameter, diameter, 180, 90);

            ImageBrush?.Dispose();
            ImageBrush = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), C1, C2, 45, true);

            ImagePath?.Dispose();
            ImagePath = new GraphicsPath();

            switch (ButtonType)
            {
                case EButtonType.Minimize:
                    ImagePath.AddArc(radius, Height - diameter - radius, diameter, diameter, 90, 180);
                    ImagePath.AddArc(Width - diameter - radius, Height - diameter - radius, diameter, diameter, 270, 180);
                    break;
                case EButtonType.Close:
                    float d1 = (float)(Width * 0.5 - radius);
                    float d2 = (float)(Width * 0.5 - radius - diameter * Math.Sqrt(2));
                    ImagePath.AddArc(radius, Height - diameter - radius, diameter, diameter, 45, 180);
                    ImagePath.AddArc(d2, d1, diameter, diameter, 45, -90);

                    ImagePath.AddArc(radius, radius, diameter, diameter, 135, 180);
                    ImagePath.AddArc(d1, d2, diameter, diameter, 135, -90);

                    ImagePath.AddArc(Width - diameter - radius, radius, diameter, diameter, 225, 180);
                    ImagePath.AddArc(Width - d2 - diameter, d1, diameter, diameter, 225, -90);


                    ImagePath.AddArc(Width - diameter - radius, Height - diameter - radius, diameter, diameter, 315, 180);
                    ImagePath.AddArc(d1, Height - d2 - diameter, diameter, diameter, 315, -90);
                    break;
            }
        }

        GraphicsPath ImagePath;

        public KImageButton()
        {
            InitializeComponent();
        }

        public enum EButtonType
        {
            Minimize,
            Close
        }

    }
}
