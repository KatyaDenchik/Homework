using BeautySaloonKPZDenchik6.Services.Abstact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BeautySaloonKPZDenchik6.Services.SpecialServices
{
    internal class ManicureKorean : Service
    {
        public override Category Category => Category.Manicure;
        public override string Name => "Корейский манiкюр";
        public override double Cost => 300;
        public ManicureKorean()
        {

        }
    }
}
