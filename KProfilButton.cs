﻿using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PianoGalon
{
    public partial class KProfilButton : KButton
    {
        public TProfil Profil;

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.TranslateTransform(1, 1);
            pevent.Graphics.DrawString(Profil.Name, Ft, Brushes.Black, pevent.ClipRectangle, StrCC);
            pevent.Graphics.TranslateTransform(-1, -1);
            if (IsCurrent)
                pevent.Graphics.DrawString(Profil.Name, Ft, CurrentBrs, pevent.ClipRectangle, StrCC);
            else
                pevent.Graphics.DrawString(Profil.Name, Ft, Brushes.Gray, pevent.ClipRectangle, StrCC);
        }

        public KProfilButton(TProfil profil)
        {
            Profil = profil;
            BckBrush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(OverallSize.Width, OverallSize.Height),
                Color.FromArgb((byte)(Profil.BckColor.R * 0.5), (byte)(Profil.BckColor.G * 0.5), (byte)(Profil.BckColor.B * 0.5)),
                Color.FromArgb((byte)(Profil.BckColor.R * 0.5) + 128, (byte)(Profil.BckColor.G * 0.5) + 128, (byte)(Profil.BckColor.B * 0.5) + 128));
            InitializeComponent();
            Path = new GraphicsPath();
            Path.AddLine((2 + radius), 2, OverallSize.Width - (2 + radius), 2);
            Path.AddArc(new RectangleF(OverallSize.Width - (2 + diameter), 2, diameter, diameter), 270, 90);
            Path.AddLine(OverallSize.Width - 2, (2 + radius), OverallSize.Width - 2, OverallSize.Height - (2 + radius));
            Path.AddArc(new RectangleF(OverallSize.Width - (2 + diameter), OverallSize.Height - (2 + diameter), diameter, diameter), 0, 90);
            Path.AddLine(OverallSize.Width - (2 + radius), OverallSize.Height - 2, (2 + radius), OverallSize.Height - 2);
            Path.AddArc(new RectangleF(2, OverallSize.Height - (2 + diameter), diameter, diameter), 90, 90);
            Path.AddLine(2, OverallSize.Height - (2 + radius), 2, (2 + radius));
            Path.AddArc(new RectangleF(2, 2, diameter, diameter), 180, 90);
        }



    }
}
