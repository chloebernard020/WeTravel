using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class ConversationApiController : ControllerBase
{
    private readonly WeTravelContext _context;

    public ConversationApiController(WeTravelContext context)
    {
        _context = context;
    }

    // GET: api/AnimalApi
    public async Task<ActionResult<IEnumerable<Conversation>>> GetConversations()
    {
        return await _context.Conversations.OrderBy(e => e.Compte1Id).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Conversation>> GetConversation(int id)
    {
        var conversation = await _context.Conversations.Where(s => s.Id == id)
            .SingleOrDefaultAsync();
        if (conversation == null)
            return NotFound();
        return conversation;
    }

    [HttpGet("parcompte/{compteId}")]
    public async Task<ActionResult<IEnumerable<Conversation>>> GetConversationsParCompte(int compteId)
    {
        var conversation1 = await _context.Conversations.Where(s => s.Compte1Id == compteId)
            .Include(s => s.Compte1Id)
            .ToListAsync();

        var conversation2 = await _context.Conversations.Where(s => s.Compte2Id == compteId)
            .Include(s => s.Compte2Id)
            .ToListAsync();

        var conversationsparcompte = conversation1.Union(conversation2);

        if (!conversationsparcompte.Any())
            return NotFound();

        return conversationsparcompte.ToList();
    }

    [HttpPost]
    public async Task<ActionResult<Conversation>> PostConversation(ConversationDTO conversationDTO)
    {
        Conversation conversation = new Conversation(conversationDTO);

        var compte1 = _context.Comptes.Find(conversation.Compte1Id);
        conversation.Compte1 = compte1!;

        var compte2 = _context.Comptes.Find(conversation.Compte2Id);
        conversation.Compte2 = compte2!;
        // Create new animal in DB
        _context.Conversations.Add(conversation);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(PostConversation), new { id = conversation.Id }, conversation);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutConversation(int id, ConversationDTO conversationDTO)
    {
        if (id != conversationDTO.Id)
            return BadRequest();

        Conversation conversation = new Conversation(conversationDTO);

        var compte1 = _context.Comptes.Find(conversation.Compte1Id);
        conversation.Compte1 = compte1!;

        var compte2 = _context.Comptes.Find(conversation.Compte2Id);
        conversation.Compte2 = compte2!;

        _context.Entry(conversation).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Conversations.Any(m => m.Id == id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteConversation(int id)
    {
        var conversation = await _context.Conversations.FindAsync(id);
        if (conversation == null)
            return NotFound();

        _context.Conversations.Remove(conversation);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
