using System.Xml.Serialization;

namespace Total1IZVP
{
    public class Student
    {
        [XmlAttribute] public string name;
        [XmlAttribute] public int yearBirth;
        [XmlAttribute] public string group;
        [XmlAttribute] public int[] grades;
        [XmlAttribute] public double avg;
        public Student() { }
    }
}
