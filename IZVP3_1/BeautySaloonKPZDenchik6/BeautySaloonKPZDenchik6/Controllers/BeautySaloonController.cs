using BeautySaloonKPZDenchik6.Helpers;
using BeautySaloonKPZDenchik6.Services;
using BeautySaloonKPZDenchik6.Services.Abstact;
using BeautySaloonKPZDenchik6.Services.SpecialServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BeautySaloonKPZDenchik6.Controllers
{
    internal static class BeautySaloonController
    {
        public static ServicesPackage AllServices { get; set; } = new();
        public static string PathToCsv => Assembly.GetExecutingAssembly().Location.Replace($"{Assembly.GetExecutingAssembly().GetName().Name}.dll", "input.csv");
        public static string PathToJson => "db.json";
        static BeautySaloonController()
        {
            //AllServices.PackageName= "Всi послуги:";
            //AllServices.AddServices(new BringAFriend());
            //AllServices.AddServices(new HaircutAndManicure());
            //AllServices.AddServices(new HaircutAndManicure());
            //AllServices.AddServices(new ManicureClassic());
            //AllServices.AddServices(new ManicureKorean());

            //new SerializerToJSON().Serialiaze(AllServices, "db.json");
            AllServices = new SerializerToJSON().Deserialiazation<ServicesPackage>("db.json");
        }

        /// <summary>
        /// Метод, який повертає кількість послуг, які мають відповідне ім'я
        /// </summary>
        /// <param name="name">Ім'я послуги</param>
        /// <returns>Кількість послуг с данним ім'ям</returns>
        public static int GetCountSales(string name)
        {

            var allServices = AllServices.GetServices();

            var foundServices = allServices.Where(s => s.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));


            if (foundServices.Any())
            {
                return foundServices.Count();
            }
            else { return 0; }
        }

        /// <summary>
        /// Метод виводить інформації про кількість кожної послуги до консолі
        /// </summary>
        public static void ShowStatistics() => GetStatisics()
                                                .ToStringColection()
                                                .ToList()
                                                .ForEach(s => Console.WriteLine(s));
        /// <summary>
        /// Метод виводить інформації про топову послугу до консолі
        /// </summary>
        public static void ShowTopService() => Console.WriteLine(
                                                 GetStatisics()
                                                .ToStringColection()
                                                .ElementAt(1));
        /// <summary>
        /// Метод виводить інформації про кількість кожної послуги до csv файлу
        /// </summary>
        public static void PrintStatistics() => GetStatisics()
                                                .WriteToFile("input.csv");

        /// <summary>
        /// Метод формує колекцію, яка містить назву послуги та кількість замовлень цієї послуги
        /// </summary>
        /// <returns>Колекція з інформацією про послуги</returns>
        private static IQueryable GetStatisics() => AllServices
                                                    .GetServices()
                                                    .GroupBy(s => s.Name)
                                                    .Select(s => new { s.Key, Count = s.Count() })
                                                    .OrderByDescending(s => s.Count)
                                                    .AsQueryable();
    }
}
