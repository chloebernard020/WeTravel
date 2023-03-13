public class Lieu
{
    public int Id { get; set; }
    public string Nom { get; set; } = null!;
    public string Description { get; set; } = null!;
    public Ville Ville { get; set; } = null!;
    public int VilleId { get; set; }
    public string? Photo { get; set; }

    public Lieu() { }
    public Lieu(LieuDTO dto)
    {
        // Copy DTO field values
        Id = dto.Id;
        Nom = dto.Nom;
        Description = dto.Description;
        VilleId = dto.VilleId;
    }

}