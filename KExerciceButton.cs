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
    public partial class KExerciceButton : KButton
    {
        public readonly TExercice Exercice;



        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.TranslateTransform(1, 1);
            pevent.Graphics.DrawString(Exercice.Name, Ft, Brushes.Black, TextRectangle, StrCC);
            pevent.Graphics.TranslateTransform(-1, -1);
            if (IsCurrent)
                pevent.Graphics.DrawString(Exercice.Name, Ft, CurrentBrs, TextRectangle, StrCC);
            else
                pevent.Graphics.DrawString(Exercice.Name, Ft, Brushes.Gray, TextRectangle, StrCC);
        }

        public KExerciceButton(TExercice exercice)
        {
            Exercice = exercice;


            Random rnd = new Random((int)-exercice.Id);
            int i = 85;// 0 * (int)(AllColors.Length * rnd.NextDouble());
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
            Path.AddArc(new RectangleF(OverallSize.Width - 32, 2, diameter, diameter), 270, 90);
            Path.AddArc(new RectangleF(OverallSize.Width - 32 + diameter, 22 - diameter, diameter, diameter), 180, -90);
        }

        Rectangle TextRectangle = new Rectangle(0, 0, OverallSize.Width - 22, OverallSize.Height);

    }
}
