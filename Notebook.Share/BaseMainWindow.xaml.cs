using System.Windows;
using System.Windows.Controls;

namespace Notebook.Share
{
    public partial class BaseMainWindow : UserControl
    {
        public BaseMainWindow()
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

        protected Notiz _AktuelleNotiz = null;
        public Notiz AktuelleNotiz
        {
            get => _AktuelleNotiz;
            set
            {
                _AktuelleNotiz = value;
                if (value != null)
                    tbxNotiz.Text = value.Inhalt;
                else tbxNotiz.Clear();
                tbxNotiz.Text = value?.Inhalt ?? "";
                tbxNotiz.IsEnabled = value != null;
            }
        }

        public void listeAktualisieren()
        {
            Notiz aktuelleNotiz = AktuelleNotiz;

            var gewählteKat = (Kategorie)this.cbxKategorie.SelectedItem;
            lbxNotizen.Items.Clear();
            foreach (Notiz notiz in Notiz.Notizen.Values)
            {
                if (gewählteKat == Kategorie.Alle || notiz.Kategorie == gewählteKat)
                {
                    lbxNotizen.Items.Add(notiz);
                }
            }
            lbxNotizen.SelectedItem = aktuelleNotiz;
        }

        public void cbxKategorie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listeAktualisieren();
            btnNeu.IsEnabled = (Kategorie)cbxKategorie.SelectedItem != Kategorie.Alle;
        }

        public void lbxNotizen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AktuelleNotiz = lbxNotizen.SelectedItem as Notiz;
            btnLöschen.IsEnabled = lbxNotizen.SelectedIndex > -1;
        }

        public void tbxNotiz_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnSpeichern.IsEnabled = AktuelleNotiz != null && tbxNotiz.Text != "";
        }

        public void btnSpeichern_Click(object sender, RoutedEventArgs e)
        {
            AktuelleNotiz.Inhalt = tbxNotiz.Text;
            listeAktualisieren();
            btnSpeichern.IsEnabled = false;
        }

        public void btnLöschen_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Soll die Notiz wirklich gelöscht werden?", "Notiz löschen",
                MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                Notiz.Entfernen(AktuelleNotiz);
                AktuelleNotiz = null;
                listeAktualisieren();
            }
        }

        public void btnNeu_Click(object sender, RoutedEventArgs e)
        {
            AktuelleNotiz = new Notiz((Kategorie)cbxKategorie.SelectedItem, "Neue Notiz");
            listeAktualisieren();
            tbxNotiz.Focus();
            tbxNotiz.SelectAll();
        }

        public void btnBeenden_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // --------------------------------------------------------------------------------------
        // Abhängigkeitseigenschaften / öffentliche Eigenschaften, die Sie im XAML (Neu Project) binden können:

    //    public static readonly DependencyProperty SucheTextProperty =
    //DependencyProperty.Register("SucheText", typeof(string), typeof(BaseMainWindow));

    //    public string SucheText
    //    {
    //        get { return (string)GetValue(SucheTextProperty); }
    //        set { SetValue(SucheTextProperty, value); }
    //    }

    //    public static readonly DependencyProperty SucheButtonContentProperty =
    //        DependencyProperty.Register("SucheButtonContent", typeof(string), typeof(BaseMainWindow));

    //    public string SucheButtonContent
    //    {
    //        get { return (string)GetValue(SucheButtonContentProperty); }
    //        set { SetValue(SucheButtonContentProperty, value); }
    //    }
    }
}
