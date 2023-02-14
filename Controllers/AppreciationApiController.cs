using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class AppreciationApiController : ControllerBase
{
    private readonly WeTravelContext _context;

    public AppreciationApiController(WeTravelContext context)
    {
        _context = context;
    }

    // GET: api/AnimalApi
    public async Task<ActionResult<IEnumerable<Appreciation>>> GetAppreciations()
    {
        return await _context.Appreciations.OrderBy(e => e.Date).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Appreciation>> GetAppreciation(int id)
    {
        var appreciation = await _context.Appreciations.Where(s => s.Id == id)
            .SingleOrDefaultAsync();
        if (appreciation == null)
            return NotFound();
        return appreciation;
    }

    [HttpGet("parlieu/{lieuId}")]
    public async Task<ActionResult<IEnumerable<Appreciation>>> GetAppreciationsParLieux(int lieuId)
    {
        var appreciationsparlieu = await _context.Appreciations.Where(s => s.LieuId == lieuId)
            .Include(s => s.Lieu)
            .ToListAsync();
        if (appreciationsparlieu == null)
            return NotFound();
        return appreciationsparlieu;
    }
    [HttpGet("parcompte/{compteId}")]
    public async Task<ActionResult<IEnumerable<Appreciation>>> GetAppreciationsParCompte(int compteId)
    {
        var appreciationsparcompte = await _context.Appreciations.Where(s => s.CompteId == compteId)
            .Include(s => s.Compte)
            .ToListAsync();
        if (appreciationsparcompte == null)
            return NotFound();
        return appreciationsparcompte;
    }
    //Voir comment gérer les appréciations par compte + est ce que les listes sont indispensables ?


    [HttpPost]
    public async Task<ActionResult<Appreciation>> PostAppreciation(AppreciationDTO appreciationDTO)
    {
        Appreciation appreciation = new Appreciation(appreciationDTO);


        var lieu = _context.Lieux.Find(appreciation.LieuId);
        appreciation.Lieu = lieu!;

        var compte = _context.Comptes.Find(appreciation.CompteId);
        appreciation.Compte = compte!;
        // Create new animal in DB
        _context.Appreciations.Add(appreciation);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(PostAppreciation), new { id = appreciation.Id }, appreciation);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAppreciation(int id, AppreciationDTO appreciationDTO)
    {
        if (id != appreciationDTO.Id)
            return BadRequest();

        Appreciation appreciation = new Appreciation(appreciationDTO);

        var lieu = _context.Lieux.Find(appreciation.LieuId);
        appreciation.Lieu = lieu!;

        var compte = _context.Comptes.Find(appreciation.CompteId);
        appreciation.Compte = compte!;

        _context.Entry(appreciation).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Appreciations.Any(m => m.Id == id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAppreciation(int id)
    {
        var appreciation = await _context.Appreciations.FindAsync(id);
        if (appreciation == null)
            return NotFound();

        _context.Appreciations.Remove(appreciation);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}

