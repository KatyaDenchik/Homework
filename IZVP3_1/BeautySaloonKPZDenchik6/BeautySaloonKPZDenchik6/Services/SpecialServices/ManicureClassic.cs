using BeautySaloonKPZDenchik6.Services.Abstact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BeautySaloonKPZDenchik6.Services.SpecialServices
{
    internal class ManicureClassic : Service
    {
        public override Category Category => Category.Manicure;
        public override string Name => "Класичний манiкюр";
        public override double Cost => 200;
        public ManicureClassic()
        {

        }
    }
}
