using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class PhotoApiController : ControllerBase
{
    private readonly WeTravelContext _context;

    public PhotoApiController(WeTravelContext context)
    {
        _context = context;
    }

    // GET: api/AnimalApi
    public async Task<ActionResult<IEnumerable<Photo>>> GetPhotos()
    {
        return await _context.Photos.OrderBy(e => e.Id).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Photo>> GetPhoto(int id)
    {
        var photo = await _context.Photos.Where(s => s.Id == id)
            .SingleOrDefaultAsync();
        if (photo == null)
            return NotFound();
        return photo;
    }

    [HttpGet("parlieu/{lieuId}")]
    public async Task<ActionResult<IEnumerable<Photo>>> GetPhotosParLieux(int lieuId)
    {
        var photosparlieu = await _context.Photos.Where(s => s.LieuId == lieuId)
            .Include(s => s.Lieu)
            .ToListAsync();
        if (photosparlieu == null)
            return NotFound();
        return photosparlieu;
    }
    [HttpGet("parcompte/{compteId}")]
    public async Task<ActionResult<IEnumerable<Photo>>> GetAppreciationsParCompte(int compteId)
    {
        var photosparcompte = await _context.Photos.Where(s => s.CompteId == compteId)
            .Include(s => s.Compte)
            .ToListAsync();
        if (photosparcompte == null)
            return NotFound();
        return photosparcompte;
    }
    //Voir comment gérer les appréciations par compte + est ce que les listes sont indispensables ?


    [HttpPost]
    public async Task<ActionResult<Photo>> PostPhoto(PhotoDTO photoDTO)
    {
        Photo photo = new Photo(photoDTO);


        var lieu = _context.Lieux.Find(photo.LieuId);
        photo.Lieu = lieu!;

        var compte = _context.Comptes.Find(photo.CompteId);
        photo.Compte = compte!;
        // Create new animal in DB
        _context.Photos.Add(photo);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(PostPhoto), new { id = photo.Id }, photo);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutPhoto(int id, PhotoDTO photoDTO)
    {
        if (id != photoDTO.Id)
            return BadRequest();

        Photo photo = new Photo(photoDTO);

        var lieu = _context.Lieux.Find(photo.LieuId);
        photo.Lieu = lieu!;

        var compte = _context.Comptes.Find(photo.CompteId);
        photo.Compte = compte!;

        _context.Entry(photo).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Photos.Any(m => m.Id == id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePhoto(int id)
    {
        var photo = await _context.Photos.FindAsync(id);
        if (photo == null)
            return NotFound();

        _context.Photos.Remove(photo);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
