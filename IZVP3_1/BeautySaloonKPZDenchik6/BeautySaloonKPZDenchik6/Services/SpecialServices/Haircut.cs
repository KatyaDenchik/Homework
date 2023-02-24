using BeautySaloonKPZDenchik6.Services.Abstact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BeautySaloonKPZDenchik6.Services.SpecialServices
{
    internal class Haircut : Service
    {
        public override string Name => "Стрижка";
        public override double Cost => 100;
        public override Category Category => Category.Haircut;
        public Haircut()
        {

        }
    }
}
