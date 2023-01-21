using Microsoft.VisualBasic;
using Microsoft.Win32;
using PR2Konst.Entities;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PR2Konst
{
    public class MainVM : BindableBase
    {
        public ObservableCollection<Car> Cars { get; set; }
        public ObservableCollection<Parking> Parkings { get; set; }
        public int SaveTime { get { return AppConfig.Instance.SaveTime / 1000; } set { SetProperty(ref AppConfig.Instance.SaveTime, value * 1000); } }
        public MainVM()
        {
            Parkings = GetParkings();
            UpdateParkings();

            Cars = GetCars();
            UpdateCars();

            Repositiry.Parkings.CollectionChanged += (o, s) =>
            {
                UpdateParkings();
            };

            Repositiry.Cars.CollectionChanged += (o, s) =>
            {
                UpdateCars();
            };
        }

        private void UpdateParkings()
        {
            Parkings.Clear();
            foreach (var parking in GetParkings())
            {
                Parkings.Add(parking);
            }
        }

        private void UpdateCars()
        {
            Cars.Clear();
            foreach (var car in GetCars())
            {
                Cars.Add(car);
            }
        }

        private ObservableCollection<Parking> GetParkings()
        {
            int index = Repositiry.Parkings.Count - 2;
            int range = 2;

            if (index < 0)
            {
                index = 0;
            }
            if (range > Repositiry.Parkings.Count - index)
            {
                range = 0;
            }
            return new ObservableCollection<Parking>(Repositiry.Parkings.ToList().GetRange(index, range));
        }

        private ObservableCollection<Car> GetCars()
        {
            int index = Repositiry.Cars.Count - 2;
            int range = 2;

            if (index < 0)
            {
                index = 0;
            }
            if (Repositiry.Cars.Count == 0)
            {
                range = 0;
            }
            else if (Repositiry.Cars.Count == 1)
            {
                range = 1;
            }
            return new ObservableCollection<Car>(Repositiry.Cars.ToList().GetRange(index, range));
        }

        public Command SaveCommand { get; set; } = new Command(s => { Repositiry.Save(); });
        public Command AddCarCommand { get; set; } = new Command(s => { Repositiry.Cars.Add(new Car()); });
        public Command AddParkingCommand { get; set; } = new Command(s => { Repositiry.Parkings.Add(new Parking()); });
        public Command ShowCarsDBCommand { get; set; } = new Command(s =>
        {
            var path = Environment.CurrentDirectory + Repositiry.Serializer.CarFilePath;

            Interaction.Shell("explorer /open," + path, AppWinStyle.NormalFocus);
        });
        public Command ShowParkingsDBCommand { get; set; } = new Command(s =>
        {
            var path = Environment.CurrentDirectory + Repositiry.Serializer.ParkingFilePath;

            Interaction.Shell("explorer /open," + path, AppWinStyle.NormalFocus);
        });

    }
}
