using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class CompteApiController : ControllerBase
{
    private readonly WeTravelContext _context;

    public CompteApiController(WeTravelContext context)
    {
        _context = context;
    }

    // GET: api/AnimalApi
    public async Task<ActionResult<IEnumerable<Compte>>> GetComptes()
    {
        return await _context.Comptes.OrderBy(e => e.Id).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Compte>> GetCompte(int id)
    {
        var compte = await _context.Comptes.Where(s => s.Id == id)
            .SingleOrDefaultAsync();
        if (compte == null)
            return NotFound();
        return compte;
    }

    //Amis à gérer

    [HttpPost]
    public async Task<ActionResult<Compte>> PostCompte(Compte compte)
    {

        // Create new animal in DB
        _context.Comptes.Add(compte);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(PostCompte), new { id = compte.Id }, compte);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutCompte(int id, Compte compte)
    {
        if (id != compte.Id)
            return BadRequest();

        _context.Entry(compte).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CompteExists(id))
                return NotFound();
            else
                throw;
        }
        return NoContent();
    }

    private bool CompteExists(int id)
    {
        return _context.Comptes.Any(m => m.Id == id);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCompte(int id)
    {
        var compte = await _context.Comptes.FindAsync(id);
        if (compte == null)
            return NotFound();

        _context.Comptes.Remove(compte);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}

