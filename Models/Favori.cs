public class Favori
{
    public int Id { get; set; }
    public Compte Compte { get; set; } = null!;
    public int CompteId { get; set; }
    public Lieu Lieu { get; set; } = null!;
    public int LieuId { get; set; }
    public Favori() { }
    public Favori(FavoriDTO dto)
    {
        // Copy DTO field values
        Id = dto.Id;
        CompteId = dto.CompteId;
        LieuId = dto.LieuId;
    }
}