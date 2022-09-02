using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using KCTechStore.Models;

namespace KCTechStore.Repositories
{

    public interface IComputerRepository
    {
        public Task<IEnumerable<ShoeViewModel>> GetComputers();
        public void PostComputers(ShoeViewModel shoes);
    }


    public class ComputerRepository : IComputerRepository
    {
        private readonly IDbConnection _db;

        public ComputerRepository(IConfiguration db)
        {
            this._db = new SqlConnection(db.GetConnectionString("DefaultConnection"));
        }

        
        //Computer GET
        public async Task<IEnumerable<ShoeViewModel>> GetComputers()
        {

            var query = @"
SELECT ShoeID
	  ,ShoeName
	  ,size.SizeId AS SizeId
	  ,size.Sizes
	  ,Price
	  ,Description
	  ,Quantity
	  ,IsInStock
	  ,ShoePhoto
	  ,Condition
FROM dbo.Shoe
LEFT JOIN Size AS size
ON Shoe.SizeId = size.SizeId
";

            var ShoesDictionary = new Dictionary<int, ShoeViewModel>();

            IEnumerable<ShoeViewModel> shoes = await _db.QueryAsync<ShoeViewModel, SizeViewModel, ShoeViewModel>(query, (shoes, size) =>
            {
                ShoeViewModel shoe;
                if (!ShoesDictionary.TryGetValue(shoes.ShoeId, out shoe))
                {
                    shoe = shoes;
                    shoe.Sizes = new List<SizeViewModel>();
                    ShoesDictionary.Add(shoe.ShoeId, shoe);
                }

                return shoe;
            }, splitOn: "SizeId");

            var shoe = shoes.Distinct().ToList();
                
            return shoe;
        }

        //Computer POST
        public void PostComputers(ShoeViewModel shoes)
        {
            string query = @"
INSERT into Shoe (ShoeName, SizeId, Price, Description, Quantity, IsInStock, ShoePhoto, Condition)
VALUES (@ShoeName, @SizeId, @Price, @Description, @Quantity, @IsInStock, @ShoePhoto, @Condition)
";

            var result = _db.Execute(query, shoes);
        }

        //Computer PUT
        public void PutComputers()
        {

        }
    }
}
