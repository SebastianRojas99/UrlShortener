using System;
using Microsoft.AspNetCore.Mvc;
using URLshorter.Entities; 
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authorization;

namespace URLshorter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class XYZController : Controller
    {
        private readonly URLshorterContext _context;

        public XYZController(URLshorterContext context)
        {
            _context = context;
        }

        [HttpPost("crear-url-corta/{categoryId}")]
        public IActionResult ShortenUrl(int categoryId,[FromBody] string originalUrl,int userId)
        {
            if (string.IsNullOrEmpty(originalUrl))
            {
                return BadRequest("La URL original no puede estar vacía.");
            }
            
            var existingUrl = _context.XYZs.SingleOrDefault(x => x.urlOG == originalUrl); 
            if (existingUrl != null)
            {
                return Ok(existingUrl.urlShort); 
            }

            var newShortUrl = GenerateShortUrl();
            var newUrlEntity = new XYZ
            {
                urlOG = originalUrl, 
                urlShort = newShortUrl,
                CategoryId = categoryId,
                UserId  = userId
                
            };

            _context.XYZs.Add(newUrlEntity);
            _context.SaveChanges();

            return Ok(newShortUrl);
        }

        [HttpGet("{shortUrl}")]
        public IActionResult Redirecting([FromRoute] string shortUrl)
        {
            var urlEntity = _context.XYZs.SingleOrDefault(x => x.urlShort == shortUrl);
            if (urlEntity == null)
            {
                return NotFound("La URL corta no se encontró en la base de datos.");
            }
            //suma uno a las visitas cada vez que se pida
            urlEntity.VisitCount++;

            // Guarda los cambios en la base de datos
            _context.SaveChanges();
            return Ok(new { OriginalUrl = urlEntity.urlOG }); 
        }
        [HttpGet("redireccionando-url/{shorter}")]
        public IActionResult RedireccionURL([FromRoute] string shorter)
        {
            var urlEntity = _context.XYZs.SingleOrDefault(x => x.urlShort == shorter);
            if (urlEntity == null)
            {
                return NotFound("La URL corta no se encontró en la base de datos.");
            }

            urlEntity.VisitCount++;
            _context.SaveChanges();

            return new RedirectResult(urlEntity.urlOG);

        }


        [HttpGet("mostrar-visitas-url")]
        public async Task<IActionResult> ShowAllUrlAsync()
        {
            var urlInfoList = await _context.XYZs
                .Select(urlEntity => new
                {
                    OriginalUrl = urlEntity.urlOG,
                    VisitCount = urlEntity.VisitCount
                })
                .ToListAsync();

            return Ok(urlInfoList);
        }

        [HttpGet("mis-url-acortadas")]
        public async Task<IActionResult> ShowAllShortURLAsync()
        {
            var urlInfo = await _context.XYZs.Select(urlEntity => new
            {
                Shorterurl = urlEntity.urlShort,
                OgURL = urlEntity.urlOG,
                CategoryName = urlEntity.Category!= null? urlEntity.Category.CategoryName:"sin categoria",
                UserEmail = urlEntity.User != null ? urlEntity.User.Email : "sin email",
            }).ToListAsync();

            return Ok(urlInfo);
        }
        
        //metodo para generar la url corta
        private string GenerateShortUrl()
        {
            const string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var shortUrl = new char[6];
            

            for (int i = 0; i < 6; i++)
            {
                shortUrl[i] = characters[random.Next(characters.Length)];
            }

            return new string( shortUrl);
            //return new string("https://" + shortUrl + ".com");
        }

    }
}

