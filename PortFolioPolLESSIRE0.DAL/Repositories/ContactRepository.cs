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
    public class ContactRepository : IContactRepository
    {
#nullable disable
        private readonly SqlConnection _connection;

        public ContactRepository(SqlConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        public async Task<bool> AddContactAsync(Contact contact)
        {
            try
            {
                string sql = "INSERT INTO Contact (Name, Email, Phone) VALUES " +
                    "(@Name, @Email, @Phone)";
            
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Name", contact.Name);
                parameters.Add("@Email", contact.Email);
                parameters.Add("@Phone", contact.Phone);
    
                int rowsAffected = await _connection.ExecuteAsync(sql, parameters);
                return rowsAffected > 0 ;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding contact: {ex.ToString()}");
                return false;
            }
        }

        public void AddContact(Contact contact)
        {
            try
            {
                string sql = @"INSERT INTO Contact (Name, Email, Phone)" +
                    "VALUES (@Name, @Email, @Phone)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Name", contact.Name);
                parameters.Add("@Email", contact.Email);
                parameters.Add("@Phone", contact.Phone);
                
                _connection.Execute(sql, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating contact: {ex.ToString}");
            }
        }

        public async Task<IEnumerable<Contact?>> GetAllContactsAsync(bool includeInactive = false)
        {
            try
            {
                string sql = includeInactive ? "SELECT * FROM Contact" : "SELECT * FROM Contact WHERE Active = 1";

                var contacts = await _connection.QueryAsync<Contact?>(sql);

                return contacts ?? Enumerable.Empty<Contact>();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error retrieving contacts: {ex.Message}");
                return Enumerable.Empty<Contact>();
            }
        }

        public async Task<Contact?> GetByIdContactAsync(int id)
        {
            try
            {
                string sql = "SELECT * FROM Contact WHERE Id = @id AND Active = 1";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@id", id, DbType.Int64);

                var contact = await _connection.QueryFirstOrDefaultAsync<Contact?>(sql, parameters);

                return contact;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting contact : {ex.ToString}");

                return null;
            }
        }

        public Contact UpdateContact(int id, string name, string email, string phone)
        {
            try
            {
                string sql = "UPDATE Contact SET Name = @name, Email = @email, Phone = @phone WHERE Id = @id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@name", name);
                parameters.Add("@email", email);
                parameters.Add("@phone", phone);
                return _connection.QueryFirst<Contact?>(sql, parameters);
            }
            catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            {

                Console.WriteLine($"Validation error : {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating contact : {ex}");
            }
            return new Contact();
        }
    }
}

















//Copyrite https://github.com/POLLESSI
