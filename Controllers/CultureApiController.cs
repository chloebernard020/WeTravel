using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class CultureApiController : ControllerBase
{
    private readonly WeTravelContext _context;

    public CultureApiController(WeTravelContext context)
    {
        _context = context;
    }

    // GET: api/AnimalApi
    public async Task<ActionResult<IEnumerable<Culture>>> GetCultures()
    {
        return await _context.Cultures.OrderBy(e => e.Id).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Culture>> GetCulture(int id)
    {
        var culture = await _context.Cultures.Where(s => s.Id == id)
            .SingleOrDefaultAsync();
        if (culture == null)
            return NotFound();
        return culture;
    }

    [HttpGet("parlieu/{lieuId}")]
    public async Task<ActionResult<IEnumerable<Culture>>> GetAppreciationsParLieu(int lieuId)
    {
        var culturesparlieu = await _context.Cultures.Where(s => s.LieuId == lieuId)
            .Include(s => s.Lieu)
            .ToListAsync();
        if (culturesparlieu == null)
            return NotFound();
        return culturesparlieu;
    }
    //Voir comment gérer les appréciations par compte + est ce que les listes sont indispensables ?


    [HttpPost]
    public async Task<ActionResult<Culture>> PostCulture(CultureDTO cultureDTO)
    {
        Culture culture = new Culture(cultureDTO);


        var lieu = _context.Lieux.Find(culture.LieuId);
        culture.Lieu = lieu!;

        // Create new animal in DB
        _context.Cultures.Add(culture);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(PostCulture), new { id = culture.Id }, culture);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutCulture(int id, CultureDTO cultureDTO)
    {
        if (id != cultureDTO.Id)
            return BadRequest();

        Culture culture = new Culture(cultureDTO);

        var lieu = _context.Lieux.Find(culture.LieuId);
        culture.Lieu = lieu!;

        _context.Entry(culture).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Cultures.Any(m => m.Id == id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCulture(int id)
    {
        var culture = await _context.Cultures.FindAsync(id);
        if (culture == null)
            return NotFound();

        _context.Cultures.Remove(culture);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}

