using BeautySaloonKPZDenchik6.Services.Abstact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BeautySaloonKPZDenchik6.Services.SpecialServices
{ 
    internal class HaircutAndManicure : ServicesPackage
    {
        public override string PackageName => "Стрижка + Класичний маникюр ";
        public override double PackageCost => 250;
        public override List<IService> Servies => new List<IService> { new Haircut(), new ManicureClassic() };
        public HaircutAndManicure()
        {

        }
    }
}
