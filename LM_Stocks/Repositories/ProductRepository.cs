using LM_Stocks.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LM_Stocks.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection DbConnection;

        public ProductRepository()
        {
            this.DbConnection = new SqlConnection("Server=localhost;database=LM_Stocks;user=sa;password=******");
            this.DbConnection.Open();
        }
        ~ProductRepository()
        {
            if (this.DbConnection != null)
                this.DbConnection.Close();
        }

        public Product Add(Product product)
        {
            IDbCommand insert = DbConnection.CreateCommand();
            insert.CommandText = "INSERT INTO Products (Name, Price, Validity, Lot, Weight, Quantity, Description) VALUES (@Name, @Price, @Validity, @Lot, @Weight, @Quantity, @Description);";

            IDbDataParameter paramName = new SqlParameter("Name", product.Name);
            IDbDataParameter paramPrice = new SqlParameter("Price", product.Price);
            IDbDataParameter paramValidity = new SqlParameter("Validity", product.Validity);
            IDbDataParameter paramLot = new SqlParameter("Lot", product.Lot);
            IDbDataParameter paramWeight = new SqlParameter("Weight", product.Weight);
            IDbDataParameter paramQuantity = new SqlParameter("Quantity", product.Quantity);
            IDbDataParameter paramDescription = new SqlParameter("Description", product.Description);

            insert.Parameters.Add(paramName);
            insert.Parameters.Add(paramPrice);
            insert.Parameters.Add(paramValidity);
            insert.Parameters.Add(paramLot);
            insert.Parameters.Add(paramWeight);
            insert.Parameters.Add(paramQuantity);
            insert.Parameters.Add(paramDescription);

            var rowsAffected = insert.ExecuteNonQuery();

            if (rowsAffected > 0)
                return product;

            return default;
        }

        public Product Get(int id)
        {
            var select = DbConnection.CreateCommand();
            select.CommandText = "SELECT ID, Name, Price, Validity, Lot, Weight, Quantity, Description FROM Products WHERE ID = @id;";

            IDataParameter paramId = new SqlParameter("ID", id);

            select.Parameters.Add(paramId);

            Product product = null;

            using (var reader = select.ExecuteReader())
                if (reader.Read())
                    product = new Product()
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Name = Convert.ToString(reader["Name"]),
                        Price = Convert.ToDecimal(reader["Price"]),
                        Validity = Convert.ToDateTime(reader["Validity"]),
                        Lot = Convert.ToString(reader["Lot"]),
                        Weight = Convert.ToDecimal(reader["Weight"]),
                        Quantity = Convert.ToInt32(reader["Quantity"]),
                        Description = Convert.ToString(reader["Description"])
                    };
            return product;
        }

        public IEnumerable<Product> GetAll()
        {
            ICollection<Product> list = new Collection<Product>();

            IDbCommand select = DbConnection.CreateCommand();
            select.CommandText = "SELECT ID, Name, Price, Validity, Lot, Weight, Quantity, Description FROM Products;";

            using (var reader = select.ExecuteReader())
                while (reader.Read())
                    list.Add(new Product()
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Name = Convert.ToString(reader["Name"]),
                        Price = Convert.ToDecimal(reader["Price"]),
                        Validity = Convert.ToDateTime(reader["Validity"]),
                        Lot = Convert.ToString(reader["Lot"]),
                        Weight = Convert.ToDecimal(reader["Weight"]),
                        Quantity = Convert.ToInt32(reader["Quantity"]),
                        Description = Convert.ToString(reader["Description"])
                    });
            return list;
        }

        public bool Remove(int id)
        {
            IDbCommand remove = DbConnection.CreateCommand();
            remove.CommandText = "DELETE FROM Products WHERE ID = @id;";
            IDbDataParameter paramId = new SqlParameter("ID", id);

            remove.Parameters.Add(paramId);

            var rowsAffected = remove.ExecuteNonQuery();

            return rowsAffected > 0;
        }

        public Product Update(Product entity, int id)
        {
            IDbCommand update = DbConnection.CreateCommand();
            update.CommandText = "UPDATE Products SET Name = @Name, Price = @Price, Validity = @Validity, Lot = @Lot, Weight = @Weight, Quantity = @Quantity, Description = @Description WHERE ID = @id;";

            IDbDataParameter paramId = new SqlParameter("ID", id);
            IDbDataParameter paramName = new SqlParameter("Name", entity.Name);
            IDbDataParameter paramPrice = new SqlParameter("Price", entity.Price);
            IDbDataParameter paramValidity = new SqlParameter("Validity", entity.Validity);
            IDbDataParameter paramLot = new SqlParameter("Lot", entity.Lot);
            IDbDataParameter paramWeight = new SqlParameter("Weight", entity.Weight);
            IDbDataParameter paramQuantity = new SqlParameter("Quantity", entity.Quantity);
            IDbDataParameter paramDescription = new SqlParameter("Description", entity.Description);

            update.Parameters.Add(paramId);
            update.Parameters.Add(paramName);
            update.Parameters.Add(paramPrice);
            update.Parameters.Add(paramValidity);
            update.Parameters.Add(paramLot);
            update.Parameters.Add(paramWeight);
            update.Parameters.Add(paramQuantity);
            update.Parameters.Add(paramDescription);

            var rowsAffected = update.ExecuteNonQuery();

            if (rowsAffected > 0)
                return entity;

            return default;

        }
    }
}
