using Microsoft.AspNetCore.Mvc;
using WebApp.Model.MelderModel;

namespace WebApp.Controllers;

public class MelderController : Controller
{
    private  BusinessLayer.BusinessLayer _business;

    public MelderController(IConfiguration configuration)
    {
        _business = new BusinessLayer.BusinessLayer(configuration);
    }
    
  [HttpGet]
        [Route("/api/Melder")]
        public async Task<IActionResult> GetMelderById([FromQuery] int? id)
        {
            try
            {
                if (!id.HasValue)
                {
                    try
                    {
                        var melder2 = await _business.GetAllMelders();
                        return Ok(melder2);
                    }
                    catch (Exception)
                    {
                        return StatusCode(500, "Interner Serverfehler");
                    }
                }

                var melder = await _business.GetMelderById(id.Value);
                if (melder == null)
                {
                    return NotFound($"Melder mit ID {id} wurde nicht gefunden.");
                }

                return Ok(melder);
            }
            catch (Exception)
            {
                return StatusCode(500, "Interner Serverfehler");
            }
        }

        [HttpPost]
        [Route("/api/Melder")]
        public async Task<IActionResult> AddMelder([FromBody] Melder melder)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Daten sind nicht korrekt.");
                }

                var id = await _business.InsertMelder(melder);
                return Ok(id);
            }
            catch (Exception)
            {
                return StatusCode(500, "Interner Serverfehler");
            }
        }

        [HttpPut]
        [Route("/api/Melder")]
        public async Task<IActionResult> UpdateMelder([FromBody] Melder melder)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Daten sind nicht korrekt.");
                }

                var success = await _business.UpdateMelder(melder);
                return Ok(success);
            }
            catch (Exception)
            {
                return StatusCode(500, "Interner Serverfehler");
            }
        }

        [HttpDelete]
        [Route("/api/Melder")]
        public async Task<IActionResult> DeleteMelder([FromQuery] int id)
        {
            try
            {
                var success = await _business.DeleteMelder(id);
                if (!success)
                {
                    return NotFound($"Melder mit ID {id} wurde nicht gefunden.");
                }

                return Ok(success);
            }
            catch (Exception)
            {
                return StatusCode(500, "Interner Serverfehler");
            }
        }

        [HttpGet]
        [Route("/api/Melder/Email")]
        public async Task<IActionResult> GetMelderByEmail([FromQuery] string email)
        {
            try
            {
                var melder = await _business.GetMelderByEmail(email);
                if (melder == null)
                {
                    return NotFound($"Melder mit Email {email} wurde nicht gefunden.");
                }

                return Ok(melder);
            }
            catch (Exception)
            {
                return StatusCode(500, "Interner Serverfehler");
            }
        }

        [HttpGet]
        [Route("/api/Melder/Benutzername")]
        public async Task<IActionResult> GetMelderByBenutzername([FromQuery] string benutzername)
        {
            try
            {
                var melder = await _business.GetMelderByBenutzername(benutzername);
                if (melder == null)
                {
                    return NotFound($"Melder mit Benutzername {benutzername} wurde nicht gefunden.");
                }

                return Ok(melder);
            }
            catch (Exception)
            {
                return StatusCode(500, "Interner Serverfehler");
            }
        }
}