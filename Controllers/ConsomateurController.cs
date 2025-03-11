using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using API.DTO;

[ApiController]
[Route("api/[controller]")]
public class ConsomateurController : Controller
{
    private readonly AchatsContext _dbContext;

    public ConsomateurController(AchatsContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("GetConsomateurs")]
    public async Task<ActionResult<List<Consomateur>>> Get()
    {
        var list = await _dbContext.Set<Consomateur>().ToListAsync();
        return list.Count > 0 ? Ok(list) : NotFound();
    }

    [HttpGet("GetConsomateurById/{id}")]
    public async Task<ActionResult<Consomateur>> GetConsomateurById(int id)
    {
        var consomateur = await _dbContext.Set<Consomateur>().FindAsync(id);
        return consomateur != null ? Ok(consomateur) : NotFound();
    }

    [HttpPost("InsertConsomateur")]
    public async Task<ActionResult> InsertConsomateur(Consomateur consomateur)
    {
        _dbContext.Set<Consomateur>().Add(consomateur);
        await _dbContext.SaveChangesAsync();
        return StatusCode((int)HttpStatusCode.Created);
    }

    [HttpPut("UpdateConsomateur")]
    public async Task<ActionResult> UpdateConsomateur(Consomateur consomateur)
    {
        var entity = await _dbContext.Set<Consomateur>().FindAsync(consomateur.Id);
        if (entity == null)
            return NotFound();

        entity.Nom = consomateur.Nom;
        entity.Age = consomateur.Age;
        entity.Adresse = consomateur.Adresse;

        await _dbContext.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete("DeleteConsomateur/{id}")]
    public async Task<ActionResult> DeleteConsomateur(int id)
    {
        var entity = await _dbContext.Set<Consomateur>().FindAsync(id);
        if (entity == null)
            return NotFound();

        _dbContext.Set<Consomateur>().Remove(entity);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}
