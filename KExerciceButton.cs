﻿using System;
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
                if (value != null) BckBrush = GetBrs(Size, exercice.Id);
            }
        }


        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);


            pevent.Graphics.FillPath(BckBrush, Path);
            pevent.Graphics.DrawPath(BorderPen, Path);

            pevent.Graphics.TranslateTransform(1, 1);

            if (exercice != null)
            {
                pevent.Graphics.DrawString(exercice.Name, Ft, Brushes.Black, TextRectangle, StrCC);
                pevent.Graphics.TranslateTransform(-1, -1);
                pevent.Graphics.DrawString(exercice.Name, Ft, Brushes.LightGray, TextRectangle, StrCC);
            }
            else
            {
                pevent.Graphics.DrawString("Select an Exercice", Ft, Brushes.Black, TextRectangle, StrCC);
                pevent.Graphics.TranslateTransform(-1, -1);
                pevent.Graphics.DrawString("Select an Exercice", Ft, Brushes.LightGray, TextRectangle, StrCC);
            }
            if (HasMouse) pevent.Graphics.FillPath(BorderPen.Brush, Path);
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

        Rectangle TextRectangle = new Rectangle(0, 0, OverallSize.Width, OverallSize.Height);

    }
}
