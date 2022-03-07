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

        TExercices exercices;


        public TExercices Exercices
        {
            get => exercices;
            set
            {
                exercices = value;
                if (value != null)
                {
                    Random rnd = new Random((int)-exercices.Id);
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
            if (exercices != null)
            {
                pevent.Graphics.DrawString(Exercices.Name, Ft, Brushes.Black, pevent.ClipRectangle, StrCC);
                pevent.Graphics.TranslateTransform(-1, -1);
                pevent.Graphics.DrawString(Exercices.Name, Ft, CurrentBrs, pevent.ClipRectangle, StrCC);
            }
            else
            {
                pevent.Graphics.DrawString("Select the Exercices", Ft, Brushes.Black, pevent.ClipRectangle, StrCC);
                pevent.Graphics.TranslateTransform(-1, -1);
                pevent.Graphics.DrawString("Select the Exercices", Ft, CurrentBrs, pevent.ClipRectangle, StrCC);
            }
        }

        public KExercicesButton()
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


    }
}
