using Dapper;
using MySql.Data.MySqlClient;
using WebApp.Model;
using WebApp.Model.BildModel;
using WebApp.Model.KategorieModel;
using WebApp.Model.MelderModel;
using WebApp.Model.ModelSichtung;






namespace WebApp.SqlDal
{
    // das ist zum austellen der warnings weil mich das nervt
#pragma warning  disable 
 public class SqlDal : IAccessible
    {
        private readonly string _connectionString;

        public SqlDal(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<Melder> GetMelderByIdAsync(int id)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    string sql = "SELECT * FROM Melder WHERE MId = @MId";
                    Melder melder = await connection.QueryFirstOrDefaultAsync<Melder>(sql, new { MId = id });
                    return melder;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Melder> GetMelderByBenutzernameAsync(string benutzername)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    string sql = "SELECT * FROM Melder WHERE Benutzername = @Benutzername";
                    Melder melder =
                        await connection.QueryFirstOrDefaultAsync<Melder>(sql, new { Benutzername = benutzername });
                    return melder;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Melder> GetMelderByEmailAsync(string email)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    string sql = "SELECT * FROM Melder WHERE Email = @Email";
                    Melder melder = await connection.QueryFirstOrDefaultAsync<Melder>(sql, new { Email = email });
                    return melder;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<Melder>> GetAllMelderAsync()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    string sql = "SELECT * FROM Melder";
                    var melder = await connection.QueryAsync<Melder>(sql);
                    return melder.ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<int> AddMelderAsync(Melder melder)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    string sql = 
                        @"INSERT INTO Melder (Name, KennwortHash, Salt, IsAktiv, IsAdmin, RegDatum, Email, Benutzername) 
                  VALUES (@Name, @KennwortHash, @Salt, @IsAktiv, @IsAdmin, @RegDatum, @Email, @Benutzername);
                  SELECT LAST_INSERT_ID();";
                    int result = await connection.QuerySingleAsync<int>(sql, melder);
                    return result;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"General Error: {e.Message}");
                throw;
            }
        }

        public async Task<bool> UpdateMelderAsync(Melder melder)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    string sql = 
                        @"UPDATE Melder SET Name = @Name, KennwortHash = @KennwortHash, Salt = @Salt, IsAktiv = @IsAktiv, IsAdmin = @IsAdmin, RegDatum = @RegDatum, Email = @Email, Benutzername = @Benutzername WHERE MId = @MId";
                    int result = await connection.ExecuteAsync(sql, melder);
                    return result > 0;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> DeleteMelderAsync(int id)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    string sql = "DELETE FROM Melder WHERE MId = @MId";
                    int result = await connection.ExecuteAsync(sql, new { MId = id });
                    return result > 0;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Kategorie> GetKategorieByIdAsync(int id)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    string sql = "SELECT * FROM Kategorie WHERE KId = @KId";
                    Kategorie kategorie = await connection.QueryFirstOrDefaultAsync<Kategorie>(sql, new { KId = id });
                    return kategorie;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Kategorie> GetKategorieByBezeichnungAsync(string bezeichnung)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    string sql = "SELECT * FROM Kategorie WHERE Bezeichnung = @Bezeichnung";
                    Kategorie kategorie =
                        await connection.QueryFirstOrDefaultAsync<Kategorie>(sql, new { Bezeichnung = bezeichnung });
                    return kategorie;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<Kategorie>> GetAllKategorieAsync()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    string sql = "SELECT * FROM Kategorie";
                    var kategorie = await connection.QueryAsync<Kategorie>(sql);
                    return kategorie.ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<int> AddKategorieAsync(Kategorie kategorie)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    string sql = "INSERT INTO Kategorie (Bezeichnung) VALUES (@Bezeichnung); SELECT LAST_INSERT_ID();";
                    int result = await connection.QuerySingleAsync<int>(sql, kategorie);
                    return result;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> UpdateKategorieAsync(Kategorie kategorie)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    string sql = "UPDATE Kategorie SET Bezeichnung = @Bezeichnung WHERE KId = @KId";
                    int result = await connection.ExecuteAsync(sql, kategorie);
                    return result > 0;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> DeleteKategorieAsync(int id)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    string sql = "DELETE FROM Kategorie WHERE KId = @KId";
                    int result = await connection.ExecuteAsync(sql, new { KId = id });
                    return result > 0;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Sichtung> GetSichtungByIdAsync(int id)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    string sql = "SELECT * FROM Sichtung WHERE SId = @SId";
                    Sichtung sichtung = await connection.QueryFirstOrDefaultAsync<Sichtung>(sql, new { SId = id });
                    return sichtung;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<Sichtung>> GetAllSichtungAsync()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    string sql = "SELECT * FROM Sichtung";
                    var sichtung = await connection.QueryAsync<Sichtung>(sql);
                    return sichtung.ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<Sichtung>> GetSichtungByKategorieIdAsync(int kategorieId)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    string sql = "SELECT * FROM Sichtung WHERE KategorieId = @KategorieId";
                    var sichtung = await connection.QueryAsync<Sichtung>(sql, new { KategorieId = kategorieId });
                    return sichtung.ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<Sichtung>> GetSichtungByMelderIdAsync(int melderId)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    string sql = "SELECT * FROM Sichtung WHERE MelderId = @MelderId";
                    var sichtung = await connection.QueryAsync<Sichtung>(sql, new { MelderId = melderId });
                    return sichtung.ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<int> AddSichtungAsync(Sichtung sichtung)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    string sql =
                        @"INSERT INTO Sichtung (MId, Titel, Anmerkung, Datum, Eintragsdatum, Laengengrad, Breitengrad, KId) 
                  VALUES ( @MId, @Titel, @Anmerkung, @Datum, @Eintragsdatum, @Laengengrad, @Breitengrad, @KId);
                  SELECT LAST_INSERT_ID();";
                    int result = await connection.QuerySingleAsync<int>(sql, sichtung);
                    return result;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> UpdateSichtungAsync(Sichtung sichtung)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    string sql =
                        @"UPDATE Sichtung SET MId = @MId, Titel = @Titel, Anmerkung = @Anmerkung, Datum = @Datum, Eintragsdatum = @Eintragsdatum, Laengengrad = @Laengengrad, Breitengrad = @Breitengrad, KId = @KId WHERE SId = @SId";
                    int result = await connection.ExecuteAsync(sql, sichtung);
                    return result > 0;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> DeleteSichtungAsync(int id)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    string sql = "DELETE FROM Sichtung WHERE SId = @SId";
                    int result = await connection.ExecuteAsync(sql, new { SId = id });
                    return result > 0;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            } 
        }

        public async Task<Bild> GetBildByIdAsync(int id)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    string sql = "SELECT * FROM Bild WHERE BId = @BId";
                    Bild bild = await connection.QueryFirstOrDefaultAsync<Bild>(sql, new { BId = id });
                    return bild;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<Bild>> GetBildBySichtungIdAsync(int sichtungId)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    string sql = "SELECT * FROM Bild WHERE SId = @SId";
                    var bild = await connection.QueryAsync<Bild>(sql, new { SId = sichtungId });
                    return bild.ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<Bild>> GetAllBildAsync()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    string sql = "SELECT * FROM Bild";
                    var bild = await connection.QueryAsync<Bild>(sql);
                    return bild.ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<int> AddBildAsync(Bild bild)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    string sql = "INSERT INTO Bild (Sid, Name) VALUES (@Sid, @Name); SELECT LAST_INSERT_ID();";
                    int result = await connection.QuerySingleAsync<int>(sql, bild);
                    return result;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> UpdateBildAsync(Bild bild)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    string sql = "UPDATE Bild SET Sid = @Sid, Name = @Name WHERE BId = @BId";
                    int result = await connection.ExecuteAsync(sql, bild);
                    return result > 0;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> DeleteBildAsync(int id)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    string sql = "DELETE FROM Bild WHERE BId = @BId";
                    int result = await connection.ExecuteAsync(sql, new { BId = id });
                    return result > 0;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}