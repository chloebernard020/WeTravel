public class Ville
{
    public int Id { get; set; }
    public string Nom { get; set; } = null!;
    public List<Lieu> Lieux { get; set; } = null!;
}