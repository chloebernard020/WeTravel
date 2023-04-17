using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class AmitieApiController : ControllerBase
{
    private readonly WeTravelContext _context;

    public AmitieApiController(WeTravelContext context)
    {
        _context = context;
    }

    // GET: api/AnimalApi
    public async Task<ActionResult<IEnumerable<Amitie>>> GetAmities()
    {
        return await _context.Amities.OrderBy(e => e.Compte1Id).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Amitie>> GetAmitie(int id)
    {
        var amitie = await _context.Amities.Where(s => s.Id == id)
            .SingleOrDefaultAsync();
        if (amitie == null)
            return NotFound();
        return amitie;
    }

    [HttpGet("parcompte/{compteId}")]
    public async Task<ActionResult<IEnumerable<Amitie>>> GetAmitiesParCompte(int compteId)
    {
        var amities1 = await _context.Amities.Where(s => s.Compte1Id == compteId)
            .Include(s => s.Compte1Id)
            .ToListAsync();

        var amities2 = await _context.Amities.Where(s => s.Compte2Id == compteId)
            .Include(s => s.Compte2Id)
            .ToListAsync();

        var amitiesparcompte = amities1.Union(amities2);

        if (!amitiesparcompte.Any())
            return NotFound();

        return amitiesparcompte.ToList();
    }

    [HttpPost]
    public async Task<ActionResult<Amitie>> PostAmitie(AmitieDTO amitieDTO)
    {
        Amitie amitie = new Amitie(amitieDTO);

        var compte1 = _context.Comptes.Find(amitie.Compte1Id);
        amitie.Compte1 = compte1!;

        var compte2 = _context.Comptes.Find(amitie.Compte2Id);
        amitie.Compte2 = compte2!;
        // Create new animal in DB
        _context.Amities.Add(amitie);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(PostAmitie), new { id = amitie.Id }, amitie);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAmitie(int id, AmitieDTO amitieDTO)
    {
        if (id != amitieDTO.Id)
            return BadRequest();

        Amitie amitie = new Amitie(amitieDTO);

        var compte1 = _context.Comptes.Find(amitie.Compte1Id);
        amitie.Compte1 = compte1!;

        var compte2 = _context.Comptes.Find(amitie.Compte2Id);
        amitie.Compte2 = compte2!;

        _context.Entry(amitie).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Amities.Any(m => m.Id == id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAmitie(int id)
    {
        var amitie = await _context.Amities.FindAsync(id);
        if (amitie == null)
            return NotFound();

        _context.Amities.Remove(amitie);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
