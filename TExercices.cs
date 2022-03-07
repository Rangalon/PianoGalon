using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PianoGalon
{
  public  class TExercices
    {

        [XmlAttribute]
        public UInt32 Id { get; set; } = TLecons.GetId();

        [XmlAttribute]
        public string Name { get; set; }

        public List<TExercice> Exercices = new List<TExercice>();

        public override string ToString()
        {
            return Name;
        }


    }
}
