using Dapper;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;

namespace CoreEmplDapper.Models
{
    public class EmplRepository : IEmplRepository
    {
        string connectionString = null;
        public EmplRepository(string conn)
        {
            connectionString = conn;
        }
        public List<Empl> GetEmpls()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Empl>("SELECT * FROM Empl").ToList();
            }
        }
 
        public Empl Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Empl>("SELECT * FROM Empl WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }
 
        //переделать
        public void Create(Empl user)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO [dbo].[Empl] (FirstName ,LastName ,Title ,BirthDate ,City) VALUES (@FirstName, @LastName, @Title, @BirthDate, @City)";
                db.Execute(sqlQuery, user);
 
            }
        }
 
        //переделать
        public void Update(Empl empl)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Empl SET FirstName = @FirstName, LastName = @LastName, Title = @Title, BirthDate = @BirthDate, City = @City WHERE Id = @Id";
                db.Execute(sqlQuery, empl);
            }
        }
 
        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Empl WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }
    }
}
