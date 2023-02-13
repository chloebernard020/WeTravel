using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class LieuApiController : ControllerBase
{
    private readonly WeTravelContext _context;

    public LieuApiController(WeTravelContext context)
    {
        _context = context;
    }

    // GET: api/AnimalApi
    public async Task<ActionResult<IEnumerable<Lieu>>> GetLieux()
    {
        return await _context.Lieux.OrderBy(e => e.Nom).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Lieu>> GetLieu(int id)
    {
        var lieu = await _context.Lieux.Where(s => s.Id == id)
            .SingleOrDefaultAsync();
        if (lieu == null)
            return NotFound();
        return lieu;
    }

    [HttpGet("parville/{villeId}")]
    public async Task<ActionResult<IEnumerable<Lieu>>> GetLieuxParVille(int villeId)
    {
        var lieuxparville = await _context.Lieux.Where(s => s.VilleId == villeId)
            .Include(s => s.Ville)
            .ToListAsync();
        if (lieuxparville == null)
            return NotFound();
        return lieuxparville;
    }


    [HttpPost]
    public async Task<ActionResult<Lieu>> PostLieu(LieuDTO lieuDTO)
    {
        Lieu lieu = new Lieu(lieuDTO);


        var ville = _context.Villes.Find(lieu.VilleId);
        lieu.Ville = ville!;
        // Create new animal in DB
        _context.Lieux.Add(lieu);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(PostLieu), new { id = lieu.Id }, lieu);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAnimal(int id, LieuDTO lieuDTO)
    {
        if (id != lieuDTO.Id)
            return BadRequest();

        Lieu lieu = new Lieu(lieuDTO);

        var ville = _context.Villes.Find(lieu.VilleId);
        lieu.Ville = ville!;

        _context.Entry(lieu).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Lieux.Any(m => m.Id == id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLieu(int id)
    {
        var lieu = await _context.Lieux.FindAsync(id);
        if (lieu == null)
            return NotFound();

        _context.Lieux.Remove(lieu);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}

