using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class VilleApiController : ControllerBase
{
    private readonly WeTravelContext _context;

    public VilleApiController(WeTravelContext context)
    {
        _context = context;
    }

    // GET: api/AnimalApi
    public async Task<ActionResult<IEnumerable<Ville>>> GetVilles()
    {
        return await _context.Villes.OrderBy(e => e.Nom).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Ville>> GetVille(int id)
    {
        var ville = await _context.Villes.Where(s => s.Id == id)
            .SingleOrDefaultAsync();
        if (ville == null)
            return NotFound();
        return ville;
    }

    [HttpGet("parpays/{paysId}")]
    public async Task<ActionResult<IEnumerable<Ville>>> GetVillesParPays(int paysId)
    {
        var villesparpays = await _context.Villes.Where(s => s.PaysId == paysId)
            .Include(s => s.Pays)
            .ToListAsync();
        if (villesparpays == null)
            return NotFound();
        return villesparpays;
    }


    [HttpPost]
    public async Task<ActionResult<Ville>> PostVille(VilleDTO villeDTO)
    {
        Ville ville = new Ville(villeDTO);


        var pays = _context.Pays.Find(ville.PaysId);
        ville.Pays = pays!;
        // Create new animal in DB
        _context.Villes.Add(ville);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(PostVille), new { id = ville.Id }, ville);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutVille(int id, VilleDTO villeDTO)
    {
        if (id != villeDTO.Id)
            return BadRequest();

        Ville ville = new Ville(villeDTO);

        var pays = _context.Pays.Find(ville.PaysId);
        ville.Pays = pays!;

        _context.Entry(ville).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Villes.Any(m => m.Id == id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVille(int id)
    {
        var ville = await _context.Villes.FindAsync(id);
        if (ville == null)
            return NotFound();

        _context.Villes.Remove(ville);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}

