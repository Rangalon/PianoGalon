using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml.Serialization;

namespace PianoGalon
{
    public class TChord
    {
        [XmlAttribute("d")]
        public float Duration;

        [XmlAttribute("n")]
        public int[] Notes;

        [XmlAttribute("s")]
        public float Start;

        public override string ToString()
        {
            return Start.ToString() + " " + Duration.ToString() + Notes.Length.ToString();
        }

        public static float DurationRatio = 150f;

        internal void ComputePaths(TPiano piano, List<GraphicsPath> wlst, List<GraphicsPath> blst, List<TChordTarget> ChordTargets)
        {
            for (int i = 0; i < Notes.Length; i++)
            {
                TPiano.TKey key = piano.Keys[Notes[i]];
                float xmin = key.MinX; float xmax = key.MaxX;
                float ymin = DurationRatio * Start;
                float ymax = ymin + DurationRatio * Duration;
                GraphicsPath path = new GraphicsPath();
                path.AddLine(xmin + Radius, ymin, xmax - Radius, ymin);
                path.AddArc(xmax - Diameter, ymin, Diameter, Diameter, 270, 90);
                path.AddLine(xmax, ymin + Radius, xmax, ymax - Radius);
                path.AddArc(xmax - Diameter, ymax - Diameter, Diameter, Diameter, 0, 90);
                path.AddLine(xmax - Radius, ymax, xmin + Radius, ymax);
                path.AddArc(xmin, ymax - Diameter, Diameter, Diameter, 90, 90);
                path.AddLine(xmin, ymax - Radius, xmin, ymin + Radius);
                path.AddArc(xmin, ymin, Diameter, Diameter, 180, 90);

                if (key.Black)
                    blst.Add(path);
                else
                    wlst.Add(path);

                TChordTarget ct;
                ct = new TChordTarget();
                ct.Number = key.Number;
                ct.Date = Start;
                ct.EventType = EChordEventType.Pressed;
                ct.Rec = new Rectangle((int)(0.5 * (xmin + xmax) - Radius), (int)(DurationRatio * ct.Date - 3), (int)Diameter, 6);
                ChordTargets.Add(ct);
                ct = new TChordTarget();
                ct.Number = key.Number;
                ct.Date = Start + Duration;
                ct.EventType = EChordEventType.Released;
                ct.Rec = new Rectangle((int)(0.5 * (xmin + xmax) - Radius), (int)(DurationRatio * ct.Date - 3), (int)Diameter, 6);
                ChordTargets.Add(ct);
            }

        }

        public static float Radius = 20;
        public static float Diameter = Radius * 2;
    }

    public enum EChordEventType
    {
        Pressed,
        Released
    }

    public class TChordTarget
    {
        public int Number;
        public EChordEventType EventType;
        public float Date;
        public Rectangle Rec;
        public bool Done;
    }

    public class TChordTargetComparer : IComparer<TChordTarget>
    {
        public static readonly TChordTargetComparer Default = new TChordTargetComparer();

        public int Compare(TChordTarget x, TChordTarget y)
        {
            return x.Date.CompareTo(y.Date);
        }
    }
}
