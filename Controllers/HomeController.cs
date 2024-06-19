using Microsoft.AspNetCore.Mvc;
using WebApp.BusinessLayer;
using WebApp.Model.BildModel;
using WebApp.Model.KategorieModel;
using WebApp.Model.MelderModel;
using WebApp.Model.ModelSichtung;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly BusinessLayer.BusinessLayer _business;

        public HomeController(IConfiguration configuration)
        {
            _business = new BusinessLayer.BusinessLayer(configuration);
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }


        #region Melder

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

        #endregion

        #region Kategorie

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

        #endregion

        #region Sichtung

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
             

        #endregion

        #region  Bild
        
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

        #endregion
    }
}