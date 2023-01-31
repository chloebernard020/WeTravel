public class Compte
{
    public int Id { get; set; }
    public string Nom { get; set; } = null!;
    public string Prenom { get; set; } = null!;
    public string Mail { get; set; } = null!;
    public string MotDePasse { get; set; } = null!;
    public List<Lieu> Favoris { get; set; } = null!;
    public List<Lieu> Visites { get; set; } = null!;
    public List<Appreciation> Appreciations { get; set; } = null!;
}