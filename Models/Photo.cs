public class Photo
{
    public int Id { get; set; }
    public string Lien { get; set; } = null!;
    public Compte Compte { get; set; } = null!;
    public int CompteId { get; set; }
    public Lieu Lieu { get; set; } = null!;
    public int LieuId { get; set; }

    public Photo() { }
    public Photo(PhotoDTO dto)
    {
        // Copy DTO field values
        Id = dto.Id;
        Lien = dto.Lien;
        CompteId = dto.CompteId;
        LieuId = dto.LieuId;
    }

}