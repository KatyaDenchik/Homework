using BeautySaloonKPZDenchik6.Services.Abstact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BeautySaloonKPZDenchik6.Services.SpecialServices
{
    internal class EyebrowCorrection : Service
    {
        public override Category Category => Category.EyebrowFixing;
        public override string Name => "Корекцiя бров";
        public override double Cost => 150;
        public EyebrowCorrection()
        {

        }
    }
}
