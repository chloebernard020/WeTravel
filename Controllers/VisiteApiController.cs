using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class VisiteApiController : ControllerBase
{
    private readonly WeTravelContext _context;

    public VisiteApiController(WeTravelContext context)
    {
        _context = context;
    }

    // GET: api/AnimalApi
    public async Task<ActionResult<IEnumerable<Visite>>> GetVisites()
    {
        return await _context.Visites.OrderBy(e => e.Date).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Visite>> GetVisite(int id)
    {
        var visite = await _context.Visites.Where(s => s.Id == id)
            .SingleOrDefaultAsync();
        if (visite == null)
            return NotFound();
        return visite;
    }

    [HttpGet("parlieu/{lieuId}")]
    public async Task<ActionResult<IEnumerable<Visite>>> GetVisitesParLieu(int lieuId)
    {
        var visitesparlieu = await _context.Visites.Where(s => s.LieuId == lieuId)
            .Include(s => s.Lieu)
            .ToListAsync();
        if (visitesparlieu == null)
            return NotFound();
        return visitesparlieu;
    }
    [HttpGet("parcompte/{compteId}")]
    public async Task<ActionResult<IEnumerable<Visite>>> GetVisitesParCompte(int compteId)
    {
        var visitesparcompte = await _context.Visites.Where(s => s.CompteId == compteId)
            .Include(s => s.Compte)
            .ToListAsync();
        if (visitesparcompte == null)
            return NotFound();
        return visitesparcompte;
    }

    [HttpPost]
    public async Task<ActionResult<Visite>> PostVisite(VisiteDTO visiteDTO)
    {
        Visite visite = new Visite(visiteDTO);


        var lieu = _context.Lieux.Find(visite.LieuId);
        visite.Lieu = lieu!;

        var compte = _context.Comptes.Find(visite.CompteId);
        visite.Compte = compte!;
        // Create new animal in DB
        _context.Visites.Add(visite);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(PostVisite), new { id = visite.Id }, visite);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutVisite(int id, VisiteDTO visiteDTO)
    {
        if (id != visiteDTO.Id)
            return BadRequest();

        Visite visite = new Visite(visiteDTO);

        var lieu = _context.Lieux.Find(visite.LieuId);
        visite.Lieu = lieu!;

        var compte = _context.Comptes.Find(visite.CompteId);
        visite.Compte = compte!;

        _context.Entry(visite).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Visites.Any(m => m.Id == id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVisite(int id)
    {
        var visite = await _context.Visites.FindAsync(id);
        if (visite == null)
            return NotFound();

        _context.Visites.Remove(visite);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}

