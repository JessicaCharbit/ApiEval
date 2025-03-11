using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using API.DTO;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    


    public class ArticleController : ControllerBase
    {
        private readonly AchatsContext _dbContext;

        public ArticleController(AchatsContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetArticles")]
        public async Task<ActionResult<List<Article>>> Get()
        {
            var list = await _dbContext.Articles.ToListAsync();
            return list.Count > 0 ? Ok(list) : NotFound();
        }

        [HttpGet("GetArticleById/{id}")]
        public async Task<ActionResult<Article>> GetArticleById(int id)
        {
            var article = await _dbContext.Articles.FindAsync(id);
            return article != null ? Ok(article) : NotFound();
        }

        [HttpPost("InsertArticle")]
        public async Task<ActionResult> InsertArticle([FromBody] Article article)
        {
            _dbContext.Articles.Add(article);
            await _dbContext.SaveChangesAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut("UpdateArticle")]
        public async Task<ActionResult> UpdateArticle([FromBody] Article article)
        {
            var entity = await _dbContext.Articles.FindAsync(article.Id);
            if (entity == null)
                return NotFound();

            entity.Nom = article.Nom;
            entity.Prix = article.Prix;

            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("DeleteArticle/{id}")]
        public async Task<ActionResult> DeleteArticle(int id)
        {
            var entity = await _dbContext.Articles.FindAsync(id);
            if (entity == null)
                return NotFound();

            _dbContext.Articles.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
