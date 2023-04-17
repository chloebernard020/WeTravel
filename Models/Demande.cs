public class Demande
{
    public int Id { get; set; }
    public Compte CompteDemandeur { get; set; } = null!;
    public Compte CompteReceveur { get; set; } = null!;
    public int CompteDemandeurId { get; set; }
    public int CompteReceveurId { get; set; }

    public Demande() { }
    public Demande(DemandeDTO dto)
    {
        // Copy DTO field values
        Id = dto.Id;
        CompteDemandeurId = dto.CompteDemandeurId;
        CompteReceveurId = dto.CompteReceveurId;
    }
}