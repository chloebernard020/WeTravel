public class Culture
{
    public int Id { get; set; }
    public string Nom { get; set; } = null!;
    public string Description { get; set; } = null!;
    public Lieu Lieu { get; set; } = null!;
    public int LieuId { get; set; }

    public Culture() { }
    public Culture(CultureDTO dto)
    {
        // Copy DTO field values
        Id = dto.Id;
        Nom = dto.Nom;
        Description = dto.Description;
        LieuId = dto.LieuId;

    }

}