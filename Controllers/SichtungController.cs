using Microsoft.AspNetCore.Mvc;
using WebApp.Model.ModelSichtung;

namespace WebApp.Controllers;

public class SichtungController : Controller
{
 private readonly  BusinessLayer.BusinessLayer _business;

 public SichtungController(IConfiguration configuration)
 {
  _business = new BusinessLayer.BusinessLayer(configuration);
 }
   [HttpGet]
            [Route("/api/Sichtung")]
            public async Task<IActionResult> GetSichtungById([FromQuery] int? id)
            {
                try
                {
                    if (!id.HasValue)
                    {
                        try
                        {
                            var sichtung2 = await _business.GetAllSichtungs();
                            return Ok(sichtung2);
                        }
                        catch (Exception)
                        {
                            return StatusCode(500, "Interner Serverfehler");
                        }
                    }

                    var sichtung = await _business.GetSichtungById(id.Value);
                    if (sichtung == null)
                    {
                        return NotFound($"Sichtung mit ID {id} wurde nicht gefunden.");
                    }

                    return Ok(sichtung);
                }
                catch (Exception)
                {
                    return StatusCode(500, "Interner Serverfehler");
                }
            }
        
            [HttpPost]
            [Route("/api/Sichtung")]
            public async Task<IActionResult> AddSichtung([FromBody] Sichtung sichtung)
            {
                try
                {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest("Daten sind nicht korrekt.");
                    }

                    var id = await _business.InsertSichtung(sichtung);
                    return Ok(id);
                }
                catch (Exception)
                {
                    return StatusCode(500, "Interner Serverfehler");
                }
            }
              [HttpPut]
            [Route("/api/Sichtung")]
            public async Task<IActionResult> UpdateSichtung([FromBody] Sichtung sichtung)
            {
                try
                {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest("Daten sind nicht korrekt.");
                    }

                    var success = await _business.UpdateSichtung(sichtung);
                    return Ok(success);
                }
                catch (Exception)
                {
                    return StatusCode(500, "Interner Serverfehler");
                }
            }
         [HttpDelete]
            [Route("/api/Sichtung")]
            public async Task<IActionResult> DeleteSichtung([FromQuery] int id)
            {
                try
                {
                    var success = await _business.DeleteSichtung(id);
                    if (!success)
                    {
                        return NotFound($"Sichtung mit ID {id} wurde nicht gefunden.");
                    }

                    return Ok(success);
                }
                catch (Exception)
                {
                    return StatusCode(500, "Interner Serverfehler");
                }
            }
            [HttpGet]
            [Route("/api/Sichtung/KategorieId")]
            public async Task<IActionResult> GetSichtungByKategorieId([FromQuery] int kategorieId)
            {
                try
                {
                    var sichtung = await _business.GetSichtungByKategorieId(kategorieId);
                    if (sichtung == null)
                    {
                        return NotFound($"Sichtung mit KategorieId {kategorieId} wurde nicht gefunden.");
                    }

                    return Ok(sichtung);
                }
                catch (Exception)
                {
                    return StatusCode(500, "Interner Serverfehler");
                }
            }
             [HttpGet]
            [Route("/api/Sichtung/MelderId")]
            public async Task<IActionResult> GetSichtungByMelderId([FromQuery] int melderId)
            {
                try
                {
                    var sichtung = await _business.GetSichtungByMelderId(melderId);
                    if (sichtung == null)
                    {
                        return NotFound($"Sichtung mit MelderId {melderId} wurde nicht gefunden.");
                    }

                    return Ok(sichtung);
                }
                catch (Exception)
                {
                    return StatusCode(500, "Interner Serverfehler");
                }
            }
 
 
}