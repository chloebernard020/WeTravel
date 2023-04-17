public class Conversation
{
    public int Id { get; set; }
    public Compte Compte1 { get; set; } = null!;
    public int Compte1Id { get; set; }
    public Compte Compte2 { get; set; } = null!;
    public int Compte2Id { get; set; }

    public Conversation() { }
    public Conversation(ConversationDTO dto)
    {
        // Copy DTO field values
        Id = dto.Id;
        Compte1Id = dto.Compte1Id;
        Compte2Id = dto.Compte2Id;
    }

}