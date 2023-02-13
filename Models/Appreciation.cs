public class Appreciation
{
    public int Id { get; set; }
    public string Commentaire { get; set; } = null!;

    public DateTime Date { get; set; }
    public Lieu Lieu { get; set; } = null!;
    public int LieuId { get; set; }
    public Compte Compte { get; set; } = null!;

    public int CompteId { get; set; }

    public Appreciation() { }
    public Appreciation(AppreciationDTO dto)
    {
        // Copy DTO field values
        Id = dto.Id;
        Commentaire = dto.Commentaire;
        LieuId = dto.LieuId;
        CompteId = dto.CompteId;
    }
}