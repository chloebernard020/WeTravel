public class Amitie
{
    public int Id { get; set; }
    public Compte Compte1 { get; set; } = null!;
    public Compte Compte2 { get; set; } = null!;
    public int Compte1Id { get; set; }
    public int Compte2Id { get; set; }

    public Amitie() { }
    public Amitie(AmitieDTO dto)
    {
        // Copy DTO field values
        Id = dto.Id;
        Compte1Id = dto.Compte1Id;
        Compte2Id = dto.Compte2Id;
    }
}