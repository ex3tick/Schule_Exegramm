using Microsoft.AspNetCore.Mvc;
using WebApp.Model.KategorieModel;

namespace WebApp.Controllers;

public class KategorieController : Controller
{
    private readonly BusinessLayer.BusinessLayer _business;

    public KategorieController(IConfiguration configuration)
    {
        _business = new BusinessLayer.BusinessLayer(configuration);
    }
    
    
    [HttpGet]
        [Route("/api/Kategorie")]
        public async Task<IActionResult> GetKategorieById([FromQuery] int? id)
        {
            try
            {
                if (!id.HasValue)
                {
                    try
                    {
                        var kategorie2 = await _business.GetAllKategories();
                        return Ok(kategorie2);
                    }
                    catch (Exception)
                    {
                        return StatusCode(500, "Interner Serverfehler");
                    }
                }

                var kategorie = await _business.GetKategorieById(id.Value);
                if (kategorie == null)
                {
                    return NotFound($"Kategorie mit ID {id} wurde nicht gefunden.");
                }

                return Ok(kategorie);
            }
            catch (Exception)
            {
                return StatusCode(500, "Interner Serverfehler");
            }
        }

        [HttpPost]
        [Route("/api/Kategorie")]
        public async Task<IActionResult> AddKategorie([FromBody] Kategorie kategorie)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Daten sind nicht korrekt.");
                }

                var id = await _business.InsertKategorie(kategorie);
                return Ok(id);
            }
            catch (Exception)
            {
                return StatusCode(500, "Interner Serverfehler");
            }
        }

        [HttpPut]
        [Route("/api/Kategorie")]
        public async Task<IActionResult> UpdateKategorie([FromBody] Kategorie kategorie)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Daten sind nicht korrekt.");
                }

                var success = await _business.UpdateKategorie(kategorie);
                return Ok(success);
            }
            catch (Exception)
            {
                return StatusCode(500, "Interner Serverfehler");
            }
        }

        [HttpDelete]
        [Route("/api/Kategorie")]
        public async Task<IActionResult> DeleteKategorie([FromQuery] int id)
        {
            try
            {
                var success = await _business.DeleteKategorie(id);
                if (!success)
                {
                    return NotFound($"Kategorie mit ID {id} wurde nicht gefunden.");
                }

                return Ok(success);
            }
            catch (Exception)
            {
                return StatusCode(500, "Interner Serverfehler");
            }
        }

        [HttpGet]
        [Route("/api/Kategorie/Bezeichnung")]
        public async Task<IActionResult> GetKategorieByBezeichnung([FromQuery] string bezeichnung)
        {
            try
            {
                var kategorie = await _business.GetKategorieByBezeichnung(bezeichnung);
                if (kategorie == null)
                {
                    return NotFound($"Kategorie mit Bezeichnung {bezeichnung} wurde nicht gefunden.");
                }

                return Ok(kategorie);
            }
            catch (Exception)
            {
                return StatusCode(500, "Interner Serverfehler");
            }
        }
}