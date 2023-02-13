using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class PaysApiController : ControllerBase
{
    private readonly WeTravelContext _context;

    public PaysApiController(WeTravelContext context)
    {
        _context = context;
    }

    // GET: api/AnimalApi
    public async Task<ActionResult<IEnumerable<Pays>>> GetPays()
    {
        return await _context.Pays.OrderBy(e => e.Nom).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Pays>> GetPays(int id)
    {
        var pays = await _context.Pays.Where(s => s.Id == id)
            .SingleOrDefaultAsync();
        if (pays == null)
            return NotFound();
        return pays;
    }

    [HttpGet("parcontinent/{continentId}")]
    public async Task<ActionResult<IEnumerable<Pays>>> GetPaysParContinent(int continentId)
    {
        var paysparcontinent = await _context.Pays.Where(s => s.ContinentId == continentId)
            .Include(s => s.Continent)
            .ToListAsync();
        if (paysparcontinent == null)
            return NotFound();
        return paysparcontinent;
    }


    [HttpPost]
    public async Task<ActionResult<Pays>> PostPays(PaysDTO paysDTO)
    {
        Pays pays = new Pays(paysDTO);


        var continent = _context.Continents.Find(pays.ContinentId);
        pays.Continent = continent!;
        // Create new animal in DB
        _context.Pays.Add(pays);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(PostPays), new { id = pays.Id }, pays);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutPays(int id, PaysDTO paysDTO)
    {
        if (id != paysDTO.Id)
            return BadRequest();

        Pays pays = new Pays(paysDTO);

        var continent = _context.Continents.Find(pays.ContinentId);
        pays.Continent = continent!;

        _context.Entry(pays).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Pays.Any(m => m.Id == id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePays(int id)
    {
        var pays = await _context.Pays.FindAsync(id);
        if (pays == null)
            return NotFound();

        _context.Pays.Remove(pays);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}

