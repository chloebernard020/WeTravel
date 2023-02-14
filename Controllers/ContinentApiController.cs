using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class ContinentApiController : ControllerBase
{
    private readonly WeTravelContext _context;

    public ContinentApiController(WeTravelContext context)
    {
        _context = context;
    }

    // GET: api/AnimalApi
    public async Task<ActionResult<IEnumerable<Continent>>> GetContinents()
    {
        return await _context.Continents.OrderBy(e => e.Nom).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Continent>> GetContinent(int id)
    {
        var continent = await _context.Continents.Where(s => s.Id == id)
            .SingleOrDefaultAsync();
        if (continent == null)
            return NotFound();
        return continent;
    }

    [HttpPost]
    public async Task<ActionResult<Continent>> PostContinent(Continent continent)
    {

        // Create new animal in DB
        _context.Continents.Add(continent);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(PostContinent), new { id = continent.Id }, continent);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutContinent(int id, Continent continent)
    {
        if (id != continent.Id)
            return BadRequest();

        _context.Entry(continent).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ContinentExists(id))
                return NotFound();
            else
                throw;
        }
        return NoContent();
    }

    private bool ContinentExists(int id)
    {
        return _context.Continents.Any(m => m.Id == id);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContinent(int id)
    {
        var continent = await _context.Continents.FindAsync(id);
        if (continent == null)
            return NotFound();

        _context.Continents.Remove(continent);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}

