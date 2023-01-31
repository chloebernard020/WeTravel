public class Visite
{
    public int Id { get; set; }
    public string Compte { get; set; } = null!;
    public DateTime Date { get; set; }
    public Lieu Lieu { get; set; } = null!;
}