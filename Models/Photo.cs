public class Photo
{
    public int Id { get; set; }
    public string Lien { get; set; } = null!;
    public string Compte { get; set; } = null!;
    public Lieu Lieu { get; set; } = null!;
}