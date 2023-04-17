public class MessageDTO
{
    public int Id { get; set; }
    public string Mess { get; set; } = null!;
    public int ConversationId { get; set; }
    public int CompteEnvoyeurId { get; set; }
    public int CompteReceveurId { get; set; }
}