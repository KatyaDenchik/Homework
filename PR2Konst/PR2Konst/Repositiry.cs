using PR2Konst.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR2Konst
{
    public static class Repositiry
    {
        public static ObservableCollection<Car> Cars { get; set; }
        public static ObservableCollection<Parking> Parkings { get; set; }
        public static ISerializer Serializer => AppConfig.Instance.typeOfSerialiaze switch
        {
            TypeOfSerialiaze.XML => new SerializerToXML(),
            TypeOfSerialiaze.JSON => new SerializerToJSON(),
            TypeOfSerialiaze.BIN => new SerializerToBIN(),
        };

        static Repositiry()
        {
            AppConfig.Instance = Serializer.Deserialiazation<AppConfig>(Serializer.AppConfigFilePath);
            Read();
        }

        public static void Save()
        {
            Serializer.Serialiaze(AppConfig.Instance, Serializer.AppConfigFilePath);
            Serializer.Serialiaze(Cars, Serializer.CarFilePath);
            Serializer.Serialiaze(Parkings, Serializer.ParkingFilePath);

        }

        public static void Read()
        {
            Cars = Serializer.Deserialiazation<ObservableCollection<Car>>(Serializer.CarFilePath);
            Parkings = Serializer.Deserialiazation<ObservableCollection<Parking>>(Serializer.ParkingFilePath);
        }
    }
}
