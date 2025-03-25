using System.Windows;

namespace AE.AE_2
{
    /// <summary>
    /// Interaction logic for MeinFenster.xaml
    /// </summary>
    public partial class MeinFenster : Window
    {
        public MeinFenster()
        {
            InitializeComponent();
        }
        private void btnSchließen_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnAbbrechen_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
            "Wollen Sie wirklich abbrechen?", // Meldungstext
            "Abbruch", // Fenster-Titel
            MessageBoxButton.YesNo, // angezeigte Standard-Buttons
            MessageBoxImage.Stop, // angezeigtes Icon
            MessageBoxResult.No // Default-Button bei EnterTaste
            );
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        // -------------- Optional --------------------------------
        //private void btnSchließen_Click(object sender, RoutedEventArgs e)
        //{
        //    if (System.Windows.Interop.ComponentDispatcher.IsThreadModal)
        //        this.DialogResult = true;
        //    this.Close();
        //}
        //private void btnAbbrechen_Click(object sender, RoutedEventArgs e)
        //{
        //    MessageBoxResult result = MessageBox.Show(
        //    "Wollen Sie wirklich abbrechen?", // Meldungstext
        //    "Abbruch", // Fenster-Titel
        //    MessageBoxButton.YesNo, // angezeigte Standard-Buttons
        //    MessageBoxImage.Stop, // angezeigtes Icon
        //    MessageBoxResult.No // Default-Button bei EnterTaste
        //    );
        //    if (result == MessageBoxResult.Yes)
        //    {
        //        // DialogResult darf bei nicht-modal geöffneten Fenstern NICHT zugewiesen werden -> Laufzeitfehler!
        //        // Modalität kann über ComponentDispatcher festgestellt werden
        //        if (System.Windows.Interop.ComponentDispatcher.IsThreadModal)
        //            this.DialogResult = false;
        //        this.Close();
        //    }
        //}
        //private void btnFenster2_Click(object sender, RoutedEventArgs e)
        //{
        //    MeinFenster fenster = new MeinFenster();
        //    fenster.Title = "Modales Fenster, Größe nicht änderbar, immer im Vordergrund";
        //    fenster.ResizeMode = ResizeMode.NoResize;
        //    fenster.Topmost = true;
        //    var result = fenster.ShowDialog();
        //    MessageBox.Show($"Das Dialog-Fenster hat {result} zurückgegeben.");
        //}
    }
}
