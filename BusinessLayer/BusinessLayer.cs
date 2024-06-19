using System.Drawing;
using WebApp.Model;
using WebApp.Model.BildModel;
using WebApp.Model.KategorieModel;
using WebApp.Model.MelderModel;
using WebApp.Model.ModelSichtung;

namespace WebApp.BusinessLayer;

public class BusinessLayer
{
    private readonly IAccessible _dal;
    public BusinessLayer(IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("DefaultConnection");
        _dal = new SqlDal.SqlDal(connectionString);
    }


    #region  Melder

    public async Task<Melder> GetMelderById(int id)
    {
        return await _dal.GetMelderByIdAsync(id);
    }
    
    public async Task<Melder> GetMelderByBenutzername(string benutzername)
    {
        return await _dal.GetMelderByBenutzernameAsync(benutzername);
    }
    
    public async Task<Melder> GetMelderByEmail(string email)
    {
        return await _dal.GetMelderByEmailAsync(email);
    }
    public async Task<List<Melder>> GetAllMelders()
    {
        return await _dal.GetAllMelderAsync();
    }
    public async Task<int> InsertMelder(Melder melder)
    {
        return await _dal.AddMelderAsync(melder);
    }
    
    public async Task<bool> UpdateMelder(Melder melder)
    {
        return await _dal.UpdateMelderAsync(melder);
    }
    
    public async Task<bool> DeleteMelder(int id)
    {
        return await _dal.DeleteMelderAsync(id);
    }

    #endregion

    #region Katgorie
      public async Task<Kategorie> GetKategorieById(int id) 
      {
          return await _dal.GetKategorieByIdAsync(id);
      }
      public async Task<Kategorie> GetKategorieByBezeichnung(string bezeichnung) 
      {
          return await _dal.GetKategorieByBezeichnungAsync(bezeichnung);
      }
      public async Task<List<Kategorie>> GetAllKategories() 
      {
          return await _dal.GetAllKategorieAsync();
      }
        public async Task<int> InsertKategorie(Kategorie kategorie) 
        {
            return await _dal.AddKategorieAsync(kategorie);
        }
        public async Task<bool> UpdateKategorie(Kategorie kategorie) 
        {
            return await _dal.UpdateKategorieAsync(kategorie);
        }
        public async Task<bool> DeleteKategorie(int id) 
        {
            return await _dal.DeleteKategorieAsync(id);
        }

    #endregion
    #region  Sichtung
    public async Task<Sichtung> GetSichtungById(int id)
    {
        return await _dal.GetSichtungByIdAsync(id);
    }
    public async Task<List<Sichtung>> GetAllSichtungs()
    {
        return await _dal.GetAllSichtungAsync();
    }
    public async Task<List<Sichtung>> GetSichtungByKategorieId(int kategorieId)
    {
        return await _dal.GetSichtungByKategorieIdAsync(kategorieId);
    }
    public async Task<List<Sichtung>> GetSichtungByMelderId(int melderId)
    {
        return await _dal.GetSichtungByMelderIdAsync(melderId);
    }
    public async Task<int> InsertSichtung(Sichtung sichtung)
    {
        return await _dal.AddSichtungAsync(sichtung);
    }
    public async Task<bool> UpdateSichtung(Sichtung sichtung)
    {
        return await _dal.UpdateSichtungAsync(sichtung);
    }
    public async Task<bool> DeleteSichtung(int id)
    {
        return await _dal.DeleteSichtungAsync(id);
    }
    #endregion

    #region Bild
    public async Task<Bild> GetBildById(int id)
    {
        return await _dal.GetBildByIdAsync(id);
    }
    
    public async Task<List<Bild>> GetAllBilds()
    {
        return await _dal.GetAllBildAsync();
    }
    public async Task<List<Bild>> GetBildBySichtungId(int sichtungId)
    {
        return await _dal.GetBildBySichtungIdAsync(sichtungId);
    }
    public async Task<int> InsertBild(Bild bild)
    {
        return await _dal.AddBildAsync(bild);
    }
    public async Task<bool> UpdateBild(Bild bild)
    {
        return await _dal.UpdateBildAsync(bild);
    }
    public async Task<bool> DeleteBild(int id)
    {
        return await _dal.DeleteBildAsync(id);
    }
    #endregion
    
    
}