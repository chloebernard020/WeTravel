public class Continent
{
    public int Id { get; set; }
    public string Nom { get; set; } = null!;
    public List<Pays> Pays { get; set; } = null!;
}