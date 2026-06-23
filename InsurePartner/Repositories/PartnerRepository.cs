using Microsoft.Data.SqlClient;
using Dapper;
using InsurePartner.Models;
namespace InsurePartner.Repositories
{
    public class PartnerRepository
    {
        private readonly string _connectionString;
        public PartnerRepository(string connectionString) => _connectionString = connectionString;

        public async Task<IEnumerable<dynamic>> GetAllPartnersWithPolicyStatsAsync()
        {
            using var db = new SqlConnection(_connectionString);

            string query = @"
                SELECT p.*, COUNT(po.Id) AS PolicyCount, ISNULL(SUM(po.Amount), 0) AS TotalAmount
                FROM Partners p 
                LEFT JOIN Policies po ON p.Id = po.PartnerId
                GROUP BY p.Id, p.FirstName, p.LastName, p.Address, p.PartnerNumber, p.CroatianPIN, p.PartnerTypeId, p.CreatedAtUtc, p.CreatedByUser, p.IsForeign, p.ExternalCode, p.Gender
                ORDER BY p.CreatedAtUtc DESC";

            return await db.QueryAsync(query);
        }

        public async Task<int> InsertPartnerAsync(Partner partner)
        {
            using var db = new SqlConnection(_connectionString);
            string query = @"
                INSERT INTO Partners (FirstName, LastName, Address, PartnerNumber, CroatianPIN, PartnerTypeId, CreatedAtUtc, CreatedByUser, IsForeign, ExternalCode, Gender)
                VALUES (@FirstName, @LastName, @Address, @PartnerNumber, @CroatianPIN, @PartnerTypeId, @CreatedAtUtc, @CreatedByUser, @IsForeign, @ExternalCode, @Gender);
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            return await db.QuerySingleAsync<int>(query, partner);
        }

        public async Task<int?> GetPartnerIdByExternalCodeAsync(string externalCode)
        {
            using var db = new SqlConnection(_connectionString);
            string query = "SELECT Id FROM Partners WHERE ExternalCode = @externalCode";
            return await db.QueryFirstOrDefaultAsync<int?>(query, new { externalCode });
        }

        public async Task InsertPolicyAsync(int partnerId, string policyNumber, decimal amount)
        {
            using var db = new SqlConnection(_connectionString);
            string query = "INSERT INTO Policies (PartnerId, PolicyNumber, Amount) VALUES (@partnerId, @policyNumber, @amount)";
            await db.ExecuteAsync(query, new { partnerId, policyNumber, amount });
        }
    }
}
