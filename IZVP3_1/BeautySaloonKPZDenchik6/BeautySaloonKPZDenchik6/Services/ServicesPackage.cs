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
    /// Клас пакету послуг, який містить інформації про пакет та реалізує інтерфейс для компанування послуг та інших пакетів
    /// </summary>
    [JsonObject]
    internal class ServicesPackage : IService
    {
        public virtual string PackageName { get; set; }

        public virtual double PackageCost { get; set; }

        public virtual List<IService> Servies { get; set; } = new List<IService>();
        public ServicesPackage()
        {

        }

        /// <summary>
        /// Метод, повертає коллекцію вкладенних у пакет послуг, якщо пакет містить інші пакети - вони також будуть розпаковані
        /// </summary>
        /// <returns>Коллекція всіх послуг, які пістить данний пакет</returns>
        public IEnumerable<Service> GetServices()
        {
            var services = new List<Service>();

            var innerServices = Servies.Select(s => s.GetServices());
            innerServices.ToList().ForEach(s => services.AddRange(s));

            return services;
        }

        /// <summary>
        /// Метод, який додає нову послугу до пакету
        /// </summary>
        /// <param name="service">Послуга, яку потрібно додати</param>
        public void AddServices(IService service) => Servies.Add(service);

        /// <summary>
        /// Метод, який видаляє послугу з пакету
        /// </summary>
        /// <param name="service">Послуга, яку потрібно видалити</param>
        public void DeleteServices(IService service) => Servies.Remove(service);

    }

}
