using BeautySaloonKPZDenchik6.Loggers;
using BeautySaloonKPZDenchik6.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BeautySaloonKPZDenchik6.Helpers
{
    public static class IQueryableExtension
    {
        /// <summary>
        /// Записує вміст колекції до файлу
        /// </summary>
        /// <param name="collection">Колекція, яку треба записати</param>
        /// <param name="pathToFile">Шлях до файлу, куди слід записати колекцію</param>
        public static void WriteToFile(this IQueryable collection, string pathToFile)
        {
            collection = collection.ToStringColection();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            try
            {
                using (var streamWriter = new StreamWriter(pathToFile, false, Encoding.GetEncoding(1251)))
                {
                    foreach (var entity in collection)
                    {
                        var editedProperties = entity.ToString().Trim(new char[] { '{', '}' });

                        streamWriter.WriteLine(editedProperties);
                        streamWriter.Flush();
                    }
                }
            }
            catch (Exception e)
            {
                Logger.Fatal(e.Message);
            }

        }

        /// <summary>
        /// Метод переформатовує колекції об'єктів до колекції строк, отримавши значення властивостей за допомогою рефлексії
        /// </summary>
        /// <param name="collection">Колекція, яку треба конвертувати</param>
        /// <returns>Колекція строк</returns>
        public static IQueryable<string> ToStringColection(this IQueryable collection)
        {
            var result = new List<string>();

            result.Add("Назва:;Кiлькiсть:");
            foreach (var entity in collection)
            {
                string editedProperties = string.Empty;

                Type type = entity.GetType();

                var props = type.GetProperties();
                foreach (var prop in props)
                {
                    // Спроба отримати значення службових властивостей призведе до виключення типу TargetParameterCountException, яку треба ігнорувати
                    try
                    {
                        var value = prop.GetValue(entity);

                        editedProperties += $"{value}; ";
                    }
                    catch (TargetParameterCountException)
                    {

                    }
                }

                result.Add(editedProperties);
            }
            return result.AsQueryable();
        }

    }
}
