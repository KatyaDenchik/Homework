using PR2Konst.Loggers;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace PR2Konst
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Logger.Debug("Запуск програми", new Loggers.MessageLogger(), new Loggers.TxtLogger());

            try
            {
                ThrowError();
            }
            catch (Exception e)
            {
                Logger.Info($"{e.Message}", new Loggers.MessageLogger());
            }

            InitializeComponent();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            Repositiry.Save();
            base.OnClosing(e);
        }

        private void SelectedSerializer_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                var item = comboBox.SelectedItem as ComboBoxItem;

                if (item.Content is null) return;

                AppConfig.Instance.typeOfSerialiaze = item.Content.ToString() switch
                {
                    "XML" => TypeOfSerialiaze.XML,
                    "JSON" => TypeOfSerialiaze.JSON,
                    "BIN" => TypeOfSerialiaze.BIN,
                };

            }
        }

        private void ThrowError()
        {
            throw new Exception("Произошла какая-то ошибка");
        }
    }
}
