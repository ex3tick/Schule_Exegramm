using Microsoft.AspNetCore.Mvc;
using WebApp.Model.BildModel;

namespace WebApp.Controllers;

public class BildController : Controller
{
    private readonly BusinessLayer.BusinessLayer _business;

    public BildController(IConfiguration configuration)
    {
        _business = new BusinessLayer.BusinessLayer(configuration);
    }
    [HttpGet]
        [Route("/api/Bild")]
        public async Task<IActionResult> GetBildById([FromQuery] int? id)
        {
            try
            {
                if (!id.HasValue)
                {
                    try
                    {
                        var bild2 = await _business.GetAllBilds();
                        return Ok(bild2);
                    }
                    catch (Exception)
                    {
                        return StatusCode(500, "Interner Serverfehler");
                    }
                }

                var bild = await _business.GetBildById(id.Value);
                if (bild == null)
                {
                    return NotFound($"Bild mit ID {id} wurde nicht gefunden.");
                }

                return Ok(bild);
            }
            catch (Exception)
            {
                return StatusCode(500, "Interner Serverfehler");
            }
        }
        [HttpPost]
        [Route("/api/Bild")]
        public async Task<IActionResult> AddBild([FromBody] Bild bild)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Daten sind nicht korrekt.");
                }

                var id = await _business.InsertBild(bild);
                return Ok(id);
            }
            catch (Exception)
            {
                return StatusCode(500, "Interner Serverfehler");
            }
        }
        [HttpPut]
        [Route("/api/Bild")]
        public async Task<IActionResult> UpdateBild([FromBody] Bild bild)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Daten sind nicht korrekt.");
                }

                var success = await _business.UpdateBild(bild);
                return Ok(success);
            }
            catch (Exception)
            {
                return StatusCode(500, "Interner Serverfehler");
            }
        }
        [HttpDelete]
        [Route("/api/Bild")]
        public async Task<IActionResult> DeleteBild([FromQuery] int id)
        {
            try
            {
                var success = await _business.DeleteBild(id);
                if (!success)
                {
                    return NotFound($"Bild mit ID {id} wurde nicht gefunden.");
                }

                return Ok(success);
            }
            catch (Exception)
            {
                return StatusCode(500, "Interner Serverfehler");
            }
        }
        [HttpGet]
        [Route("/api/Bild/SichtungId")] 
        public async Task<IActionResult> GetBildBySichtungId([FromQuery] int sichtungId)
        {
            try
            {
                var bild = await _business.GetBildBySichtungId(sichtungId);
                if (bild == null)
                {
                    return NotFound($"Bild mit SichtungID {sichtungId} wurde nicht gefunden.");
                }

                return Ok(bild);
            }
            catch (Exception)
            {
                return StatusCode(500, "Interner Serverfehler");
            }
        }
}