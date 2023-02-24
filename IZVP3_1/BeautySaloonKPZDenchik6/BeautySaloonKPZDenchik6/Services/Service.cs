using BeautySaloonKPZDenchik6.Services.Abstact;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BeautySaloonKPZDenchik6.Services
{
    /// <summary>
    /// Клас послуги, який реалізує інтерфейс для компанування, та містить інформації про послугу
    /// </summary>
    [JsonObject]
    internal class Service : IService
    {
        public virtual Category Category { get; set; }

        public virtual string Name { get; set; }

        public virtual double Cost { get; set; }
        public Service()
        {

        }

        /// <summary>
        /// Метод, повертає коллекцію, яка містить саму послугу
        /// </summary>
        /// <returns>Коллекція з послугою</returns>
        public IEnumerable<Service> GetServices()
        {
            return new List<Service> { this };
        }

    }
}
