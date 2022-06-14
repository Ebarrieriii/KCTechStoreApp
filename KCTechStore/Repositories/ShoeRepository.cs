using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using KCTechStore.Models;

namespace KCTechStore.Repositories
{

    public interface IShoeRepository
    {
        public IEnumerable<ShoeViewModel> GetShoes();
    }


    public class ShoeRepository : IShoeRepository
    {
        private readonly IDbConnection _db;

        public ShoeRepository(IConfiguration db)
        {
            this._db = new SqlConnection(db.GetConnectionString("DefaultConnection"));
        }


        public IEnumerable<ShoeViewModel> GetShoes()
        {

            string query = @"
SELECT ShoeID
	  ,ShoeName
	  ,s.Sizes
	  ,Price
	  ,Description
	  ,Quantity
	  ,IsInStock
	  ,ShoePhoto
	  ,Condition
FROM dbo.Shoe
INNER JOIN dbo.Size s
ON Shoe.SizeId = s.SizeId
";

            var shoes = this._db.Query<ShoeViewModel>(query).ToList();
                
               
            return shoes;
        }
    }
}
