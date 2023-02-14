public class Visite
{
    public int Id { get; set; }
    public Compte Compte { get; set; } = null!;
    public int CompteId { get; set; }
    public DateTime Date { get; set; }
    public Lieu Lieu { get; set; } = null!;
    public int LieuId { get; set; }
    public Visite() { }
    public Visite(VisiteDTO dto)
    {
        // Copy DTO field values
        Id = dto.Id;
        CompteId = dto.CompteId;
        Date = dto.Date;
        LieuId = dto.LieuId;
    }
}