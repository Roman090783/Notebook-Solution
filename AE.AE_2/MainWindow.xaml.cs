using System.Windows;

namespace AE.AE_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnFenster1_Click(object sender, RoutedEventArgs e)
        {
            MeinFenster fenster = new MeinFenster();
            fenster.Title = "Nicht-modales Standard-Fenster";
            fenster.Show();
        }
        private void btnFenster2_Click(object sender, RoutedEventArgs e)
        {
            MeinFenster fenster = new MeinFenster();
            fenster.Title = "Modales Fenster, Größe nicht änderbar, immer im Vordergrund";
            fenster.ResizeMode = ResizeMode.NoResize;
            fenster.Topmost = true;
            fenster.ShowDialog();
        }
        private void btnFenster3_Click(object sender, RoutedEventArgs e)
        {
            MeinFenster fenster = new MeinFenster();
            fenster.Title = "Nicht-modales Fenster in der Bildschirmmitte, mit 3DEffekt, Ziehpunkt zur Größenänderung";
            fenster.ResizeMode = ResizeMode.CanResizeWithGrip;
            fenster.WindowStyle = WindowStyle.ThreeDBorderWindow;
            fenster.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            fenster.Show();
        }
        private void btnFenster4_Click(object sender, RoutedEventArgs e)
        {
            MeinFenster fenster = new MeinFenster();
            fenster.Title = "Nicht-modales Tool-Fenster, zentriert über MainWindow, nur minimierbar";
            fenster.ResizeMode = ResizeMode.CanMinimize;
            fenster.WindowStyle = WindowStyle.ToolWindow;
            fenster.Owner = this;
            fenster.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            fenster.Show();
        }


    }
}