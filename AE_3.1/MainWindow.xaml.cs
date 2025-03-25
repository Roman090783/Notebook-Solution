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

namespace AE_3._1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            new Notiz(Kategorie.Geburtstage, "Mutter: 18.03.1945");
            new Notiz(Kategorie.Geburtstage, "Vater: 21.08.1940");
            new Notiz(Kategorie.Internet, "www.ibb.com\r\nViele interessante Kurse");
            new Notiz(Kategorie.Urlaub, "Mallorca\r\nwar nicht gut!");
            new Notiz(Kategorie.Wichtig, "Steuererklärung\r\nmuss noch gemacht werden!!!");

            foreach (var kat in Enum.GetValues(typeof(Kategorie)))
                cbxKategorie.Items.Add(kat);

            listeAktualisieren();
        }
        Notiz _AktuelleNotiz;
        public Notiz AktuelleNotiz
        {
            get => _AktuelleNotiz;
            set
            {
                _AktuelleNotiz = value;
                if (value != null) tbxNotiz.Text = value.Inhalt;
                else tbxNotiz.Clear();
                // alternativ: 
                // tbxNotiz.Text = value?.Inhalt ?? "";
            }
        }
        /// <summary> 
        /// zeigt alle Notizen der gewählten Kategorie in der ListBox an 
        /// </summary> 
        void listeAktualisieren()
        {
            // Items sind immer vom Typ object! 
            var gewählteKat = (Kategorie)this.cbxKategorie.SelectedItem;
            // ListBox-Items erstmal entfernen 
            lbxNotizen.Items.Clear();
            // und gem. Kategorie die Liste der Items neu erstellen 
            foreach (Notiz notiz in Notiz.Notizen.Values)
            {
                if (gewählteKat == Kategorie.Alle || notiz.Kategorie == gewählteKat)
                {
                    lbxNotizen.Items.Add(notiz);
                }
            }
        }

        /// <summary> 
        /// aktualisiert die Liste der angezeigten Notizen nach einem Kategorie Wechsel
        /// </summary> 
        private void cbxKategorie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listeAktualisieren();
        }

        /// <summary> 
        /// übernimmt die ausgewählte Notiz zur Bearbeitung 
        /// </summary> 
        private void lbxNotizen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Items sind immer vom Typ object! 
            AktuelleNotiz = lbxNotizen.SelectedItem as Notiz;
        }
    }
}