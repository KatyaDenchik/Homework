using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PR2Konst.Entities
{
    public class Car
    {
        public string Brand { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public Color Color { get; set; } = Color.White;
        public string Owner { get; set; } = string.Empty;
    }

}
