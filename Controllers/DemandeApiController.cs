using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class DemandeApiController : ControllerBase
{
    private readonly WeTravelContext _context;

    public DemandeApiController(WeTravelContext context)
    {
        _context = context;
    }

    // GET: api/AnimalApi
    public async Task<ActionResult<IEnumerable<Demande>>> GetDemandes()
    {
        return await _context.Demandes.OrderBy(e => e.CompteDemandeurId).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Demande>> GetDemande(int id)
    {
        var demande = await _context.Demandes.Where(s => s.Id == id)
            .SingleOrDefaultAsync();
        if (demande == null)
            return NotFound();
        return demande;
    }

    [HttpPost]
    public async Task<ActionResult<Amitie>> PostDemande(DemandeDTO demandeDTO)
    {
        Demande demande = new Demande(demandeDTO);

        var comptedemandeur = _context.Comptes.Find(demande.CompteDemandeurId);
        demande.CompteDemandeur = comptedemandeur!;

        var comptereceveur = _context.Comptes.Find(demande.CompteReceveurId);
        demande.CompteReceveur = comptereceveur!;
        // Create new animal in DB
        _context.Demandes.Add(demande);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(PostDemande), new { id = demande.Id }, demande);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDemande(int id)
    {
        var demande = await _context.Demandes.FindAsync(id);
        if (demande == null)
            return NotFound();

        _context.Demandes.Remove(demande);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
