using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySaloonKPZDenchik6.Services.Abstact
{ 
    /// <summary>
    /// Інтерфейс для компанування послуг та пакетів послуг
    /// </summary>
    internal interface IService
    {
        /// <summary>
        /// Метод, повертає коллекцію вкладенних у пакет послуг, якщо пакет містить інші пакети - вони також будуть розпаковані
        /// </summary>
        /// <returns>Коллекція всіх послуг, які пістить данний пакет</returns>
        IEnumerable<Service> GetServices();
    }
}
