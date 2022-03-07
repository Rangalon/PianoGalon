using MidiGalon;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace PianoGalon
{
    public class TExerciceComparer : IComparer<TExercice>
    {
        public static readonly TExerciceComparer Default = new TExerciceComparer();

        public int Compare(TExercice x, TExercice y)
        {
            return x.Rank.CompareTo(y.Rank);
        }
    }

    public class TExercice
    {
        [XmlAttribute]
        public UInt32 Id { get; set; } = TLecons.GetId();

        [XmlAttribute]
        public UInt32 Rank { get; set; }

        [XmlAttribute]
        public string Name { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: {1}", Rank, Name);
        }

        internal void ImportMuse(string fileName)
        {
            /*
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(fileName);


            List<TPart> lstpart = new List<TPart>();
            foreach (XmlNode xpart in xdoc.SelectNodes("/museScore/Score/Staff"))
            {
                TPart part = new TPart();
                List<TMeasure> lst = new List<TMeasure>();



                STimeSignature LastSignature = new STimeSignature();
                float measurestart = 0;
                foreach (XmlNode xmeasure in xpart.SelectNodes("./Measure"))
                {
                    /////////////////////
                    // Measure...........
                    TMeasure measure = new TMeasure();
                    measure.Start = measurestart;
                    XmlNode xsignature = xmeasure.SelectSingleNode(".//TimeSig");
                    if (xsignature != null)
                    {
                        LastSignature.N = int.Parse(xsignature.SelectSingleNode(".//sigN").InnerText);
                        LastSignature.D = int.Parse(xsignature.SelectSingleNode(".//sigD").InnerText);
                    }
                    measure.Signature = LastSignature;
                    measurestart += (float)LastSignature.N / (float)LastSignature.D;
                    lst.Add(measure);
                    /////////////////
                    // Voices........
                    List<TChord> lstchords = new List<TChord>();
                    foreach (XmlNode xvoice in xmeasure.SelectNodes("./voice"))
                    {
                        float start = 0;
                        /////////////////
                        // Chords........
                        foreach (XmlNode xchord in xmeasure.SelectNodes(".//Chord"))
                        {
                            TChord chord = new TChord();
                            chord.Start = start;
                            xsignature = xchord.SelectSingleNode(".//durationType");
                            switch (xsignature.InnerText)
                            {
                                case "32nd": chord.Duration = 1.0f / 32.0f; break;
                                case "32th": chord.Duration = 1.0f / 32.0f; break;
                                case "16th": chord.Duration = 1.0f / 16.0f; break;
                                case "eighth": chord.Duration = 1.0f / 8.0f; break;
                                case "quarter": chord.Duration = 1.0f / 4.0f; break;
                                case "half": chord.Duration = 1.0f / 2.0f; break;
                                default: throw new Exception(xsignature.InnerText + ": not implemented");
                            }
                            lstchords.Add(chord);
                            start += chord.Duration;
                            /////////////////
                            // Notes.........
                            List<int> lstnotes = new List<int>();
                            foreach (XmlNode xnote in xchord.SelectNodes(".//Note"))
                            {
                                xsignature = xnote.SelectSingleNode(".//pitch");
                                lstnotes.Add(int.Parse(xsignature.InnerText));
                            }
                            chord.Notes = lstnotes.ToArray();
                        }
                    }
                    measure.Chords = lstchords.ToArray();
                }

                part.Measures = lst.ToArray();
                lstpart.Add(part);
            }
            Parts = lstpart.ToArray();
            */
        }

        [XmlArray("Chds")]
        [XmlArrayItem("Chd")]
        public TChord[] Chords = { };
        public void ComputePaths(TPiano piano, List<GraphicsPath> wlst, List<GraphicsPath> blst, List<TChordTarget> ChordTargets)
        {
            foreach (TChord chd in Chords)
                chd.ComputePaths(piano, wlst, blst, ChordTargets);
        }

        internal void ImportMidi(string fileName)
        {
            TMidiFile mfile = new TMidiFile(fileName);
            mfile.Regularize();
            List<TChord> chds = new List<TChord>();
            foreach (TMidiTrack mtrk in mfile.Tracks)
                foreach (TMidiChannel mchn in mtrk.Channels.Where(o=>o!=null))
                    while (mchn.Events.Count > 0)
                    {
                        TMidiEvent e1 = mchn.Events[0]; mchn.Events.RemoveAt(0);
                        TMidiEvent e2 = mchn.Events.First(o => o.Note == e1.Note); mchn.Events.Remove(e2);
                        chds.Add(new TChord() { Duration = 0.001f * (e2.Date - e1.Date), Start = 0.001f * e1.Date, Notes = new int[] { e1.Note } });
                    }
            float r = 0.03f;
            float d = 0.013f;
            float n;
            float s;
            foreach (TChord c in chds)
            {
                n = (c.Duration + d) / r;
                n = (float)Math.Round(n, 0);
                if (n % 1 > 0)
                {
                }
                else
                    switch (n)
                    {
                        case 16:
                            break;
                        case 8:
                            break;
                        case 4:
                            break;
                        case 2:
                            break;
                        case 1:
                            break;
                        default:
                            break;
                    }
                c.Duration = (n * r) - d;
                s = c.Start + c.Duration + d;
                foreach (TChord cc in chds.Where(o => Math.Abs(o.Start - s) < d))
                {
                    float u = cc.Start - s;
                    u = (float)Math.Round(u, 4);
                    if (u != 0)
                    {
                        cc.Start -= u;
                        cc.Duration += u;
                    }
                }
            }
            Chords = chds.ToArray();
        }
    }


}
