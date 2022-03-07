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
        TExercice exercice;

        public TExercice Exercice
        {
            get => exercice;
            set
            {
                exercice = value;
                if (value != null)
                {
                    Random rnd = new Random((int)-exercice.Id);
                    int i = (int)(AllColors.Length * rnd.NextDouble());
                    int j = (int)(i + AllColors.Length * 0.5) % AllColors.Length;
                    Color c1 = AllColors[i];
                    Color c2 = AllColors[j];
                    BckBrush = new LinearGradientBrush(new Rectangle(0, 0, OverallSize.Width, OverallSize.Height), c1, c2, 45, true);
                }
            }
        }


        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.TranslateTransform(1, 1);

            if (exercice != null)
            {
                pevent.Graphics.DrawString(exercice.Name, Ft, Brushes.Black, TextRectangle, StrCC);
                pevent.Graphics.TranslateTransform(-1, -1);
                pevent.Graphics.DrawString(exercice.Name, Ft, CurrentBrs, TextRectangle, StrCC);
            }
            else
            {
                pevent.Graphics.DrawString("Select an Exercice", Ft, Brushes.Black, TextRectangle, StrCC);
                pevent.Graphics.TranslateTransform(-1, -1);
                pevent.Graphics.DrawString("Select an Exercice", Ft, CurrentBrs, TextRectangle, StrCC);
            }
        }

        public KExerciceButton()
        {
            BckBrush = new LinearGradientBrush(
                   new Point(0, 0),
                   new Point(OverallSize.Width, OverallSize.Height),
                   KLabel.C1,
                   KLabel.C2);


            InitializeComponent();
            Path = new GraphicsPath();
            Path.AddArc(new RectangleF(OverallSize.Width - (2 + diameter), 2, diameter, diameter), 270, 90);
            Path.AddArc(new RectangleF(OverallSize.Width - (2 + diameter), OverallSize.Height - (2 + diameter), diameter, diameter), 0, 90);
            Path.AddArc(new RectangleF(2, OverallSize.Height - (2 + diameter), diameter, diameter), 90, 90);
            Path.AddArc(new RectangleF(2, 2, diameter, diameter), 180, 90);
        }

        Rectangle TextRectangle = new Rectangle(0, 0, OverallSize.Width , OverallSize.Height);

    }
}
