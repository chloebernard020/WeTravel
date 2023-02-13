public class Pays
{
    public int Id { get; set; }
    public string Nom { get; set; } = null!;
    public Continent Continent { get; set; } = null!;
    public int ContinentId { get; set; }
    public List<Ville> Villes { get; set; } = null!;

    public Pays() { }
    public Pays(PaysDTO dto)
    {
        // Copy DTO field values
        Id = dto.Id;
        Nom = dto.Nom;
        ContinentId = dto.ContinentId;
    }

}