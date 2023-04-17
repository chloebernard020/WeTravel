using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class MessageApiController : ControllerBase
{
    private readonly WeTravelContext _context;

    public MessageApiController(WeTravelContext context)
    {
        _context = context;
    }

    // GET: api/AnimalApi
    public async Task<ActionResult<IEnumerable<Message>>> GetMessages()
    {
        return await _context.Messages.OrderBy(e => e.CompteEnvoyeurId).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Message>> GetMessage(int id)
    {
        var message = await _context.Messages.Where(s => s.Id == id)
            .SingleOrDefaultAsync();
        if (message == null)
            return NotFound();
        return message;
    }

    [HttpGet("parconversation/{conversationId}")]
    public async Task<ActionResult<IEnumerable<Message>>> GetMessagesParConversation(int conversationId)
    {
        var messagesparconversation = await _context.Messages.Where(s => s.ConversationId == conversationId)
            .Include(s => s.ConversationId)
            .ToListAsync();


        if (!messagesparconversation.Any())
            return NotFound();

        return messagesparconversation.ToList();
    }

    [HttpPost]
    public async Task<ActionResult<Message>> PostMessage(MessageDTO messageDTO)
    {
        Message message = new Message(messageDTO);

        var compte1 = _context.Comptes.Find(message.CompteEnvoyeurId);
        message.CompteEnvoyeur = compte1!;

        var compte2 = _context.Comptes.Find(message.CompteReceveurId);
        message.CompteReceveur = compte2!;
        // Create new animal in DB
        _context.Messages.Add(message);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(PostMessage), new { id = message.Id }, message);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutMessage(int id, MessageDTO messageDTO)
    {
        if (id != messageDTO.Id)
            return BadRequest();

        Message message = new Message(messageDTO);

        var compte1 = _context.Comptes.Find(message.CompteEnvoyeurId);
        message.CompteEnvoyeur = compte1!;

        var compte2 = _context.Comptes.Find(message.CompteReceveurId);
        message.CompteReceveur = compte2!;

        _context.Entry(message).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Messages.Any(m => m.Id == id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMessage(int id)
    {
        var message = await _context.Messages.FindAsync(id);
        if (message == null)
            return NotFound();

        _context.Messages.Remove(message);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
