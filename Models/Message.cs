public class Message
{
    public int Id { get; set; }
    public string Mess { get; set; } = null!;
    public DateTime Date { get; set; }
    public Conversation Conversation { get; set; } = null!;
    public int ConversationId { get; set; }
    public Compte CompteEnvoyeur { get; set; } = null!;
    public int CompteEnvoyeurId { get; set; }
    public Compte CompteReceveur { get; set; } = null!;
    public int CompteReceveurId { get; set; }

    public Message() { }
    public Message(MessageDTO dto)
    {
        // Copy DTO field values
        Id = dto.Id;
        Mess = dto.Mess;
        ConversationId = dto.ConversationId;
        CompteEnvoyeurId = dto.CompteEnvoyeurId;
        CompteReceveurId = dto.CompteReceveurId;
    }

}