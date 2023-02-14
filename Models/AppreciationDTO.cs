public class AppreciationDTO
{
    public int Id { get; set; }
    public string Commentaire { get; set; } = null!;
    public DateTime Date { get; set; }
    public int LieuId { get; set; }

    public int CompteId { get; set; }
}