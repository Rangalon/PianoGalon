using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace PianoGalon
{

    public class TScore
    {

        [XmlAttribute("id")]
        public uint ExerciceId { get; set; }
        [XmlAttribute("strs")]
        public float StairsMode { get; set; }
        [XmlAttribute("esca")]
        public float EscalatorsMode { get; set; }

        public static readonly float[] Ranges;


        static TScore()
        {
            Ranges = new float[5];
            Ranges[4] = 100;
            Ranges[3] = Ranges[4] / 1.2f;
            Ranges[2] = Ranges[3] / 1.2f;
            Ranges[1] = Ranges[2] / 1.2f;
            Ranges[0] = Ranges[1] / 1.2f;
        }



    }

    public class TProfil
    {

        public static TProfil CurrentProfil;

        public List<TScore> Scores { get; set; } = new List<TScore>();

        public override string ToString()
        {
            return Name;
        }

        public TProfil()
        {
            Name = "New one";
            Profils.Add(this);
        }


        [XmlAttribute]
        public string Name { get; set; }

        [XmlIgnore]
        public Color BckColor { get; set; }


        [XmlAttribute]
        public byte R { get => BckColor.R; set => BckColor = Color.FromArgb(value, BckColor.G, BckColor.B); }
        [XmlAttribute]
        public byte G { get => BckColor.G; set => BckColor = Color.FromArgb(BckColor.R, value, BckColor.B); }
        [XmlAttribute]
        public byte B { get => BckColor.B; set => BckColor = Color.FromArgb(BckColor.R, BckColor.G, value); }

        static TProfil()
        {
            if (System.IO.File.Exists(TLecons.MainDi.FullName + "\\Profils.xml"))
            {
                StreamReader rdr = new StreamReader(TLecons.MainDi.FullName + "\\Profils.xml");
                XmlSerializer XS = new XmlSerializer(typeof(TProfil[]));
                XS.Deserialize(rdr);
                rdr.Close(); rdr.Dispose();
            }

            StairsPaths = new GraphicsPath[5];
            EscalatorsPaths = new GraphicsPath[5];

            for (int i = 0; i < 5; i++)
            {
                float dy = i * 12;
                GraphicsPath path;
                path = new GraphicsPath();
                path.AddArc(new RectangleF(6, 6 + dy, 6, 6), 180, 90);
                path.AddArc(new RectangleF(20, 6 + dy, 6, 6), 270, 90);
                path.AddArc(new RectangleF(20, 10 + dy, 6, 6), 0, 90);
                path.AddArc(new RectangleF(6, 10 + dy, 6, 6), 90, 90);
                path.CloseFigure();
                StairsPaths[i] = path;
                //
                path = new GraphicsPath();
                path.AddArc(new RectangleF(KExerciceButton.OverallSize.Width - 36 + 6, 6 + dy, 6, 6), 180, 90);
                path.AddArc(new RectangleF(KExerciceButton.OverallSize.Width - 36 + 20, 6 + dy, 6, 6), 270, 90);
                path.AddArc(new RectangleF(KExerciceButton.OverallSize.Width - 36 + 20, 10 + dy, 6, 6), 0, 90);
                path.AddArc(new RectangleF(KExerciceButton.OverallSize.Width - 36 + 6, 10 + dy, 6, 6), 90, 90);
                path.CloseFigure();
                EscalatorsPaths[i] = path;
            }



        }

        public static readonly GraphicsPath[] StairsPaths;
        public static readonly GraphicsPath[] EscalatorsPaths;

        public static List<TProfil> Profils = new List<TProfil>();

        public static void Save()
        {
            StreamWriter wtr = new StreamWriter(TLecons.MainDi.FullName + "\\Profils.xml");
            XmlSerializer XS = new XmlSerializer(typeof(TProfil[]));
            XS.Serialize(wtr, Profils.ToArray());
            wtr.Close(); wtr.Dispose();
        }

    }
}
