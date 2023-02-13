public class Ville
{
    public int Id { get; set; }
    public string Nom { get; set; } = null!;
    public Pays Pays { get; set; } = null!;
    public int PaysId { get; set; }
    public List<Lieu> Lieux { get; set; } = null!;

    public Ville() { }
    public Ville(VilleDTO dto)
    {
        // Copy DTO field values
        Id = dto.Id;
        Nom = dto.Nom;
        PaysId = dto.PaysId;
    }
}