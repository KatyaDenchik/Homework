using PR2Konst.Loggers;
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
            Logger.Debug("Запуск програми",new ConsoleLogger());
            Repositiry.Read();

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
    }
}
