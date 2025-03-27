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
using static System.Net.Mime.MediaTypeNames;

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
                if (value != null)
                    tbxNotiz.Text = value.Inhalt;
                else tbxNotiz.Clear();
                // alternativ: 
                tbxNotiz.Text = value?.Inhalt ?? "";
                tbxNotiz.IsEnabled = value != null; // Optional: Notiz bearbeiten nur, wenn eine Notiz ausgewählt ist
            }
        }

        /// <summary> 
        /// zeigt alle Notizen der gewählten Kategorie in der ListBox an 
        /// </summary> 
        void listeAktualisieren()
        {
            // Notiz bewahren, um sie in am Ende wieder auswählen zu können. 
            Notiz aktuelleNotiz = AktuelleNotiz; // Optional: selektierte Notiz merken

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
            // Suchen der bewahrten Notiz in der neuen Liste. 
            // (IndexOf garantiert Rückgabewert -1, falls nichts gefunden wird 
            //  und SelectedIndex akzeptiert -1, um "Keine Selektion" auszudrücken.) 
            // lbxNotizen.SelectedIndex = lbxNotizen.Items.IndexOf(aktuelleNotiz); // Optional: selektierte Notiz wieder selektieren
            lbxNotizen.SelectedItem = aktuelleNotiz; // Optionale Alternative: selektierte Notiz wieder selektieren

        }

        /// <summary> 
        /// aktualisiert die Liste der angezeigten Notizen nach einem Kategorie Wechsel
        /// </summary> 
        private void cbxKategorie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listeAktualisieren();
            btnNeu.IsEnabled = (Kategorie)cbxKategorie.SelectedItem != Kategorie.Alle; // Neu nur, wenn eine Kategorie ausgewählt ist
        }

        /// <summary> 
        /// übernimmt die ausgewählte Notiz zur Bearbeitung 
        /// </summary> 
        private void lbxNotizen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Items sind immer vom Typ object! 
            AktuelleNotiz = lbxNotizen.SelectedItem as Notiz;
            btnLöschen.IsEnabled = lbxNotizen.SelectedIndex > -1; // Löschen nur, wenn eine Notiz ausgewählt ist
        }

        /// <summary> 
        /// aktiviert Speichern-Button, wenn Text einer ausgewählten Notiz geändert wurde
        /// </summary> 
        private void tbxNotiz_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Speichern ist möglich, wenn 
            btnSpeichern.IsEnabled =
            // 1. eine Notiz vorhanden ist 
            AktuelleNotiz != null &&
            // 2. und Text nicht leer ist 
            tbxNotiz.Text != "";
        }

        /// <summary> 
        /// übernimmt Textänderungen für die aktuelle Notiz 
        /// </summary> 
        private void btnSpeichern_Click(object sender, RoutedEventArgs e)
        {
            // (geänderten) Text übernehmen 
            AktuelleNotiz.Inhalt = tbxNotiz.Text;
            // Anzeige in ListBox aktualisieren 
            listeAktualisieren();
            // Button deaktivieren 
            btnSpeichern.IsEnabled = false;
        }

        // löscht die aktuelle Notiz 
        private void btnLöschen_Click(object sender, RoutedEventArgs e)
        {
            // Sicherheitsabfrage 
            MessageBoxResult result = MessageBox.Show("Soll die Notiz wirklich gelöscht werden ? ", "Notiz löschen",
            MessageBoxButton.YesNo,
            MessageBoxImage.Warning, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                // Notiz aus Auflistung entfernen 
                Notiz.Entfernen(AktuelleNotiz);
                // keine aktuelle Notiz mehr 
                AktuelleNotiz = null;
                listeAktualisieren();
            }
        }

        // erzeugt eine neue Notiz mit der gewählten Kategorie
        private void btnNeu_Click(object sender, RoutedEventArgs e)
        {
            // Neue Notiz mit "Default-Text" 
            AktuelleNotiz = new Notiz((Kategorie)cbxKategorie.SelectedItem, "Neue Notiz");
            listeAktualisieren();
            // Fokus auf TextBox; ermöglicht sofortige Eingabe 
            tbxNotiz.Focus();
            // "Default-Text" selektieren; keine nachträgliche Selektion erforderlich, um Default-Text zu überschreiben
            tbxNotiz.SelectAll();
        }

        // beendet die Anwendung
        private void btnBeenden_Click(object sender, RoutedEventArgs e)
        {
            Close(); // Schließen des letzten (hier: einzigen) Fensters der Anwendung beendet die Anwendung
        }
    }
}