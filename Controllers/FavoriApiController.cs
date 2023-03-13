using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class FavoriApiController : ControllerBase
{
    private readonly WeTravelContext _context;

    public FavoriApiController(WeTravelContext context)
    {
        _context = context;
    }

    // GET: api/AnimalApi
    public async Task<ActionResult<IEnumerable<Favori>>> GetFavoris()
    {
        return await _context.Favoris.OrderBy(e => e.CompteId).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Favori>> GetFavori(int id)
    {
        var favori = await _context.Favoris.Where(s => s.Id == id)
            .SingleOrDefaultAsync();
        if (favori == null)
            return NotFound();
        return favori;
    }

    [HttpGet("parcompte/{compteId}")]
    public async Task<ActionResult<IEnumerable<Favori>>> GetFavorisParCompte(int compteId)
    {
        var favorisparcompte = await _context.Favoris.Where(s => s.CompteId == compteId)
            .Include(s => s.Compte)
            .ToListAsync();
        if (favorisparcompte == null)
            return NotFound();
        return favorisparcompte;
    }

    [HttpPost]
    public async Task<ActionResult<Favori>> PostFavori(FavoriDTO favoriDTO)
    {
        Favori favori = new Favori(favoriDTO);


        var lieu = _context.Lieux.Find(favori.LieuId);
        favori.Lieu = lieu!;

        var compte = _context.Comptes.Find(favori.CompteId);
        favori.Compte = compte!;
        // Create new animal in DB
        _context.Favoris.Add(favori);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(PostFavori), new { id = favori.Id }, favori);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutFavori(int id, FavoriDTO favoriDTO)
    {
        if (id != favoriDTO.Id)
            return BadRequest();

        Favori favori = new Favori(favoriDTO);

        var lieu = _context.Lieux.Find(favori.LieuId);
        favori.Lieu = lieu!;

        var compte = _context.Comptes.Find(favori.CompteId);
        favori.Compte = compte!;

        _context.Entry(favori).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Favoris.Any(m => m.Id == id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFavori(int id)
    {
        var favori = await _context.Favoris.FindAsync(id);
        if (favori == null)
            return NotFound();

        _context.Favoris.Remove(favori);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}

