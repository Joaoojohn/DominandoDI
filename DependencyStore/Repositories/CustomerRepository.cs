
using DependencyStore.Models;
using System.Data.SqlClient;
using Dapper;
using DependencyStore.Repositories.Contracts;

namespace DependencyStore.Repositories
{
    public partial class CustomerRepository : ICustomerRepository
    {
        private readonly SqlConnection _connection;

        public CustomerRepository(SqlConnection connection) => _connection = connection;

        public async Task<Customer?> GetByIdAsync(string customerId)
        {
            const string query = "SELECT [Id], [Name], [Email] FROM CUSTOMER WHERE ID=@id";

            return await _connection.QueryFirstAsync<Customer>(query, new { id = customerId });
        }
    }
}
