using System;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using PortFolioPolLESSIRE0.DAL.Interfaces;
using PortFolioPolLESSIRE0.DAL.Entities;
using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace PortFolioPolLESSIRE0.DAL.Repositories
{
    public class CertificationRepository : ICertificationRepository
    {
    #nullable disable
        private readonly SqlConnection _connection;

        public CertificationRepository(SqlConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        public async Task<bool> AddCertificationAsync(Certification certification)
        {
            try
            {
                string sql = "INSERT INTO Certification (Name, Authority, LicenceNumber, Url, LicenceDate) VALUES " +
                    "(@Name, @Authority, @LicenceNumber, @Url, @LicenceDate)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Name", certification.Name);
                parameters.Add("@Authority", certification.Authority);
                parameters.Add("@LicenceNumber", certification.LicenceNumber);
                parameters.Add("@Url", certification.Url);
                parameters.Add("@LicenceDate", certification.LicenceDate);
                
                int rowsAffected = await _connection.ExecuteAsync(sql, parameters);
                return rowsAffected > 0 ;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding certification: {ex.ToString()}");
                return false;
            }
        }

        public void AddCertification(Certification certification)
        {
            try
            {
                string sql = @"INSERT INTO Certification (Name, Authority, LicenceNumber, Url, LicenceDate)" +
                    "VALUES (@name, @authority, @licenceNumber, @url, @licenceDate)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@name", certification.Name);
                parameters.Add("@authority", certification.Authority);
                parameters.Add("@licenceNumber", certification.LicenceNumber);
                parameters.Add("@url", certification.Url);
                parameters.Add("@licenceDate", certification.LicenceDate);

                _connection.Execute(sql, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating certification: {ex.ToString}");
            }
        }

        public async Task<IEnumerable<Certification?>> GetAllCertificationsAsync(bool includeInactive = false)
        {
            try
            {
                string sql = includeInactive ? "SELECT * FROM Cerification" : "SELECT * FROM Certification WHERE Active = 1";

                var certifications = await _connection.QueryAsync<Certification?>(sql);

                return certifications ?? Enumerable.Empty<Certification>();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error retrieving certifications: {ex.Message}");
                return Enumerable.Empty<Certification>();
            }
        }

        public async Task<Certification?> GetByIdCertificationAsync(int id)
        {
            try
            {
                string sql = "SELECT * FROM Certification WHERE Id = @id AND Active = 1";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@id", id, DbType.Int64);

                var certification = await _connection.QueryFirstOrDefaultAsync<Certification?>(sql, parameters);

                return certification;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting Certification : {ex.ToString}");

                return null;
            }
        }

        public Certification UpdateCertification(int id, string name, string authority, string licenceNumber, string url, DateTime licenceDate)
        {
            try
            {
                string sql = "UPDATE Certification SET Name = @name, Authority = @authority, LicenceNumber = @licenceNumber, Url = @url, LicenceDate = @licenceDate WHERE Id = @id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@name", name);
                parameters.Add("@authority", authority);
                parameters.Add("@licenceNumber", licenceNumber);
                parameters.Add("@url", url);
                
                return _connection.QueryFirst<Certification?>(sql, parameters);
            }
            catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            {

                Console.WriteLine($"Validation error : {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating certification : {ex}");
            }
            return new Certification();
        }
    }
}






















//Copyrite https://github.com/POLLESSI