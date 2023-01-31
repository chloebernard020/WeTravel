public class Lieu
{
    public int Id { get; set; }
    public string Nom { get; set; } = null!;
    public string Description { get; set; } = null!;
    public Ville Ville { get; set; } = null!;
    public List<Appreciation> Appreciations { get; set; } = null!;
    public List<Culture>? Cultures { get; set; }
}