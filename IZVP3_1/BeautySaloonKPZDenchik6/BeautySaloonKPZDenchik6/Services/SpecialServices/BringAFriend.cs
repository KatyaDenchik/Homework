using BeautySaloonKPZDenchik6.Services.Abstact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BeautySaloonKPZDenchik6.Services.SpecialServices
{
    internal class BringAFriend : ServicesPackage
    {
        public override string PackageName => "Приведи друга";
        public override List<IService> Servies => new List<IService> { new HaircutAndManicure(), new HaircutAndManicure(), new EyebrowCorrection()};
        public override double PackageCost => 400;
        public BringAFriend()
        {

        }
    }
}
