public class Pays
{
    public int Id { get; set; }
    public string Nom { get; set; } = null!;
    public Continent Continent { get; set; } = null!;
    public List<Ville> Villes { get; set; } = null!;
}