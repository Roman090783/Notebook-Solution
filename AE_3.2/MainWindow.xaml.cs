using System.ComponentModel;
using System.Windows;

namespace AE_3._2
{
    public class Dummy
    {
        public string Property { get; set; } = "Eigenschaft";
        public string GetterOnlyProperty => "konstante Eigenschaft";
    }

    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private int _Wert;
        public int Wert
        {
            get => _Wert;
            set
            {
                _Wert = value;
                OnPropertyChanged();
            }
        }

        public int Zahl { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Dummy dummy = new Dummy();
            this.DataContext = dummy;

            stpChange.DataContext = this;
        }

        private void btnWertInc_Click(object sender, RoutedEventArgs e)
        {
            Wert++;
        }

        private void btnZahlInc_Click(object sender, RoutedEventArgs e)
        {
            Zahl++;
            OnPropertyChanged(nameof(Zahl));
        }
    }
}