using EBookStore.API.Models;
using EBookStore.API.Models.Dto;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EBookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly BookStoreDbContext _db;
        private readonly ILogger<AuthorController> logger;

        public AuthorController(BookStoreDbContext db, ILogger<AuthorController> logger)
        {
            this._db = db;
            this.logger = logger;
            ConfigureMapping();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetAuthorDto>>> GetAuthors()
        {
            logger.LogInformation($"Request to {nameof(GetAuthors)} to get all authors");
            try
            {
                var result = await _db.Authors.ToListAsync();
                var AuthorsDto = result.Adapt<IEnumerable<GetAuthorDto>>();
                return Ok(AuthorsDto);
            }
            catch(Exception ex)
            {
                logger.LogError(ex, $"Error Performing Get in {nameof(GetAuthors)}");
                return BadRequest(ex);
            }
         
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetAuthorDto>> GetAuthor(int id)
        {
            logger.LogInformation($"Request to {nameof(GetAuthor)} to get author");
            try
            {
                var result = await _db.Authors.FirstOrDefaultAsync(x => x.Id == id);
                if (result == null)
                {
                    return NotFound();
                }
                var AuthorDto = result.Adapt<GetAuthorDto>();
                return Ok(AuthorDto);
            }
            catch(Exception ex)
            {
                logger.LogError(ex, $"Error Performing Get in {nameof(GetAuthor)}");
                return BadRequest(ex);
            }
          
        }

        [HttpPost]
        public async Task<ActionResult> AddAuthor(AddAuthorDto model)
        {
            logger.LogInformation($"Request to {nameof(AddAuthor)} to add new author");
            try
            {
                var newAuthor = new Author();
                newAuthor = model.Adapt<Author>();
                await _db.Authors.AddAsync(newAuthor);
                await _db.SaveChangesAsync();

                return CreatedAtAction(nameof(GetAuthor), new { id = newAuthor.Id }, newAuthor);
            }
          catch(Exception ex)
            {
                logger.LogError(ex, $"Error Performing Add in {nameof(AddAuthor)}");
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAuthor(int id)
        {
            logger.LogError($"Request to {nameof(DeleteAuthor)} to delete author");

            try
            {
                var Author = await _db.Authors.FindAsync(id);
                if (Author == null)
                    return NotFound();

                _db.Authors.Remove(Author);
                await _db.SaveChangesAsync();
                return Ok("Author is deleted");
            }
            catch(Exception ex)
            {
                logger.LogError(ex, $"Error Performing Delete in {nameof(DeleteAuthor)}");
                return BadRequest(ex);
            }
     
        }


        #region Helper Methods
        protected static void ConfigureMapping()
        {
            TypeAdapterConfig<GetAuthorDto, Author>.NewConfig();
        }
        #endregion
    }
}
