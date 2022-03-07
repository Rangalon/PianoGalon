using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml.Serialization;
using static PianoGalon.TPiano;

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

        internal void ComputePaths(TPiano piano, List<TChordTarget> ChordTargets)
        {
            for (int i = 0; i < Notes.Length; i++)
            {
                TKey key = piano.Keys[Notes[i]];
                TChordTarget ct;
                ct = new TChordTarget();
                ct.Key = key;
                ct.Date = Start * 2; ct.Duration = Duration * 2;
                ct.EventType = EChordEventType.Pressed;
                ChordTargets.Add(ct);
                ct = new TChordTarget();
                ct.Key = key;
                ct.Date = (Start + Duration) * 2;
                ct.EventType = EChordEventType.Released;
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
        public EChordEventType EventType;
        public float Date;
        public float Duration;
        public bool Done;
        public TKey Key;
        internal RectangleF Rec;
        internal GraphicsPath Path;

        internal TChordTarget Clone(int v, float d, TPiano piano)
        {
            TChordTarget ct = new TChordTarget();
            ct.Date = Date + d;
            ct.Duration = Duration;
            ct.EventType = EventType;
            ct.Key = piano.Keys[Key.Number + v];
            return ct;
        }
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
