using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Multimedia;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PianoGalon
{
    public class TPiano
    {
        InputDevice device;

        public TPiano(InputDevice p)
        {
            device = p;
            if (p != null)
            {
                p.EventReceived += P_EventReceived;
                p.StartEventsListening();
            }
            Keys = new TKey[113];
            //for (int i = 0; i < Keys.Length; i++) Keys[i] = new TKey(i); 
            for (int i = 21; i < 109; i++) Keys[i] = new TKey(i);
            Max = Keys.Where(o => o != null).Max(o => o.Max);
            Min = Keys.Where(o => o != null).Min(o => o.Min);
        }

        public delegate void NoteEventCallBack(int note, int velocity);

        public NoteEventCallBack NoteEvent;

        public class TKey
        {

            public readonly int Number;
            public int Velocity;
            public readonly PointF[] Pnts;
            public readonly float Min;
            public readonly float Max;
            public bool Black;
            public System.Drawing.Drawing2D.GraphicsPath Path;

            public readonly string Name;

            static readonly float WhiteW = 23;
            static readonly float BlackW = 10f;
            static readonly float TotalW3 = WhiteW * 3 + 2;
            static readonly float TotalW4 = WhiteW * 4 + 3;
            static readonly float W3Width = (TotalW3 - 2 * BlackW - 4) / 3.0f;
            static readonly float W4Width = (TotalW4 - 3 * BlackW - 6) / 4.0f;
            static readonly float TotalW = (WhiteW + 1) * 7;

            public float MinX;
            public float MaxX;

            public float DeltaX;

            static float radius = 5;
            static float diameter = radius * 2;


            public TKey(int i)
            {
                Number = i;
                float start;
                int di = i % 12;
                float dl = 0, dr = 0;
                i -= di;
                i /= 12;
                start = TotalW * i;
                float w = 0, h1 = 0, h2 = 0;

                switch (Number  % 12)
                {
                    case 0: Name = "Do"; break;
                    case 2: Name = "Re"; break;
                    case 4: Name = "Mi"; break;
                    case 5: Name = "Fa"; break;
                    case 7: Name = "Sol"; break;
                    case 9: Name = "La"; break;
                    case 11: Name = "Si"; break;
                }

                switch (di)
                {
                    case 0:
                    case 2:
                    case 4:
                        w = W3Width; h2 = 138;
                        dl = start + (di >> 1) * (WhiteW + 1);
                        dr = start + (di >> 1) * (WhiteW + 1) + WhiteW;
                        start += (di >> 1) * (W3Width + 1 + BlackW + 1);
                        dl = start - dl;
                        dr = dr - start - w;
                        h1 = 71;
                        break;
                    case 1:
                    case 3:
                        Black = true;
                        w = BlackW; h2 = 70;
                        start += ((di + 1) >> 1) * (W3Width + 1) + ((di - 1) >> 1) * (BlackW + 1);
                        break;
                    case 5:
                    case 7:
                    case 9:
                    case 11:
                        w = W4Width; h2 = 138;
                        start += TotalW3 + 1;
                        dl = start + ((di - 5) >> 1) * (WhiteW + 1);
                        dr = start + ((di - 5) >> 1) * (WhiteW + 1) + WhiteW;
                        start += ((di - 5) >> 1) * (W4Width + 1 + BlackW + 1);
                        dl = start - dl;
                        dr = dr - start - w;
                        h1 = 71;
                        break;
                    case 6:
                    case 8:
                    case 10:
                        Black = true;
                        w = BlackW; h2 = 70;
                        start += TotalW3 + 1 + ((di - 4) >> 1) * (W4Width + 1) + ((di - 6) >> 1) * (BlackW + 1);
                        break;
                }

                MinX = 5 * start;
                MaxX = 5 * (start + w);
                DeltaX = MaxX - MinX;

                Pnts = new PointF[] {
                    new PointF(start,0),
                    new PointF(start+w,0),
                    new PointF(start+w,h1),
                    new PointF(start+w+dr,h1),
                    new PointF(start+w+dr,h2),
                    new PointF(start-dl,h2),
                    new PointF(start-dl,h1),
                    new PointF(start,h1),
                };

                Pnts = Pnts.Distinct().ToArray();
                for (int i1 = 0; i1 < Pnts.Length; i1++)
                {
                    int i2 = (i1 + 1) % Pnts.Length;
                    int i3 = (i1 + 2) % Pnts.Length;
                    if (Pnts[i1].X == Pnts[i2].X && Pnts[i2].X == Pnts[i3].X)
                    {
                        Pnts[i2].Y = Pnts[i3].Y;
                    }
                }
                Pnts = Pnts.Distinct().ToArray();


                for (int i1 = 0; i1 < Pnts.Length; i1++)
                {
                    Pnts[i1].X *= 5;
                    Pnts[i1].Y *= 5;
                }


                Path = new System.Drawing.Drawing2D.GraphicsPath();
                for (int i1 = 0; i1 < 8 && i1 < Pnts.Length; i1++)
                {
                    int i2 = (i1 + 1) % Pnts.Length;
                    int i3 = (i1 + 2) % Pnts.Length;
                    if (Pnts[i1].X == Pnts[i2].X)
                    {
                        if (Pnts[i1].Y > Pnts[i2].Y)
                        {
                            Path.AddLine(Pnts[i1].X, Pnts[i1].Y - radius, Pnts[i2].X, Pnts[i2].Y + radius);
                            if (Pnts[i1].X < Pnts[i3].X)
                            {
                                Path.AddArc(new RectangleF(Pnts[i2].X, Pnts[i2].Y, diameter, diameter), 180, 90);
                            }
                            else
                            {
                                //Path.AddArc(new RectangleF(Pnts[i2].X - diameter, Pnts[i2].X, diameter, diameter), 0, 90);
                            }
                        }
                        else
                        {
                            Path.AddLine(Pnts[i1].X, Pnts[i1].Y + radius, Pnts[i2].X, Pnts[i2].Y - radius);
                            if (Pnts[i1].X < Pnts[i3].X)
                            {
                                Path.AddArc(new RectangleF(Pnts[i2].X, Pnts[i2].Y - diameter, diameter, diameter), 180, -90);
                            }
                            else
                            {
                                Path.AddArc(new RectangleF(Pnts[i2].X - diameter, Pnts[i2].Y - diameter, diameter, diameter), 0, 90);
                            }
                        }
                    }
                    else
                    {
                        if (Pnts[i1].X > Pnts[i2].X)
                        {
                            Path.AddLine(Pnts[i1].X - radius, Pnts[i1].Y, Pnts[i2].X + radius, Pnts[i2].Y);
                            if (Pnts[i1].Y < Pnts[i3].Y)
                            {
                                Path.AddArc(new RectangleF(Pnts[i2].X, Pnts[i2].X - diameter, diameter, diameter), 90, 90);
                            }
                            else
                            {
                                Path.AddArc(new RectangleF(Pnts[i2].X, Pnts[i2].Y - diameter, diameter, diameter), 90, 90);
                            }
                        }
                        else
                        {
                            Path.AddLine(Pnts[i1].X + radius, Pnts[i1].Y, Pnts[i2].X - radius, Pnts[i2].Y);
                            if (Pnts[i1].Y < Pnts[i3].Y)
                            {
                                Path.AddArc(new RectangleF(Pnts[i2].X - diameter, Pnts[i2].Y, diameter, diameter), 270, 90);
                            }
                            else
                            {
                                Path.AddArc(new RectangleF(Pnts[i2].X - diameter, Pnts[i2].Y - diameter, diameter, diameter), 90, -90);
                            }
                        }
                    }
                }

                Min = Pnts.Min(o => o.X);
                Max = Pnts.Max(o => o.X);
            }
        }

        public readonly TKey[] Keys;
        public readonly float Max;
        public readonly float Min;

        private void P_EventReceived(object sender, MidiEventReceivedEventArgs e)
        {

            switch (e.Event.EventType)
            {
                case MidiEventType.ActiveSensing:
                    break;
                case MidiEventType.TimingClock:
                    break;
                case MidiEventType.NoteOn:
                    NoteOnEvent noe = (NoteOnEvent)e.Event;
                    Keys[noe.NoteNumber].Velocity = noe.Velocity;
                    NoteEvent?.Invoke(noe.NoteNumber, noe.Velocity);
                    TPianoEvent ev = new TPianoEvent();
                    ev.Number = noe.NoteNumber;
                    if (noe.Velocity == 0)
                        ev.EventType = EChordEventType.Released;
                    else
                        ev.EventType = EChordEventType.Pressed;
                    KeyEvent?.Invoke(ev);
                    break;
                case MidiEventType.NoteOff:
                    break;
                default:
                    break;
            }


        }

        public delegate void KeyEventCallBack(TPianoEvent e);

        public event KeyEventCallBack KeyEvent;

    }

    public class TPianoEvent
    {
        public int Number;
        public EChordEventType EventType;
    }
}
