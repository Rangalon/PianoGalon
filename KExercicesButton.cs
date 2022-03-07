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
    public partial class KExercicesButton : KButton
    {

        public readonly TExercices Exercices;

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.TranslateTransform(1, 1);
            pevent.Graphics.DrawString(Exercices.Name, Ft, Brushes.Black, TextRectangle, StrCC);
            pevent.Graphics.TranslateTransform(-1, -1);
            if (IsCurrent)
                pevent.Graphics.DrawString(Exercices.Name, Ft, CurrentBrs, TextRectangle, StrCC);
            else
                pevent.Graphics.DrawString(Exercices.Name, Ft, Brushes.Gray, TextRectangle, StrCC);
        }

        public KExercicesButton(TExercices exercices)
        {
            Exercices = exercices;

            Random rnd = new Random((int)-exercices.Id);
            int i = (int)(AllColors.Length * rnd.NextDouble());
            int j = (int)(i + AllColors.Length * 0.5) % AllColors.Length;
            Color c1 = AllColors[i];
            Color c2 = AllColors[j];

            BckBrush = new LinearGradientBrush(new Rectangle(0, 0, OverallSize.Width, OverallSize.Height), c1, c2, 45, true);

            InitializeComponent();
            Path = new GraphicsPath();
            Path.AddArc(new RectangleF(OverallSize.Width - (2 + diameter), 22, diameter, diameter), 270, 90);
            Path.AddArc(new RectangleF(OverallSize.Width - (2 + diameter), OverallSize.Height - (2 + diameter), diameter, diameter), 0, 90);
            Path.AddArc(new RectangleF(2, OverallSize.Height - (2 + diameter), diameter, diameter), 90, 90);
            Path.AddArc(new RectangleF(2, 2, diameter, diameter), 180, 90);
            Path.AddArc(new RectangleF(40, 2, diameter, diameter), 270, 90);
            Path.AddArc(new RectangleF(40 + diameter, 22 - diameter, diameter, diameter), 180, -90);
        }

        Rectangle TextRectangle = new Rectangle(0, 22, OverallSize.Width - 22, OverallSize.Height - 22);

    }
}
