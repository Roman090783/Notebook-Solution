namespace Notebook.Interfaces;
public enum Kategorie { Alle, Wichtig, Urlaub, Geburtstage, Internet, Sonstiges }

public interface INotiz
{
    Guid ID { get; }
    Kategorie Kategorie { get; }
    string Inhalt { get; set; }
    DateTime ErstelltAm { get; }
    bool Entfernen();
}