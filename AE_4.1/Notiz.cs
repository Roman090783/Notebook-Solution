namespace Notebook.Share
{
    public enum Kategorie { Alle, Wichtig, Urlaub, Geburtstage, Internet, Sonstiges }

    public class Notiz
    {
        public static Dictionary<Guid, Notiz> Notizen = new Dictionary<Guid, Notiz>();
        public Guid ID { get; private set; }
        public Kategorie Kategorie { get; private set; }
        public string Inhalt { get; set; }
        public DateTime ErstelltAm { get; private set; }

        public Notiz(Kategorie kat, string text)
        {
            this.Kategorie = kat;
            this.Inhalt = text;
            this.ID = Guid.NewGuid();
            this.ErstelltAm = DateTime.Now;
            Notizen.Add(this.ID, this);
        }

        public static bool Entfernen(Notiz notiz) => Notizen.Remove(notiz.ID);
    }
}


