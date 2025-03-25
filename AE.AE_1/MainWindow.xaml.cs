using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AE.AE_1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Button button = new Button
            {
                Content = "Klick mich",
                Height = 50,
                Width= 80 
            };
            grdMain.Children.Add(button);

            // ---------------- Optional -------------------------
            button.Foreground = Brushes.DarkRed;
            RadialGradientBrush radial = new RadialGradientBrush();
            radial.GradientStops.Add(new GradientStop
            {
                Color =
           Colors.LightGoldenrodYellow,
                Offset = 0
            });
            radial.GradientStops.Add(new GradientStop
            {
                Color = Colors.Goldenrod,
                Offset = 0.75
            });
            radial.GradientStops.Add(new GradientStop
            {
                Color =
           Colors.DarkGoldenrod,
                Offset = 0.9
            });
            button.Background = radial;
        }

    }
}